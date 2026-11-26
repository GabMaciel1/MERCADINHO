using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace MERCADINHO
{

    internal class CupomDAL
    {
        public static int ObterProxCupom()
        {
            using (SqlConnection conexao = ConexaoDAL.ObterConexao())
            {
                conexao.Open();

                string sql = "SELECT NEXT VALUE FOR dbo.SeqCupom";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static bool GravarCupom(Cupom cupom)
        {
            using (SqlConnection conexao = ConexaoDAL.ObterConexao())
            {
                conexao.Open();

                SqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    // Grava o cupom
                    string sqlCupom = @"
                        INSERT INTO Cupons
                        (Numero, Emissao, Cliente, ValorTotal)
                        VALUES
                        (@Numero, @Emissao, @Cliente, @ValorTotal)";

                    using (SqlCommand cmd = new SqlCommand(
                        sqlCupom, conexao, transacao))
                    {
                        cmd.Parameters.Add("@Numero", SqlDbType.Int)
                            .Value = cupom.Numero;

                        cmd.Parameters.Add("@Emissao", SqlDbType.DateTime)
                            .Value = cupom.Emissao;

                        cmd.Parameters.Add("@Cliente", SqlDbType.VarChar, 14)
                            .Value = string.IsNullOrWhiteSpace(cupom.Cliente)
                                ? (object)DBNull.Value
                                : cupom.Cliente;

                        cmd.Parameters.Add("@ValorTotal", SqlDbType.Decimal)
                            .Value = cupom.CalcularValorTotal();

                        cmd.Parameters["@ValorTotal"].Precision = 10;
                        cmd.Parameters["@ValorTotal"].Scale = 2;

                        cmd.ExecuteNonQuery();
                    }

                    // Grava os itens e atualiza os estoques
                    foreach (Cupom.ItemCupom item in cupom.Itens)
                    {
                        // Atualiza o estoque diretamente no banco
                        string sqlEstoque = @"
                            UPDATE Produtos
                            SET Estoque = Estoque - @Quantidade
                            WHERE EAN13 = @EAN13
                            AND Estoque >= @Quantidade";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlEstoque, conexao, transacao))
                        {
                            cmd.Parameters.Add("@Quantidade", SqlDbType.Decimal)
                                .Value = item.Quantidade;

                            cmd.Parameters["@Quantidade"].Precision = 10;
                            cmd.Parameters["@Quantidade"].Scale = 2;

                            cmd.Parameters.Add("@EAN13", SqlDbType.VarChar, 13)
                                .Value = item.Item.EAN13;

                            int linhas = cmd.ExecuteNonQuery();

                            if (linhas == 0)
                            {
                                throw new Exception(
                                    "Estoque insuficiente ou produto não encontrado: "
                                    + item.Item.Descricao);
                            }
                        }

                        // Insere o item do cupom
                        string sqlItem = @"
                            INSERT INTO ItensCupom
                            (NumeroCupom, EAN13, Quantidade, PrecoUnitario)
                            VALUES
                            (@NumeroCupom, @EAN13, @Quantidade, @Preco)";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlItem, conexao, transacao))
                        {
                            cmd.Parameters.Add("@NumeroCupom", SqlDbType.Int)
                                .Value = cupom.Numero;

                            cmd.Parameters.Add("@EAN13", SqlDbType.VarChar, 13)
                                .Value = item.Item.EAN13;

                            cmd.Parameters.Add("@Quantidade", SqlDbType.Decimal)
                                .Value = item.Quantidade;

                            cmd.Parameters["@Quantidade"].Precision = 10;
                            cmd.Parameters["@Quantidade"].Scale = 2;

                            cmd.Parameters.Add("@Preco", SqlDbType.Decimal)
                                .Value = item.Item.Preco;

                            cmd.Parameters["@Preco"].Precision = 10;
                            cmd.Parameters["@Preco"].Scale = 2;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Confirma todas as operações
                    transacao.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    // Desfaz tudo caso ocorra algum erro
                    transacao.Rollback();

                    System.Windows.Forms.MessageBox.Show(
                        "Erro ao gravar cupom: " + ex.Message,
                        "Erro",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);

                    return false;
                }
            }
        }
    }
}



/*   // Lucca Stern Bianchi, Arthur D Lucca Araújo Dos Santos
   // Murilo Queiroz Cardoso, Renato Henrique Leme De Alcântara

   private readonly static string Path = @"C:\TEMP\", Arq = "NUMCUPOM.txt";

   public static int ObterProxCupom()
   {
       try
       {
           StreamReader sr = new StreamReader(Path + Arq);
           int proxNum = int.Parse(sr.ReadLine());
           sr.Close();
           return proxNum;
       }
       catch (IOException)
       {
           Directory.CreateDirectory(Path);
           EscreverArquivo(1);
           return 1;
       }
       catch (FormatException)
       {
           EscreverArquivo(1);
           return 1;
       }
   }

   public static void GravarProxCupom(int num)
   {
       EscreverArquivo(num + 1);
   }

   public static bool GravarCupom(Cupom cupom)
   {
       Directory.CreateDirectory(Path);
       try
       {
           StreamWriter sw = new StreamWriter(new FileStream($"{Path}CUPOM{cupom.Numero:000000}.txt", FileMode.Create, FileAccess.Write));
           sw.WriteLine($"{cupom.Numero}, {cupom.Emissao}, {cupom.Cliente}");

           foreach (Cupom.ItemCupom item in cupom.Itens)
           {
               string quantidadeStr = item.Quantidade.ToString("f2", CultureInfo.InvariantCulture);
               string precoStr = item.Item.Preco.ToString("f2", CultureInfo.InvariantCulture);

               sw.WriteLine($"{item.Item.EAN13} - {quantidadeStr} X {precoStr}");
           }
           sw.Close();
           return true;
       }
       catch (Exception ex)
       {
           Console.WriteLine($"Erro ao gravar cupom: {ex.Message}");
           return false;
       }
   }

   private static void EscreverArquivo(int num)
   {
       Directory.CreateDirectory(Path);
       StreamWriter sw = new StreamWriter(new FileStream(Path + Arq, FileMode.Create));
       sw.Write(num);
       sw.Close();
   }
}
}*/