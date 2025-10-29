
using Controle_de_Hábitos_Diários.Controller;

namespace Controle_de_Hábitos_Diários.Models
{
    public class Controle
    {
        public string? Nome { get; set; }
        public int QuantasVezes { get; set; }
        public int MetaDiaria { get; set; }     
        public bool Status { get; set; } = false;
        public int DiasSeguidos { get; set; } = 0;

        public Controle(string nome, int quantasVezes, int metaDiaria)
        
        {
            Nome = nome;
            QuantasVezes = quantasVezes;
            MetaDiaria = metaDiaria;
        }
    
        public void AtualizarStatus(string statusInput)
        {
            if (statusInput.ToLower() == "concluido")
            {
                Status = true;
                DiasSeguidos++;
            }
            else if (statusInput.ToLower() == "nao concluido")
            {
                Status = false;
                DiasSeguidos = 0;
            }
        }

        public string StatusFormatado => Status? "Concluído" : "Não Concluído";
        


    }
}