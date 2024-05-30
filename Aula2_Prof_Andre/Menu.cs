using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2_Prof_Andre
{
    internal class Menu
    {
        public Menu() { }

        public static int MenuOpcoes() 
        {
            bool result;
            int opcao;

            Console.WriteLine(">>>MENU<<<");
            Console.WriteLine("1 -> INSERT");
            Console.WriteLine("2 -> UPDATE");
            Console.WriteLine("3 -> DELETE");
            Console.WriteLine("4 -> GET");
            Console.WriteLine("5 -> GET_ALL");
            Console.WriteLine("0 -> SAIR");
            Console.Write("Sua Resposta: ");
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            return opcao;
        }

        public static void OptionChoosed(int option)
        {
            Car car = CarData();

            switch (option)
            {
                case 0:
                    Console.WriteLine("\nSaindo...");
                    break;

                case 1:
                    Console.WriteLine("EXEMPLO INSERT: ");
                    Console.WriteLine(new CarController().Insert(car) ? "Registro Inserido" : "Erro ao inserir Registro");

                    Console.WriteLine("\nVALIDAÇÃO: ");
                    foreach (var item in new CarController().GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 2:
                    Console.WriteLine("\nEXEMPLO UPDATE: ");
                    Console.WriteLine(new CarController().Update(car) ? "Registro Atualizado" : "Erro ao atualizar Registro");
                    Console.WriteLine("VALIDAÇÃO: ");
                    foreach (var item in new CarController().GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 3:
                    Console.WriteLine("\nEXEMPLO DELETE: ");
                    Console.WriteLine(new CarController().Delete(car.Id) ? "Registro Deletado" : "Erro ao deletar Registro");
                    Console.WriteLine("VALIDAÇÃO: ");
                    foreach (var item in new CarController().GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 4:
                    Console.WriteLine("\nEXEMPLO GET: ");
                    Console.WriteLine(new CarController().Get(1));
                    break;

                case 5:
                    Console.WriteLine("EXEMPLO GET_ALL: ");
                    foreach (var item in new CarController().GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                default:
                    Console.WriteLine("\nOpção Inválida!\n");
                    break;
            }
        }

        public static Car CarData()
        {
            Console.WriteLine("Início do processamento".ToUpper());

            Car car = new Car
            {
                Id = 1,
                Name = "Carro Muito Diferente",
                Color = "Vermelho",
                Year = 1234
            };
            Console.WriteLine(car);

            Console.WriteLine("\n\nPressione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();

            return car;
        }
        
    }
}
