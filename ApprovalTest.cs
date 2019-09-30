using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Program.Main(new string[] { });

            var output = fakeoutput.ToString();
            Approvals.Verify(output);
        }
    }
}
