
using System.Data.SqlClient;

namespace ConexaoBd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string de conexão
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True
            string conexao = @"Data source=(localdb)\MSSQLLocalDB ;
                            Initial Catalog=DbProdutos;
                            Integrated Security=True";
            //criar conexao
            var cn = new SqlConnection();
            cn.ConnectionString= conexao;

            //abrir conexão
            cn.Open();

            //ORM - Objetc Relational Mapping
            //Dapper
            //Entity

            //fechar Conexao
            cn.Close();

        }
    }
}