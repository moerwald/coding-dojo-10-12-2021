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
    public class ControllerTest
    {

        [Test]
        public void TestShowAllCommand()
        {
            Controller controller = new Controller(new FakeReader());

            List<Todo> result = controller.HandleCommand("ShowAll");
            result.Should().BeEquivalentTo(new List<Todo> { new Todo { Id = 1, IsCompleted = false, Title = "Dummy" } });
        }


    }

}
