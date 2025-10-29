using Controle_de_Hábitos_Diários.Controller;
namespace Controle_de_Hábitos_Diários.View
{
    public class Menu
    {
        Logica logica = new Logica();
        public void MenuHabitos()
        {
            bool Rodando = true;

            while (Rodando)
            {
                logica.ClearGreen();
                Console.WriteLine("=== Controle de Hábitos Diários ===");
                Console.WriteLine("\n1. Adicionar Hábito");
                Console.WriteLine("2. Ver Hábitos");
                Console.WriteLine("3. Atualizar Hábito");
                Console.WriteLine("4. Remover Hábito");
                Console.WriteLine("5. Sair");              
                Console.Write("\nSelecione uma opção: ");             
               
                if (!int.TryParse(Console.ReadLine(), out int opcao))              
                {
                    logica.AddRed();
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ResetColor();
                    logica.AddGreen();
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                switch (opcao)
                {
                    case 1: logica.CadastrarHabitos(); break;
                    case 2: logica.ListarHabitos(); break;
                    case 3: logica.AtualizarHabito(); break;
                    case 4: logica.RemoverHabito(); break;
                    case 5: Rodando = false; break; 
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                if (Rodando)
                {
                    logica.AddGreen();
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}
