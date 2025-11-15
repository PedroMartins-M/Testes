using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _02_CacaAoBugMVC.Controller;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AlunoController controller = new AlunoController();
            var validacao = controller.GetValidacaoService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Sistema de Notas - Caça ao Bug MVC ====");
                string nome;
                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine("Informe o nome do Aluno");
                        nome = Console.ReadLine();
                        if (validacao.ValidaNome(nome, out string msgErro)) break;

                        Console.WriteLine($"Erro \n{msgErro}\n");
                    }

                    double nota1 = Program.LerNota("1º", validacao);
                    double nota2 = Program.LerNota("2º", validacao);
                    double nota3 = Program.LerNota("3º", validacao);
                     
                    //----------- Criar o objeto aluno e enviar para a controller -----------//

                    var aluno = new Aluno()
                    {
                        Nome = nome,
                        Nota1 = nota1,
                        Nota2 = nota2,
                        Nota3 = nota3,
                    };

                    if (controller.AdicionarAluno(aluno, out string msgErroAdd))
                    {
                        Console.WriteLine($"\nMédia: {aluno.Media}");
                        Console.WriteLine($"Situação: {aluno.Situacao}");
                    }

                    else
                    {
                        Console.WriteLine($"Erro: {msgErroAdd}");
                    }

                    Console.WriteLine("Deseja cadastrar outro aluno? (S/N)");
                    if (Console.ReadLine().ToUpper() != "S") break;
                }

                //----------- estatísticas de Aprovação --------------//
                Console.WriteLine(($"Taxa de Aprovação:  {controller.ObterTaxaAprovacao():f2}%"));

                Console.WriteLine("Deseja reiniciar o Sistema? (S/N)");
                if (Console.ReadLine().ToUpper() != "S") break;
            }
        }

        public static double LerNota(string nota, ValidacaoService validacao)
        {
            while (true)
            {
                Console.Write($"Informe a {nota} Nota: ");
                string entrada = Console.ReadLine();
                //return double.Parse(entrada );
                if( validacao.TentarConverterNota(entrada,out double valorNota) ) return valorNota;

                Console.WriteLine("Nota inválida! Digite um número entre 0 a 10");

            }
        }
    } 
}
