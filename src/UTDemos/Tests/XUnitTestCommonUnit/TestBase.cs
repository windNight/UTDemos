using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit.Abstractions;

namespace XUnitTestCommonUnit
{
    public class TestBase
    {
        protected readonly ITestOutputHelper OutputHelper;

        public TestBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        protected void Output(string message)
        {
            Console.WriteLine($"Console:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
            OutputHelper.WriteLine($"ITestOutputHelper:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
        }

    }
}
