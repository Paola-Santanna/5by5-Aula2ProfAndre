using Aula2_Prof_Andre;
using Controllers;
using Models;

internal class Program
{
    private static void Main(string[] args)
    {
        int opcaoEscolhida;

        do 
        {
            opcaoEscolhida = Menu.MenuOpcoes();
            Menu.OptionChoosed(opcaoEscolhida);

        }while (opcaoEscolhida != 0);

        //Irá mostrar todos os dados que estão no BD, de acordo com o número do Id, o qual deve ser maior que 990
        foreach (var car in new CarController().GetAll().Where(x => x.Id > 990).ToList())
        {
            Console.WriteLine(car);
        }
    }
}