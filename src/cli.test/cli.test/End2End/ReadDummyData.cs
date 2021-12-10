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
            var todo = new Todo() { Id = 1, Title = "Dummy", IsCompleted = false };
            File.WriteAllText(@"c:\todo.json", JsonConvert.SerializeObject(todo));
        }

        [Test]
        public void ShowTodos()
        {
            new SutRunner().RunSut(string.Empty).Should().Be("1 Dummy false");
        }
    }
}
