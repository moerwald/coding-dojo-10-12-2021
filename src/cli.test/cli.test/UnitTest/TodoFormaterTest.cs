using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TodoApp.Model;

namespace TodoApp.Tests.UnitTest
{
    [TestFixture]
    public class TodoFormaterTest
    {
        private readonly List<Todo> _todoLst = new() 
            {
                new Todo { Id = 1, Title="Dummy", IsCompleted = false},
                new Todo { Id = 2, Title="Dummy2", IsCompleted = false}
            };

        [Test]
        public void FormatMultipleTodoEntries()
            =>
            TodoFormater.Format(_todoLst).Should()
                                         .BeEquivalentTo(
                                            new List<string>
                                            {
                                                "1 Dummy False",
                                                "2 Dummy2 False"
                                            });
    }
}
