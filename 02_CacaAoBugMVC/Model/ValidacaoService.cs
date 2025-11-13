using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC.Model
{
    public class ValidacaoService
    {
        // valida nome: mínimo 3 caracteres, não ter 3 letras iguais seguidas, não ter duplo espaço
        private readonly string padraoNome = @"^(?!.*([A-Za-zÀ-ÖØ-öø-ÿ])\1\1)(?!.* {2,})(?=.{3,}).+$";

        // valida nota: 0..10, aceita decimais (ex: 7,5 or 7.5) - here we expect dot or comma convertible
        private readonly string padraoNota = @"^(?:10(?:[.,]0+)?|[0-9](?:[.,][0-9]+)?)$";

        public bool ValidaNome(string nome, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            if (string.IsNullOrWhiteSpace(nome))
            {
                mensagemErro = "Nome vazio.";
                return false;
            }

            if (Regex.IsMatch(nome.Trim(), padraoNome))
            {
                return true;
            }

            mensagemErro = "- Mínimo 3 caracteres\n- Não pode ter 3 letras iguais seguidas\n- Não pode ter espaços duplos";
            return false;
        }

        // tenta converter a entrada textual em double (aceita vírgula ou ponto)
        public bool TentarConverterNota(string entrada, out double nota)
        {
            nota = -1;
            if (string.IsNullOrWhiteSpace(entrada)) return false;

            var texto = entrada.Trim().Replace(',', '.'); // normaliza
            if (!Regex.IsMatch(texto, padraoNota)) return false;

            if (double.TryParse(texto, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out nota))
            {
                if (nota < 0 || nota > 10) return false;
                return true;
            }

            return false;
        }
    }
}
