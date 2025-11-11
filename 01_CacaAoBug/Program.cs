using System;
using System.Text.RegularExpressions;

namespace CacaAoBug
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Notas do Aluno ===");
                double totalAlunos = 0;
                double aprovados = 0;
                do
                {
                    string nome;
                    do
                    {
                        Console.Write("Informe o nome do aluno: ");
                        nome = Console.ReadLine();
                    } while (!ValidaNome(nome));
                    totalAlunos++;
                    //} while (ValidaNome(nome) == false);

                    /*bool nomeCorreto = false;
                    while( nomeCorreto == false)
                    {
                        Console.Write("Informe o nome do aluno: ");
                        nome = Console.ReadLine();
                        nomeCorreto = ValidaNome(nome);
                    } */

                    double nota1;
                    do
                    {
                        Console.Write("Digite a primeira nota: ");
                        nota1 = ConverterNota(Console.ReadLine());
                    } while (nota1 == -1);

                    double nota2;
                    do
                    {
                        Console.Write("Digite a segunda nota: ");
                        nota2 = ConverterNota(Console.ReadLine());
                    } while (nota2 == -1);

                    double nota3;
                    do
                    {
                        Console.Write("Digite a terceira nota: ");
                        nota3 = ConverterNota(Console.ReadLine());
                    } while (nota3 == -1);

                    double media = (nota1 + nota2 + nota3) / 3;

                    Console.WriteLine($"\nMédia de {nome}: {media}");

                    if (media >= 7)
                    {
                        aprovados++;
                        Console.WriteLine("Situação: Aprovado");
                    }
                    else if (media >= 5)
                    {
                        Console.WriteLine("Situação: Exame Final");
                    }
                    else
                    {
                        Console.WriteLine("Situação: Reprovado");
                    }
                    /*if (media < 5)
                    {
                        Console.WriteLine("Situação: Reprovado");
                    }
                    else if (media >= 5 && media < 7)
                    {
                        Console.WriteLine("Situação: Exame Final");
                    }
                    else
                    {
                        Console.WriteLine("Situação: Aprovado");
                    }*/
                    Console.WriteLine("Deseja Continuar? S/N");
                } while (Console.ReadLine().ToUpper() == "S");

                Console.WriteLine("\n=== Estatísticas da Turma ===");
                //int totalAlunos = 5;
                //int aprovados = 0;

                /*for (int i = 1; i <= totalAlunos; i++)
                {
                    if (i % 2 == 0)
                        aprovados++;
                }*/

                double percAprov = (aprovados / totalAlunos) * 100.0;
                Console.WriteLine($"Taxa de aprovação: {percAprov}%");

                Console.WriteLine("\nDeseja Continuar? S/N!");
            } while (Console.ReadLine().ToUpper() == "S");
        }

        public static bool ValidaNome(String nome)
        {
            string padrao = @"^(?!.*([A-Za-zÀ-ÖØ-öø-ÿ])\1\1)(?!.* {2,})(?=.{3,}).+$";

            if (Regex.IsMatch(nome, padrao))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Nome inválido! Verifique as regras:");
                Console.WriteLine("- Mínimo 3 caracteres");
                Console.WriteLine("- Não pode ter 3 letras iguais seguidas");
                Console.WriteLine("- Não pode ter mais de um espaço seguido");
                return false;
            }
        }

        public static double ConverterNota(String nota)
        {
            double notaRetorno = -1;
            string padrao = @"^(?:10(?:\.0+)?|[0-9](?:\.[0-9]+)?)$";
            try
            {
                if (!Regex.IsMatch(nota, padrao))
                {
                    throw new Exception("Valor Inválido");
                }
                notaRetorno = Convert.ToDouble(nota);

                /*if (Regex.IsMatch(nota, padrao))
                {
                    notaRetorno = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Valor Inválido. Informe um número de 0 a 10");                
                }*/

            }
            catch (Exception)
            {
                Console.WriteLine("Valor Inválido. Informe um número de 0 a 10");                
            }   
           
            return notaRetorno;
           
        }
    }
}
