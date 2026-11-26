using System.Configuration;
using System.Data.SqlClient;

namespace MERCADINHO
{
    internal class ConexaoDAL

    {
        private static readonly string conexao = ObterStringConexao();

        private static string ObterStringConexao()
        {
            ConnectionStringSettings configuracao =
                ConfigurationManager.ConnectionStrings["ConexaoSQL"];

            if (configuracao == null)
            {
                throw new ConfigurationErrorsException(
                    "A string de conexao 'ConexaoSQL' nao foi encontrada no arquivo de configuracao da aplicacao.");
            }

            return configuracao.ConnectionString;
        }

        public static SqlConnection ObterConexao()
        {
            return new SqlConnection(conexao);
        }
    }
}
