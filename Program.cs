using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                    break;
                    case "2":
                        InserirSerie();
                    break;
                    case "3":
                        AtualizarSerie();
                    break;
                    case "4":
                        ExcluirSerie();
                    break;
                    case "5":
                        VisualizarSerie();
                    break:
                    case "C":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                } 
                opcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por usar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.lista();

            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornoTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));  
            }
            Console.Write("Digite o genero entre opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano do inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id:repositorio.proximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo:entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO series a seu dispor!!!");
            Console.WriteLine("Informe opção desejada");

            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir serie");
            Console.WriteLine("3- atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("c- Limpar Telas");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
