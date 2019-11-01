using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestWebApi
{
    public class TestWebApiBase<TStartup> : IClassFixture<TestFixture<TStartup>> where TStartup : class, IStartup
    {
        protected HttpClient HttpClient { get; }
        protected readonly ITestOutputHelper OutputHelper;
        public TestWebApiBase(TestFixture<TStartup> fixture, ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            var converter = new ConverterTool(OutputHelper);
            Console.SetOut(converter);

            HttpClient = fixture.HttpClient;
        }

        protected void Output(string message)
        {
            Console.WriteLine($"【Console】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
            OutputHelper.WriteLine($"【ITestOutputHelper】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
        }

        protected string HttGet(string apiPath, object queryBody = null)
        {
            var url = FormatUrl(apiPath, queryBody);
            var response = HttpClient.GetAsync(url).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Output($"{response.RequestMessage.RequestUri} response.Content is {content}");
            return content;
        }

        string FormatUrl(string url, object queryParams = null)
        {
            if (queryParams == null) return url;
            var queryJObject = JObject.FromObject(queryParams);
            var paramDict = new SortedDictionary<string, string>();
            foreach (var each in queryJObject)
                paramDict.Add(each.Key, each.Value.ToString());
            var paramList = paramDict.Select(m => $"{m.Key}={m.Value}").ToList();
            return $"{url}?{string.Join("&", paramList)}";
        }

    }

    public class TestWebApiBase : TestWebApiBase<TestStartup2>
    {

        public TestWebApiBase(ITestOutputHelper outputHelper) : base(new TestFixture<TestStartup2>(), outputHelper)
        {

        }

    }

    public class TestFixture<TStartup> : IClassFixture<TStartup>, IDisposable where TStartup : class, IStartup
    {
        public HttpClient HttpClient { get; }
        public TestServer TestServer { get; private set; }

        public TestFixture()
        {
            TestServer = NewTestServer();
            HttpClient = TestServer.CreateClient();
            //HttpClient.BaseAddress = new Uri("http://localhost:5000");
        }


        private static TestServer NewTestServer()
        {
            Console.WriteLine($"【Console】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  Use {typeof(TStartup).Name} to Build TestServer");
            return new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<TStartup>()
            );
        }


        public void Dispose()
        {
            //HttpClient?.Dispose();
            //TestServer?.Dispose();
        }
    }

    public class TestIocFixture<T> : IClassFixture<T> where T : class
    {
        private static readonly Lazy<T> ObjectInstance = new Lazy<T>(() => Ioc.GetService<T>());

        public T Object => ObjectInstance.Value;
        public TestIocFixture()
        {
        }
    }

}
