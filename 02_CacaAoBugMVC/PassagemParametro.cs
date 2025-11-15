//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using _02_CacaAoBugMVC.Controller;
//using _02_CacaAoBugMVC.Model;

//namespace _02_CacaAoBugMVC
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            {
//                var controller = new AlunoController();
//                var val = controller.GetValidacaoService();

//                Console.WriteLine("=== CaçaAoBug – Sistema de Notas (MVC Console) ===");

//                bool continuarSistema = true;
//                while (continuarSistema)
//                {

//                    bool continuarCadastro = true;
//                    while (continuarCadastro)
//                    {
//                        // Nome
//                        string nome;
//                        do
//                        {
//                            Console.Write("Informe o nome do aluno: ");
//                            nome = Console.ReadLine() ?? string.Empty;
//                            if (!val.ValidaNome(nome, out string erroNome))
//                            {
//                                Console.WriteLine($"Nome inválido: {erroNome}");
//                            }
//                            else break;
//                        } while (true);

//                        // Nota1
//                        double nota1 = LerNotaConsole(val, "Digite a primeira nota: ");

//                        // Nota2
//                        double nota2 = LerNotaConsole(val, "Digite a segunda nota: ");

//                        // Nota3
//                        double nota3 = LerNotaConsole(val, "Digite a terceira nota: ");

//                        var aluno = new Aluno
//                        {
//                            Nome = nome.Trim(),
//                            Nota1 = nota1,
//                            Nota2 = nota2,
//                            Nota3 = nota3
//                        };

//                        if (!controller.AdicionarAluno(aluno, out string mensagemErro))
//                        {
//                            Console.WriteLine($"Não foi possível adicionar o aluno: {mensagemErro}");
//                        }
//                        else
//                        {
//                            Console.WriteLine($"\nAluno cadastrado: {aluno.Nome} | Média: {aluno.Media:F2} | Situação: {aluno.Situacao}");
//                        }

//                        Console.Write("\nDeseja cadastrar outro aluno neste ciclo? (S/N): ");
//                        string resp = (Console.ReadLine() ?? "").Trim().ToUpper();
//                        if (resp != "S") continuarCadastro = false;
//                    }

//                    // Estatísticas do ciclo
//                    Console.WriteLine("\n=== Estatísticas da Turma (até agora) ===");
//                    var alunos = controller.ObterAlunos();
//                    Console.WriteLine($"Total de alunos cadastrados: {alunos.Count}");
//                    Console.WriteLine($"Taxa de aprovação: {controller.ObterTaxaAprovacao():F1}%");

//                    Console.Write("\nDeseja iniciar outro ciclo (limpar e continuar)? (S/N): ");
//                    string r = (Console.ReadLine() ?? "").Trim().ToUpper();
//                    if (r != "S") continuarSistema = false;
//                }

//                Console.WriteLine("\nEncerrando o sistema. Obrigado!");
//            }
//        }

//        private static double LerNotaConsole(Model.ValidacaoService val, string prompt)
//        {
//            while (true)
//            {
//                Console.Write(prompt);
//                string entrada = Console.ReadLine() ?? string.Empty;
//                if (val.TentarConverterNota(entrada, out double nota))
//                {
//                    return nota;
//                }
//                Console.WriteLine("Valor inválido. Informe um número entre 0 e 10 (ex: 7.5).");
//            }
//        }
//    }
    
//}
