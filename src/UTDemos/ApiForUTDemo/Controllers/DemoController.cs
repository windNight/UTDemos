using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiForUTDemo.Controllers
{
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


        [HttpGet("demo/returnInput", Name = "GetReturnInput")]
        public string ReturnInput(string input)
        {
            Debug.WriteLineIf(string.IsNullOrEmpty(input), $"param input can not be null . current input is {input}");
            return _demoService.ReturnInput(input);
        }

        [HttpGet("demo/testAttribute", Name = "TestAttribute")]
        [TestActionFilter]
        [Test2ActionFilter]
        public string TestAttribute()
        {
            return nameof(TestActionFilterAttribute);
        }


    }

    /// <summary> </summary>
    public sealed class TestActionFilterAttribute : ActionFilterAttribute
    {
        public TestActionFilterAttribute()
        {
            Order = 0;
        }

        void Log(string actionName)
        {
            Console.WriteLine($"【Console】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}     Enter {nameof(TestActionFilterAttribute)}-{actionName}");
            Trace.WriteLine($"【Trace】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  Enter {nameof(TestActionFilterAttribute)}-{actionName}");
        }

        //
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Log(nameof(OnActionExecuted));
            base.OnActionExecuted(context);
        }

        //
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log(nameof(OnActionExecuting));

            base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Log(nameof(OnActionExecutionAsync));
            return base.OnActionExecutionAsync(context, next);

        }

        //
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Log(nameof(OnResultExecuted));
            base.OnResultExecuted(context);
        }

        //
        public override void OnResultExecuting(ResultExecutingContext context)
        {

            Log(nameof(OnResultExecuting));
            base.OnResultExecuting(context);
        }

        //
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Log(nameof(OnResultExecutionAsync));
            return base.OnResultExecutionAsync(context, next);
        }


    }

    public sealed class Test2ActionFilterAttribute : ActionFilterAttribute
    {
        public Test2ActionFilterAttribute()
        {
            Order = 10;
        }

        void Log(string actionName)
        {
            Console.WriteLine($"【Console】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}     Enter {nameof(Test2ActionFilterAttribute)}-{actionName}");
            Trace.WriteLine($"【Trace】:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  Enter {nameof(Test2ActionFilterAttribute)}-{actionName}");
        }

        //
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Log(nameof(OnActionExecuted));
            base.OnActionExecuted(context);
        }

        //
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log(nameof(OnActionExecuting));

            base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Log(nameof(OnActionExecutionAsync));
            return base.OnActionExecutionAsync(context, next);

        }

        //
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Log(nameof(OnResultExecuted));
            base.OnResultExecuted(context);
        }

        //
        public override void OnResultExecuting(ResultExecutingContext context)
        {

            Log(nameof(OnResultExecuting));
            base.OnResultExecuting(context);
        }

        //
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Log(nameof(OnResultExecutionAsync));
            return base.OnResultExecutionAsync(context, next);
        }


    }

    public interface IDemoService
    {
        IEnumerable<string> GetStringList();
        string ReturnInput(string input);
    }

    public class DemoService : IDemoService
    {
        private readonly IDemoDomainService _demoDomain;
        public DemoService(IDemoDomainService demoDomain)
        {
            _demoDomain = demoDomain;
        }

        public IEnumerable<string> GetStringList()
        {
            return _demoDomain.GetStringList();
        }


        public string ReturnInput(string input)
        {
            return _demoDomain.ReturnInput(input);
        }
    }

    public interface IDemoDomainService
    {
        IEnumerable<string> GetStringList();
        string ReturnInput(string input);
    }

    public class DemoDomainService : IDemoDomainService
    {
        public IEnumerable<string> GetStringList()
        {
            return new[] { "value1", "value2" };
        }


        public string ReturnInput(string input)
        {
            return input;
        }
    }

}
