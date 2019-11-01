using System;
using System.Collections.Generic;
using System.Linq;
using ApiForUTDemo.Controllers;
using Xunit;
using Xunit.Abstractions;
using XUnitTestWebApi.Tools;

namespace XUnitTestWebApi
{

    public partial class DemoControllerTest2 : TestWebApiBase
    {
        public DemoControllerTest2(ITestOutputHelper outputHelper) : base(outputHelper)
        {

        }

        [Fact(DisplayName = "GetStringListTestUseHttpClient")]
        public void GetStringListTestUseHttpClient()
        {
            var expectedList = (new[] { "value1", "value2" }).ToList();

            var response = HttpClient.GetAsync("/api/demo/stringList").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Output($"{response.RequestMessage.RequestUri} response.Content is {content}");

            var outputList = content.To<List<string>>();

            Assert.True(expectedList.Count == outputList?.Count, $"api/demo/stringList 返回list条数与预期不相等！{expectedList.Count}");
            Assert.Equal(expectedList, outputList);
            Output($"GetStringListTestUseHttpClient Assert.Pass");
        }

        [Theory(DisplayName = "ReturnInputTestUseHttpClient")]
        [InlineData("1")]
        [InlineData("asdasd")]
        [InlineData("{'a':'basdasd','b':1}")]
        public void ReturnInputTestUseHttpClient(string input)
        {
            var expected = input;
            var response = HttpClient.GetAsync($"/api/demo/returnInput?input={input}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Output($"{response.RequestMessage.RequestUri} response.Content is {content}");
            var output = content;
            Assert.Equal(expected, output);
            Output($"ReturnInputTestUseHttpClient Expected={expected}, Output ={output} . Assert.Pass");
        }

        [Fact(DisplayName = "TestAttributeTestUseHttpClient")]
        public void TestAttributeTestUseHttpClient()
        {
            var expected = nameof(TestActionFilterAttribute);

            var response = HttpClient.GetAsync($"/api/demo/testAttribute").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Output($"{response.RequestMessage.RequestUri} response.Content is {content}");
            var output = content;
            Assert.Equal(expected, output);
            Output($"TestAttributeTestUseHttpClient expected={expected},output={output} . Assert.Pass");

        }

    }






}
