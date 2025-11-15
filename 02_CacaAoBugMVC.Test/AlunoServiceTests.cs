
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC.Test
{
    [TestClass]
    public class AlunoServiceTests
    {
        [TestMethod]
        public void CalcularMedia_DeveRetornarCorreto()
        {
            //Arrange (Preparar)
            var service = new AlunoService();

            //Act (Agir)
            var resultado = service.CalcularMedia(8.0, 7.5, 6.5);

            //Assert (Afirmar)
            Assert.AreEqual(7.33, Math.Round(resultado,2));
        }

        [TestMethod]
        public void ObterSituacao_DeveRetornarErro()
        {
            var service = new AlunoService();

            var resultado = service.ObterSituacao(6.0);

            Assert.AreNotEqual("Aprovado", resultado);
        }

        [TestMethod]
        public void ObterSituacao_DeveRetornarCorreto()
        {
            var service = new AlunoService();

            var resultado = service.ObterSituacao(7.0);
            var resultadoEmExame = service.ObterSituacao(6.5);
            var resultadoReprovado = service.ObterSituacao(4.9);

            Assert.AreEqual("Aprovado", resultado);
            Assert.AreEqual("Exame Final", resultadoEmExame);
            Assert.AreEqual("Reprovado", resultadoReprovado);
        }

    }
}
