using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace csharp
{
    [TestFixture]
    [UseReporter(typeof(NUnitReporter))]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();

            Console.SetIn(new StringReader("a\n"));
            Console.SetOut(new StringWriter(fakeoutput));

            Program.Main(new string[] { });

            var output = fakeoutput.ToString();
            Approvals.Verify(output);
        }
    }
}
