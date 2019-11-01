# IntegrationTest 导航

[TOC]

## 一、包引用

### 1.1、Microsoft.AspNetCore.TestHost

```powershell
Install-Package Microsoft.AspNetCore.TestHost -Version x.x.x
或者
dotnet add package Microsoft.AspNetCore.TestHost --version x.x.x
或者
<PackageReference Include="Microsoft.AspNetCore.TestHost" Version="x.x.x" />
```

### 1.2、Microsoft.AspNetCore.App

```powershell
Install-Package Microsoft.AspNetCore.App -Version x.x.x
或者
dotnet add package Microsoft.AspNetCore.App --version x.x.x
或者
<PackageReference Include="Microsoft.AspNetCore.App" Version="x.x.x" />
```

## 二、TestServer 使用

### 2.1、TestBase （测试项目中）

```C#
    public class TestBase
    {
        protected readonly ITestOutputHelper OutputHelper;

        protected readonly HttpClient HttpClient;

        public TestBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            var service = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<TestStartup>()
            );
            HttpClient = service.CreateClient();
            //HttpClient.BaseAddress = new Uri("http://localhost:5000");
        }


        protected void Output(string message)
        {
            Console.WriteLine($"Console:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
            OutputHelper.WriteLine($"ITestOutputHelper:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
        }
    }
```

### 2.2、TestStartup （测试项目中）

```C#
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);
        }

    }

```

### 2.3、Startup (被测试项目中)

```C#
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IXXService, XXXService>();
            services.AddMvc()
                    .AddApplicationPart(typeof(Startup).Assembly)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
```

### 2.4、DemoController (被测试项目中)

```C#
    [Route("api/")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _demoService;
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpGet("demo/stringList", Name = "GetStringList")]
        public IEnumerable<string> GetStringList()
        {
            return _demoService.GetStringList();
        }
    }
```

## 三、IntegrationTest

### 3.1、demo

```C#
    public partial class DemoControllerTest : TestBase
    {
        public DemoControllerTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
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
    }
```

- Output
  ![GetStringListTestUseHttpClient_Output](http://lycfds.tcy365.com/Pic/Share/UTShare/GetStringListTestUseHttpClient_Output.png)
