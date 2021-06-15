using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFitness.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite seu nome");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite sua altura");
            var altura = Console.ReadLine();

            Console.WriteLine("Digite o seu peso");
            var peso = Console.ReadLine();

            var listaRefeicoes = new List<Refeicao>();

            

             
            var opcao = "-1";
            while (opcao != "0")
            {
                ExibirOpcoes();
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Nome: {nome}, Altura:{altura}, Peso:{peso}");
                        break;
                    case "2":
                        Cadastrar(listaRefeicoes);
                        break;
                    case "3":
                        ListarRefeicoes(listaRefeicoes);
                        break;
                    default:
                        Console.WriteLine("Por favor, digite outra opção");
                        break;
                }
            }

            ////var notas = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ////var anyNumeroMaiorQue3 = notas.Any(n => n > 3);
            ////var firstNota = notas.First(n => n == 2);
            ////var singleNota = notas.Single(n => n == 9);
            ////var ordered = notas.OrderBy(n=>n);
            ////var max = notas.Max();
            ////var min = notas.Min();
            ////var sum = notas.Sum();
            ////var average = notas.Average();

            Console.WriteLine("Fechando o app!");
            Console.Read();
        }

        public static void ExibirOpcoes()
        {
            Console.WriteLine("--- Seja Bem Vindo(a) ao DevFitness ---");
            Console.WriteLine("1 - Exibir detalhes do usuário");
            Console.WriteLine("2 - Cadastrar nova refeição");
            Console.WriteLine("3 - Listar todas refeições");
            Console.WriteLine("0 - Finalizar aplicaçãO");
        }

        public static void Cadastrar(List<Refeicao>refeicoes)
        {
            Console.WriteLine("Digite a descrição da refeção");
            var descricao = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de calorias");
            var calorias = Console.ReadLine();

            if(int.TryParse(calorias, out int caloriasInt))
            {
                var refeicao = new Refeicao(descricao, caloriasInt);
                refeicoes.Add(refeicao);

                Console.WriteLine("Refeição adicionada com Sucesso");
            }
            else
            {
                Console.WriteLine("Valor de caloria Inválida");
            }
        }

        public static void ListarRefeicoes(List<Refeicao> refeicoes)
        {
            foreach(var refeicao in refeicoes)
            {
                refeicao.ImprimirMensagem();
            }
        }
    }
}
