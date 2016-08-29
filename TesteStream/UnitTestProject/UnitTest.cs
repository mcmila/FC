using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteStream;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringStream stream = new StringStream("aAbBABacfe");
            Assert.AreEqual(ReadStream.firstChar(stream), 'e');
        }

        [TestMethod]
        public void TestMethod2()
        {
            StringStream stream = new StringStream("aAbBABacfeeou");
            Assert.AreEqual(ReadStream.firstChar(stream), 'o');
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            StringStream stream = new StringStream("aaaAAAeeeBBIou");
            Assert.AreEqual(ReadStream.firstChar(stream), 'I');
        }

        [TestMethod]
        public void TestMethod4()
        {
            StringStream stream = new StringStream("aBaaAAA");
            Assert.AreEqual(ReadStream.firstChar(stream), 'o');
        }
    }
}