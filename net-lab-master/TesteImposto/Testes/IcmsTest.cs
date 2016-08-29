using System;
using Imposto.Core.Domain.Imposto.ICMS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class IcmsTest
    {
        [TestMethod]
        public void TipoIcmsBrinde()
        {
            Assert.AreEqual("60", Icms.ObterTipoIcms(true, "SP", "RJ"));
        }

        [TestMethod]
        public void TipoIcmsEstadosIguais()
        {
            Assert.AreEqual("60", Icms.ObterTipoIcms(false, "SP", "SP"));
        }

        [TestMethod]
        public void TipoIcmsOutros()
        {
            Assert.AreEqual("10", Icms.ObterTipoIcms(false, "SP", "RJ"));
        }

        [TestMethod]
        public void AliquotaBrinde()
        {
            Assert.AreEqual(0.18, Icms.ObterAliquotaIcms(true, "SP", "RJ"));
        }

        [TestMethod]
        public void AliquotaEstadosIguais()
        {
            Assert.AreEqual(0.18, Icms.ObterAliquotaIcms(false, "SP", "SP"));
        }

        [TestMethod]
        public void AliquotaIcmsOutros()
        {
            Assert.AreEqual(0.17, Icms.ObterAliquotaIcms(false, "SP", "RJ"));
        }
        
        [TestMethod]
        public void BaseIcmsCfop()
        {
            Assert.AreEqual(90, Icms.CalcularBaseIcms("6.009", 100));
        }

        [TestMethod]
        public void BaseIcms()
        {
            Assert.AreEqual(100, Icms.CalcularBaseIcms(string.Empty, 100));
        }
    }
}