namespace ConexaoBD03
{
    internal class Program
    {
        public class Categoria
        {
            public int Id { get; set; }
            public string? Descricao { get; set; }
        }
    }

        static void Main(string[] args)
        {
            //IncluirCategoria();
            ListarCategoria();
        }

        static string conexao = @"Data Source=(localdb)\MSSQLLocalDB; 
                               Initial Catalog= DbProdutos;
                               Integrated Security=True";
        static void ListarCategoria()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var categorias = conn.Query<Categoria>("Select * from TBCategorias");
                foreach (var item in categorias)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Descrição: " + item.Descricao);
                    Console.WriteLine("------------------------------------");
                }
                static void Main(string[] args)
                {

                }
            }
