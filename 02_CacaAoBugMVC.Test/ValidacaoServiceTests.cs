using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC.Test
{
    [TestClass]
    public class ValidacaoServiceTests
    {
        [TestMethod]
        public void ValidaNome_NomeValido_RetornaTrue()
        {
            //Arrange (Preparar)
            var service = new ValidacaoService();

            //Act (Agir)
            var resultado = service.ValidaNome("Pedro", out string mensagemErro);

            //Assert (Afirmar)
            Assert.IsTrue(resultado);
            Assert.AreEqual("", mensagemErro);
        }

        [TestMethod]
        public void NomeInvalido_RetornaFalse()
        {
            var service = new ValidacaoService();

            var resultado = service.ValidaNome("", out string mensagemErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void NomeComMenosDe3caracteres_RetronaFalse()
        {
            var service = new ValidacaoService();

            var resultado = service.ValidaNome("AAA", out string mensagemErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void NomeComEspacoDuplo_RetornaFalse()
        {
            var sevice = new ValidacaoService();

            var resultado = sevice.ValidaNome("  ", out string mensagemErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void NomeComCaracteresInvalidos_RetornaFalse()
        {
            var service = new ValidacaoService();

            var resultado = service.ValidaNome(" ", out string mensagemErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]

        public void NotaValida()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("7.5", out double msgErro);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NotaComVirgula()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("4,0", out double msgErro);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NotaComPonto()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("4.0", out double msgErro);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NotaForaDoIntervalo()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("12", out double msgErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TextoInvalido()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("abc", out double msgErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void CampoVazio()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("", out double msgErro);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void FromatoNumericoIncorreto()
        {
            var service = new ValidacaoService();

            var resultado = service.TentarConverterNota("-7", out double msgErro);

            Assert.IsFalse(resultado);
        }
    }
}

