using Imposto.Core.Domain;
using Imposto.Core.Domain.Imposto.Cfop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class CfopTest
    {
        [TestMethod]
        public void SaoPauloMinasGerais()
        {
            string cfop = new CalculaCfop().ObterCfop(new Pedido { EstadoOrigem = "SP", EstadoDestino = "MG" });
            Assert.AreEqual("6.002", cfop);
        }

        [TestMethod]
        public void AlagoasMinasGerais()
        {
            string cfop = new CalculaCfop().ObterCfop(new Pedido { EstadoOrigem = "AL", EstadoDestino = "MG" });
            Assert.AreEqual(string.Empty, cfop);
        }
    }
}