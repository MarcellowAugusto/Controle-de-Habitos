using Controle_de_Hábitos_Diários.Models;
using System.Collections.Generic;
using System.Linq;


namespace Controle_de_Hábitos_Diários.Controller
{
    public class Logica
    {
        public List<Controle> controles = new List<Controle>();

        public void CadastrarHabitos()
        {
            Console.Clear();
            AddGreen();
            Console.WriteLine("=== Cadastrar Novo Hábito ===");
            Console.ResetColor();

            var nome = NovoHabito();
            if (nome == null)
            {
                AddYellow();
                Console.WriteLine("\nCadastro de hábito cancelado pelo usuário.");
                Console.ResetColor();
                return;
            }
            Console.Clear();
            var quantasVezes = QuantasVezes();
            Console.Clear();
            var metaDiaria = MetaDiaria();

            var novoHabito = new Controle(nome, quantasVezes, metaDiaria);

            controles.Add(novoHabito);

            AddGreen();
            Console.WriteLine("\nHábito cadastrado com sucesso!");
            Console.ResetColor();
        }

       private string? NovoHabito()
       {
           while (true)
           {
                AddGreen();
                Console.Write("\nDigite o nome do novo hábito.(ou digite 'sair' para cancelar): ");
                var nome = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome inválido. Tente novamente.");                  
                    continue;
                }
                if (nome.ToLower() == "sair")
                {
                    return null;
                }
                return nome;                                      
           }  
       }

        private int QuantasVezes()
        {
            while (true)
            {
                AddGreen();
                Console.Write("Quantas vezes você pretende realizar esse hábito por dia: ");
                var input = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(input, out int quantasVezes) && quantasVezes > 0)
                {
                    return quantasVezes;
                }

                AddRed();
                Console.WriteLine("\nNúmero inválido. Digite um número maior que zero.");
                Console.ResetColor();

                AddYellow();
                Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }


        private int MetaDiaria()
       {
            while (true)
            {
                ClearGreen();
                Console.Write("Metas de dias para essa hábito: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out int MetaDiariaValor))
                {
                    AddRed();
                    Console.WriteLine("\nNúmero inválido. Tente novamente.");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    return MetaDiariaValor;
                }           
            }
       }

       public void ListarHabitos()
       {
            if (!controles.Any())
            {
                AddRed();
                Console.WriteLine("Nenhum hábito cadastrado.");
                Console.ResetColor();
                return;
            }

            MostrarOpcao();          
       }

        public void AtualizarHabito()
        {
            if(!controles.Any())
            {
                AddRed();
                Console.WriteLine("Nenhum hábito cadastrado para atualizar.");
                Console.ResetColor();
                return;
            }

            MostrarOpcao();

            AddGreen();
            Console.Write("\nDigite o nome do hábito que deseja atualizar.(ou digite 'sair' para voltar ao menu): ");
            string? nomeParaAtualizar = Console.ReadLine();

            if(string.Equals(nomeParaAtualizar, "sair", StringComparison.OrdinalIgnoreCase))
            {
                Console.ResetColor();
                return;
            }

            var habitoParaAtualizar = controles.FirstOrDefault(h => h.Nome.Equals(nomeParaAtualizar, StringComparison.OrdinalIgnoreCase));

            if (habitoParaAtualizar == null)
            {
                AddRed();
                Console.WriteLine("Hábito não encontrado.");
                Console.ResetColor();
                return;
            }
            else
            {
                AddGreen();
                Console.Clear();
                bool rodando = true;

                while (rodando)
                {
                    Console.WriteLine("O que deseja atualizar?");
                    Console.WriteLine("=========================");
                    Console.WriteLine("\n1. Nome");
                    Console.WriteLine("2. Quantas Vezes");
                    Console.WriteLine("3. Meta Diária");
                    Console.WriteLine("4. atualizar o 'status'");
                    Console.WriteLine("5. Sair");
                    Console.WriteLine("\n=========================");

                    Console.Write("\nQual deseja atualizar? digite o número: ");
                    if(!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        AddRed();
                        Console.WriteLine("\nOpção inválida.");
                        Console.ResetColor();
                        continue;
                    }

                    Console.Clear();
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Digite o novo nome (ou Enter para manter): ");
                            var novoNome = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(novoNome))
                            {
                                habitoParaAtualizar.Nome = novoNome;
                                AddGreen();
                                Console.WriteLine("\nNome atualizado com sucesso!");
                            }
                            else
                            {
                                AddYellow();
                                Console.WriteLine("\nNome não alterado.");
                            }
                            break;

                        case 2:
                            Console.Write("Digite o novo valor para Quantas Vezes (ou Enter para manter): ");
                            var novoQuantasVezesInput = Console.ReadLine();
                            if (int.TryParse(novoQuantasVezesInput, out int novoQuantasVezes))
                            {
                                habitoParaAtualizar.QuantasVezes = novoQuantasVezes;
                                AddGreen();
                                Console.WriteLine("\nFrequência diária atualizada com sucesso!");
                            }
                            else
                            {
                                AddYellow();
                                Console.WriteLine("\nValor não alterado ou inválido.");
                            }
                            break;

                        case 3:
                            Console.Write("Digite o novo valor para Meta Diária (ou Enter para manter): ");
                            var novaMetaDiariaInput = Console.ReadLine();
                            if (int.TryParse(novaMetaDiariaInput, out int novaMetaDiaria))
                            {
                                habitoParaAtualizar.MetaDiaria = novaMetaDiaria;
                                AddGreen();
                                Console.WriteLine("\nMeta diária atualizada com sucesso!");
                            }
                            else
                            {
                                AddYellow();
                                Console.WriteLine("\nValor não alterado ou inválido.");
                            }
                            break;

                        case 4:
                            Console.Write("Digite o novo status ('concluido' ou 'nao concluido'): ");
                            var statusInput = Console.ReadLine();
                            if (string.Equals(statusInput, "concluido", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(statusInput, "nao concluido", StringComparison.OrdinalIgnoreCase))
                            {
                                habitoParaAtualizar.AtualizarStatus(statusInput);
                                AddGreen();
                                Console.WriteLine("\nStatus atualizado com sucesso!");
                            }
                            else
                            {
                                AddRed();
                                Console.WriteLine("\nStatus inválido. Use 'concluido' ou 'nao concluido'.");
                            }
                            break;

                        case 5:
                            rodando = false;
                            continue;

                        default:
                            AddRed();
                            Console.WriteLine("\nOpção inválida.");
                            break;
                    }

                    AddYellow();
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        public void RemoverHabito()
        {
            if (!controles.Any())
            {
                AddRed();
                Console.WriteLine("Nenhum hábito cadastrado para remover.");
                Console.ResetColor();
                return;
            }

            MostrarOpcao();

            Console.WriteLine("\nDigite o nome do hábito que deseja remover: ");
            var removerHabito = Console.ReadLine();

            var habitoParaRemover = controles.FirstOrDefault(h => h.Nome.Equals(removerHabito, StringComparison.OrdinalIgnoreCase));

            if(habitoParaRemover == null)
            {
                AddRed();
                Console.WriteLine("\nHábito não encontrado.");
                Console.ResetColor();
                return;
            }
            else
            {
                controles.Remove(habitoParaRemover);
                AddGreen();
                Console.WriteLine("\nHábito removido com sucesso!");
                Console.ResetColor();
            }
        }

        public void MostrarOpcao()
        {
            Console.Clear();
            AddGreen(); 
            Console.WriteLine("=== Lista de Hábitos Cadastrados ===");

            foreach (var habito in controles)
            {            
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Nome: {habito.Nome}");
                Console.WriteLine($"Frequência diária: {habito.QuantasVezes}");
                Console.WriteLine($"Dias Seguidos: {habito.DiasSeguidos}");
                Console.WriteLine($"Meta Diária: {habito.MetaDiaria}");           
                Console.ResetColor();

                AddGreen();
                Console.Write("Status de hoje:");
                Console.ResetColor();
                if (habito.Status)
                    AddYellow();
                else
                    AddRed();
                
                Console.Write($" {habito.StatusFormatado}");
                Console.ResetColor();
            }
            AddGreen();
            Console.WriteLine("\n------------------------------------");
            Console.ResetColor();
        }

        public void AddGreen()
        {
           Console.ForegroundColor = ConsoleColor.Green;
        }    
        public void AddRed()
        {
           Console.ForegroundColor = ConsoleColor.Red;
        }
        public void AddYellow()
        {
           Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void ClearGreen()
        {
            Console.Clear();
            AddGreen();
        }




    }
}
