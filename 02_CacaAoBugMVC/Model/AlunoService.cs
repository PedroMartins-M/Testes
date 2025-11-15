using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC.Model
{
    public class AlunoService
    {
        public double CalcularMedia(double n1, double n2, double n3)
        {
            // não valida entradas aqui; validações ficam no ValidacaoService/Controller
            return Math.Round ((n1 + n2 + n3) / 3.0, 2);
        }

        public string ObterSituacao(double media)
        {
            if (media >= 7.0) return "Aprovado";
            if (media >= 5.0) return "Em Exame Final";
            return "Reprovado";
        }

        public double CalcularTaxaAprovacao(int total, int aprovados)
        {
            if (total <= 0) return 0.0;
            return (aprovados / (double)total) * 100.0;
        }
    }
}
