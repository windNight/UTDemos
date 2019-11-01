using System; 
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit.Abstractions;

namespace XUnitTestWebApi
{
    public class TestBase
    {
        protected readonly ITestOutputHelper OutputHelper;

        protected readonly HttpClient HttpClient;


        public TestBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        

            var service = NewTestServer();
            HttpClient = service.CreateClient();
            //HttpClient.BaseAddress = new Uri("http://localhost:5000");

            var converter = new ConverterTool(OutputHelper);
            Console.SetOut(converter);

        }
        private TestServer NewTestServer()
        {
            Console.WriteLine($"【Console】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  Use {typeof(TestStartup).Name} to Build TestServer");
            return new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<TestStartup>()
            );
        }



        protected void Output(string message)
        {
            Console.WriteLine($"【Console】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
            OutputHelper.WriteLine($"【ITestOutputHelper】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
        }
    }

    internal class ConverterTool : TextWriter
    {
        ITestOutputHelper _output;
        public ConverterTool(ITestOutputHelper output)
        {
            _output = output;
        }
        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string message)
        {
            _output?.WriteLine(message);
        }
        public override void WriteLine(string format, params object[] args)
        {
            _output?.WriteLine(format, args);
        }
    }
}
