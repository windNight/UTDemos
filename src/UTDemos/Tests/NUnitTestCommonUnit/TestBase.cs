using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace NUnitTestCommonUnit
{
    public class TestBase
    {
        protected void Output(string message)
        {
            Console.WriteLine($"Console:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
            TestContext.WriteLine($"TestContext:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
        }
    }
}
