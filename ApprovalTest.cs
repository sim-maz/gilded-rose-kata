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

        //[Test]
        //public void ThirtyDays()
        //{
        //    StringBuilder fakeoutput = new StringBuilder();
        //    var fileStream = new FileStream("F:/Code/gilded-rose-kata/ApprovalTest.ThirtyDays.approved.txt", FileMode.Open);

        //    using (var streamReader = new StreamReader(fileStream))
        //    {
        //        Console.SetIn(streamReader);

        //        Console.SetOut(new StringWriter(fakeoutput));
        //        Program.Main(new string[] { });
        //    }

        //    var output = fakeoutput.ToString();
        //    Approvals.Verify(output);
        //}
    }
}
