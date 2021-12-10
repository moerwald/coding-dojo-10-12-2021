using NUnit.Framework;

namespace cli.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFrameworkPass()
        {
            Program.Main(null);
            Assert.Pass();
        }

        [Test]
        [Ignore("Was just for env-setup tests ...")]
        public void TestFrameworkFail()
        {
            Assert.Fail();
        }
    }
}