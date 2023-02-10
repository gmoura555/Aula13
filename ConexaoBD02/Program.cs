
using Dapper;
using System.Data.SqlClient;
using System;

namespace ConexaoBD02
{

    internal class Program
    {
        public int id { get; set; }
        public string? Descricao { get; set; }

        static void Main(string[] args)
        {

            int opcao;
            ExibeMenu();
            Console.Write("Escolha a sua opção: ");
            opcao = int.Parse(Console.ReadLine());



            while (opcao != 5)
            {
                if (opcao == 1)
                {
                    IncluirCategoria();
                }
                if (opcao == 2)
                {
                    ListarCategoria();
                }
                if (opcao == 3)
                {
                    AlterarCategoria();
                }
                if (opcao == 5)
                {
                    ExcluirCategoria();
                }
                Console.Write("Escolha opção:  ");
                opcao = int.Parse(Console.ReadLine());
            }



        }

        static string conexao = @"Data Source=(localdb)\MSSQLLocalDB; 
                               Initial Catalog= DbProdutos;
                               Integrated Security=True";

        static void ExibeMenu()
        {

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("1 - Incluir");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Alterar");
            Console.WriteLine("5 - Sair");
            Console.WriteLine(new string('-', 50));

        }

        static void IncluirCategoria()
        {
            string resposta;
            do

            {
                Console.Write("Informe a Categoria");
                string categoria = Console.ReadLine();

                using (var conn = new SqlConnection(conexao))
                {

                    var registros = conn
                        .Execute("Insert into TBCategorias (Descricao) values (@Descricao)",
                        new { Descricao = categoria });
                    Console.WriteLine("Registros inseridos: " + registros);
                    Console.Write("Continuar a Inserir? (S/N)");

                }
                resposta = Console.ReadLine();
                Console.WriteLine(resposta);
            } while (resposta == "s");
            ExibeMenu();


        }
        static void ExcluirCategoria()
        {
            Console.Write("Informe o Código: ");
            int codigo = int.Parse(Console.ReadLine());
            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("Delete from TBCategorias where Id=@Id",
                    new { Id = codigo });
                Console.WriteLine("Registro Removido: " + registros);
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            ExibeMenu();

        }

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
                Console.WriteLine("Prescione uma tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            ExibeMenu();


        }

        static void AlterarCategoria()
        {
            //update nomedatabela SET Descricao=@Descricao where Id=@id;
            Console.Write("Informe o Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a nova Categoria");
            string categoria = Console.ReadLine();

            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("Update TBCategorias set Descricao=@Descricao where Id=@id",
                    new { Id = codigo, Descricao = categoria });
                Console.WriteLine("registros Alterados: " + registros);

            }

        }
    }
}
