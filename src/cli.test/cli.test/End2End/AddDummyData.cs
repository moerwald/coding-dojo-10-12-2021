using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static cli.test.End2End.ReadDummyData;

namespace cli.test.End2End
{
    [TestFixture]
    public class AddDummyData
    {
        [Test]
        public void ShowTodos()
        {
            SutRunner.Run("Add DummyEntry").Should().Be($"1 Dummy False{Environment.NewLine}");
        }
    }
}
