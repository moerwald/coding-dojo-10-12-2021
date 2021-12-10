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
        private FakeWriter _fakeWriter;
        private Controller _controller;

        [SetUp]
        public void Setup()
        {
            _fakeWriter = new FakeWriter();
            _controller = new Controller(new FakeReader(), _fakeWriter);
        }

        [Test]
        public void TestShowAllCommand()
        {

            List<Todo> result = _controller.HandleCommand("ShowAll");
            result.Should().BeEquivalentTo(new List<Todo> { new Todo { Id = 1, IsCompleted = false, Title = "Dummy" } });
        }

        [Test]
        public void TestAddCommand()
        {
            List<Todo> result = _controller.HandleCommand("Add", "Dummy2");
            result.Should().BeEquivalentTo(
                new List<Todo> { new Todo { Id = 2 /* ID should be incremented */, IsCompleted = false, Title = "Dummy2" } });

            _fakeWriter.Called.Should().BeTrue();
            _fakeWriter.LstTodos.Should().BeEquivalentTo(
                new List<Todo>
                {
                    new Todo { Id = 1, IsCompleted = false, Title = "Dummy" },
                    new Todo { Id = 2, IsCompleted = false, Title = "Dummy2" }
                });
        }
    }
}
