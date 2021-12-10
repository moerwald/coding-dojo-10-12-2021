using cli.Model;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace cli.test.UnitTest
{
    [TestFixture]
    public class TodoFormaterTest
    {
        List<Todo> _todoLst = new List<Todo>
            {
                new Todo { Id = 1, Title="Dummy", IsCompleted = false},
                new Todo { Id = 2, Title="Dummy2", IsCompleted = false}
            };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void FormatMultipleTodoEntries()
        {
            var todoFormater = new TodoFormater();
            var printableResult = todoFormater.Format(_todoLst);

            printableResult.Should().BeEquivalentTo(
                new List<string>
                {
                    "1 Dummy False",
                    "2 Dummy2 False"
                });
        }
    }
}
