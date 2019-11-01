using System;
using System.Collections.Generic;
using System.Linq;
using ApiForUTDemo.Controllers;
using Xunit;
using Xunit.Abstractions;
using XUnitTestWebApi.Tools;

namespace XUnitTestWebApi
{


    public partial class DemoControllerTest3 : TestWebApiBase<TestStartup2>
    {
        public DemoControllerTest3(ITestOutputHelper outputHelper) : base(new TestFixture<TestStartup2>(), outputHelper)
        {

        }


        [Fact(DisplayName = "GetStringListTestUseHttpClient")]
        public void GetStringListTestUseHttpClient()
        {
            var expectedList = (new[] { "value1", "value2" }).ToList();

            var content = HttGet("/api/demo/stringList");
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
            var content = HttGet("/api/demo/returnInput", new { input = input });
            var output = content;
            Assert.Equal(expected, output);
            Output($"expected String is {expected} . Output String is {output} Assert.Pass");
        }

        [Fact(DisplayName = "TestAttributeTestUseHttpClient")]
        public void TestAttributeTestUseHttpClient()
        {
            var expected = nameof(TestActionFilterAttribute);
            var content = HttGet("/api/demo/testAttribute");
            Assert.Equal(expected, content);
            Output($"TestAttributeTestUseHttpClient expected={expected},output={content} Assert.Pass");

        }

    }




}
