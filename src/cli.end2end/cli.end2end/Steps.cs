using FluentAssertions;
using System;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace TodoApp.End2EndTests
{
    [Binding]
    public class Steps
    {
        private readonly ScenarioContext _context;
        private static readonly string _stdout = "Stdout";

        public Steps(ScenarioContext context) => _context = context;

        [Given(@"A file with testdata")]
        public static void GivenAFileWithTestdata()
            =>
            File.WriteAllText(@"c:\todo.json", "[{\"Id\":1,\"Title\":\"Dummy\",\"IsCompleted\":false}, {\"Id\":2,\"Title\":\"Dummy2\",\"IsCompleted\":false}]");

        [When(@"I start the CLI program with argument ""(.*)""")]
        public void WhenIStartTheCLIProgramWithArgument(string args)
            =>
            _context.Add(_stdout, SutRunner.Run(args));

        [Then(@"the following text shall be dropped on stdout")]
        public void ThenTheFollowingTextShallBeDroppedOnStdout(Table table)
            =>
            table.Rows.ToList().ForEach(row => _context.Get<string>(_stdout)
                                                       .Should()
                                                       .Be(row[_stdout].Replace("~NewLine~", Environment.NewLine)));

    }
}
