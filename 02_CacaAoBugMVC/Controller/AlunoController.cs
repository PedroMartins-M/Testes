using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC.Controller
{
    public class AlunoController
    {

        private readonly AlunoService _alunoService;
        private readonly ValidacaoService _validacaoService;
        private readonly List<Aluno> _alunos;

        public AlunoController()
        {
            _alunoService = new AlunoService();
            _validacaoService = new ValidacaoService();
            _alunos = new List<Aluno>();
        }

        // tenta adicionar; retorna true se ok, e mensagem de erro se não
        public bool AdicionarAluno(Aluno aluno, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (!_validacaoService.ValidaNome(aluno.Nome, out string mNome))
            {
                mensagemErro = $"Nome inválido: {mNome}";
                return false;
            }

            // já assumimos que notas são válidas quando chegam ao Controller (view deve validar antes),
            // mas também podemos revalidar aqui se quiser
            aluno.Media = _alunoService.CalcularMedia(aluno.Nota1, aluno.Nota2, aluno.Nota3);
            aluno.Situacao = _alunoService.ObterSituacao(aluno.Media);

            _alunos.Add(aluno);
            return true;
        }

        public IReadOnlyList<Aluno> ObterAlunos() => _alunos.AsReadOnly();

        public double ObterTaxaAprovacao()
        {
            int total = _alunos.Count;
            int aprovados = _alunos.FindAll(a => a.Situacao == "Aprovado").Count;
            return _alunoService.CalcularTaxaAprovacao(total, aprovados);
        }

        public ValidacaoService GetValidacaoService() => _validacaoService;
    }
}

