using System;
using Imposto.Core.Domain.Imposto.IPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class IpiTest
    {
        [TestMethod]
        public void AliquotaIpiBrinde()
        {
            Assert.AreEqual(0, Ipi.CalculaAliquotaIpi(true));
        }

        [TestMethod]
        public void AliquotaIpiNaoBrinde()
        {
            Assert.AreEqual(0.1, Ipi.CalculaAliquotaIpi(false));
        }
        
        [TestMethod]
        public void ValorIpiBrinde()
        {
            Assert.AreEqual(0, Ipi.CalculaValorIpi(100, Ipi.CalculaAliquotaIpi(true)));
        }

        [TestMethod]
        public void ValorIpiNaoBrinde()
        {
            Assert.AreEqual(10, Ipi.CalculaValorIpi(100, Ipi.CalculaAliquotaIpi(false)));
        }
    }
}