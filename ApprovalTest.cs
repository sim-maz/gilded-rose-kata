using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using ApprovalTests;
using ApprovalTests.Reporters;
using System.Reflection;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "csharp.ApprovalTest.ThirtyDays.approved.txt";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            Console.SetIn(reader);
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Program.Main(new string[] { });

            var output = fakeoutput.ToString();
            Approvals.Verify(output);
        }
    }
}
