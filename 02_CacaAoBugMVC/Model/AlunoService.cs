using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC.Model
{
    internal class AlunoService
    {
        public double calcularMedia(double n1, double n2, double n3)
        {
            return (n1 + n2 + n3) / 3;
        }
        public string Obtersituacao(double media)
        {
            if (media >= 7)
                return "Aprovado";
            else if (media >= 4)
                return "Em Exame Final";
            else
                return "Reprovado";
        }

        public double CalcularTaxaAprovacao(int totalAlunos, int alunosAprovados)
        {
            //Transforma a variável do tipo int para double utilizando o CAST (tipo)variável
            return (alunosAprovados / (double)totalAlunos) * 100.0;
        }
    }
}
