using System;
using System.Collections.Generic;
using System.Linq;
using ApiForUTDemo.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using XUnitTestWebApi.Tools;

namespace XUnitTestWebApi
{
    public partial class DemoControllerTest : TestBase, IClassFixture<TestIocFixture<DemoController>>
    {
        private readonly DemoController demoController;
        public DemoControllerTest(TestIocFixture<DemoController> iocFixture, ITestOutputHelper outputHelper) : base(outputHelper)
        {
            demoController = iocFixture.Object;
            // demoController = Ioc.GetService<DemoController>();
        }

        [Fact(DisplayName = "TestSkip", Skip = "TestSkip")]
        public void TestSkip()
        {
            Assert.Equal(1, 2);
            Output($"Have Skip in Fact,this case will not be exec! ");
        }

        [Fact(DisplayName = "GetStringListTestUseIoc")]
        public void GetStringListTestUseIoc()
        {
            var expectedList = (new[] { "value1", "value2" }).ToList();
            var controller = Ioc.GetService<DemoController>();
            var stringList = controller.GetStringList().ToList();
            Assert.True(expectedList.Count == stringList.Count, $"GetStringList 返回list条数与预期不相等！{expectedList.Count}");
            Assert.Equal(expectedList, stringList);
            Output($"GetStringListTest Assert.Pass");
        }


        [Fact(DisplayName = "GetStringListTest")]
        public void GetStringListTest()
        {
            var expectedList = (new[] { "value1", "value2" }).ToList();

            // var demoController = Ioc.GetService<DemoController>();
            var stringList = demoController.GetStringList().ToList();
            Assert.True(expectedList.Count == stringList.Count, $"GetStringList 返回list条数与预期不相等！{expectedList.Count}");
            Assert.Equal(expectedList, stringList);
            Output($"GetStringListTest Assert.Pass");
        }

        [Theory(DisplayName = "ReturnInputTest")]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("asdasd")]
        [InlineData("{'a':'basdasd','b':1}")]
        public void ReturnInputTest(string input)
        {
            var expected = input;
            // var demoController = Ioc.GetService<DemoController>();
            var output = demoController.ReturnInput(input);
            Assert.Equal(expected, output);
            Output($"expected String is {expected} . Output String is {output} Assert.Pass");
        }


        [Fact(DisplayName = "GetStringListTestUseHttpClient")]
        public void GetStringListTestUseHttpClient()
        {
            var response = HttpClient.GetAsync("/api/demo/stringList").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Output($"{response.RequestMessage.RequestUri} response.Content is {content}");
            var outputList = content.To<List<string>>();
            var expectedList = (new[] { "value1", "value2" }).ToList();

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

            Output($"expected String is {expected} . Output String is {output} Assert.Pass");
        }

        [Fact(DisplayName = "TestAttributeTest")]
        public void TestAttributeTest()
        {
            var expected = nameof(TestActionFilterAttribute);
            //var demoController = Ioc.GetService<DemoController>();
            var output = demoController.TestAttribute();
            Assert.Equal(expected, output);

            Output($"TestAttributeTest Assert.Pass");
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
            Output($"TestAttributeTestUseHttpClient Assert.Pass");
        }

    }
}
