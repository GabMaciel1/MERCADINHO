using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace MERCADINHO
{
    internal class ServicoDAL
    {
            public static List<Produto> ObterTabelaProdutos()
            {
                List<Produto> lista = new List<Produto>();

                using (SqlConnection conexao = ConexaoDAL.ObterConexao())
                {
                    conexao.Open();

                    string sql = @"SELECT EAN13, Descricao, Unidade, Preco, Estoque
                               FROM Produtos";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto(
                                reader["EAN13"].ToString(),
                                reader["Descricao"].ToString(),
                                reader["Unidade"].ToString(),
                                Convert.ToDouble(reader["Preco"]),
                                Convert.ToDouble(reader["Estoque"])
                            );

                            lista.Add(produto);
                        }
                    }
                }

                return lista;
            }
        }
    }





        /* // Lucca Stern Bianchi, Arthur D Lucca Araújo Dos Santos
        // Murilo Queiroz Cardoso, Renato Henrique Leme De Alcântara

        private readonly static string Path = @"C:\TEMP\", Arq = "LISTAPROD.csv";

        public static List<string> ObterTabelaProdutos()
        {
            List<string> lista = new List<string>();
            bool funcionou = false;

            while (!funcionou)
            {
                try
                {
                    StreamReader sr = new StreamReader(Path + Arq);
                    funcionou = true;
                    string linha = sr.ReadLine();

                    if (linha == null)
                    {
                        sr.Close();
                        EscreverArquivo();
                        StreamReader sr2 = new StreamReader(Path + Arq);
                        while (!sr2.EndOfStream)
                            lista.Add(sr2.ReadLine());
                        sr2.Close();
                    }
                    else
                    {
                        lista.Add(linha);
                        while (!sr.EndOfStream)
                            lista.Add(sr.ReadLine());
                        sr.Close();
                    }
                }
                catch (IOException)
                {
                    Directory.CreateDirectory(Path);
                    EscreverArquivo();
                }
            }
            return lista;
        }

        public static void GravarTabelaProdutos(List<Produto> produtos)
        {
            try
            {
                Directory.CreateDirectory(Path);
                StreamWriter sw = new StreamWriter(new FileStream(Path + Arq, FileMode.Create));
                foreach (Produto produto in produtos)
                {
                    string precoStr = produto.Preco.ToString("f2", CultureInfo.InvariantCulture);
                    string estoqueStr = produto.Estoque.ToString("f2", CultureInfo.InvariantCulture);

                    sw.WriteLine($"{produto.EAN13}, {produto.Descricao}, {produto.Unidade}, {precoStr}, {estoqueStr}");
                }
                sw.Close();
                Console.WriteLine($"\nEstoque atualizado gravado em: {Path + Arq}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao gravar tabela de produtos: {ex.Message}");
            }
        }

        private static void EscreverArquivo()
        {
            StreamWriter sw = new StreamWriter(new FileStream(Path + Arq, FileMode.Create));
            sw.WriteLine("7891025101604, Leite, Und, 4.60, 250.00");
            sw.WriteLine("7891000105016, Barra cereal, Und, 3.20, 150.00");
            sw.WriteLine("7891000120101, Creme de leite, Und, 9.80, 100.00");
            sw.WriteLine("7891000100103, Leite condensado, Und, 10.90, 180.00");
            sw.WriteLine("7891999000538, Iogurte, Und, 2.90, 40.00");
            sw.WriteLine("7896051126041, Leite fermentado, Und, 5.10, 25.00");
            sw.WriteLine("7897236904805, Água, Und, 2.20, 62.00");
            sw.WriteLine("7622300830083, Biscoito recheado, Und, 3.40, 85.00");
            sw.WriteLine("7891150036567, Caldo de galinha, Und, 4.30, 30.00");
            sw.WriteLine("4005900036728, Desodorante, Und, 16.50, 50.00");
            sw.Close();
        }
    }
}*/