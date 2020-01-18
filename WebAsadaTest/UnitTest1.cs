using NUnit.Framework;
using WebAsada.Models;

namespace WebAsadaTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Verify_Password_Complexity()
        {
            var p = Password.Create("AsadaCv123+");

            var u = UserName.Create("Administrator");

            Assert.AreEqual(true, p.IsSuccess);
            Assert.AreEqual(true, u.IsSuccess);
        }
    }
}