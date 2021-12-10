using cli.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cli.test.End2End
{
    [TestFixture]
    public partial class ReadDummyData
    {

        [SetUp]
        public void Setup()
        {
            File.WriteAllText(@"c:\todo.json", "[{\"Id\":1,\"Title\":\"Dummy\",\"IsCompleted\":false}, {\"Id\":2,\"Title\":\"Dummy2\",\"IsCompleted\":false}]");
        }

        [Test]
        public void ShowTodos()
        {
            new SutRunner().RunSut(string.Empty).Should().Be("1 Dummy false");
        }
    }
}
