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
                    break;
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

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
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
