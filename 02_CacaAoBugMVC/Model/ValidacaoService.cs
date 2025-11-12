using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC.Model
{
    internal class ValidacaoService
    {
        //Padrão:
        //- minimo de 3 caracteres
        //- não pode ter 3 letras repetidas
        //- não permititr multiplo espaço
       private readonly string padraoNome = @"^(?!.*([A-Za-zÀ-ÖØ-öø-ÿ])\1\1)(?!.* {2,})(?=.{3,}).+$";
       private readonly string padraoNota = @"^(?:10(?:[.,]0+)?|[0-9](?:[.,][0-9]+)?)$";

        //padrão
        //- valida nota 0 a 10
        //- Aceita deciamais, aceitando ponto(.) ou virgula(,) como separar de decimal

        public bool ValidarNome(string nome, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            if (string.IsNullOrEmpty(nome))
            {
                mensagemErro = "Nome vazio";
                return false;
            }

            if (!Regex.IsMatch(nome.Trim(), padraoNome))
            {
                mensagemErro = "-Minimo 3 caracteres\nNão pode ter 3 letras iguais seguidas\n Não pode ter espaços multiplos";
                return false;
            }

            return true;
        }

        public bool ConverteNota(string notaEntrada, out double nota)
        {
            nota = -1;
            if( string.IsNullOrEmpty(notaEntrada) ) return false; 

            var notaDecimalVirgula = notaEntrada.Trim().Replace(",",".");

            if (Regex.IsMatch(notaDecimalVirgula, padraoNome)) return false;

            if (double.TryParse(notaDecimalVirgula, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out nota))
            {
                if(nota < 0 || nota > 10) 
                return false;
                else
                    return true;
            }
            return false;
        }
    }
}
