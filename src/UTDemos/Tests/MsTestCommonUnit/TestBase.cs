using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestCommonUnit
{
    public class TestBase
    {
        protected void Output(string message)
        {
            Console.WriteLine($"Console:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
            Trace.WriteLine($"Trace:{DateTime.Now:yyyy-MM-dd HH:mm:sss}  {message}");
        }
    }

    public static class AssertEx
    {

        /// <summary>
        /// Verifies that a delegate does not throw an exception 
        /// </summary>
        /// <typeparam name="T">Type of exception expected not to be thrown.</typeparam>
        /// <param name="action">委托到要进行测试且预期不引发异常的代码</param>
        /// <exception cref=" AssertFailedException">Thrown if action throws exception of type T</exception>
        public static void DoesNotThrow<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                if (typeof(T) != typeof(Exception))
                    Assert.IsTrue(true);
            }

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception 
        /// </summary>
        /// <typeparam name="T">Type of exception expected not to be thrown.</typeparam>
        /// <param name="action">委托到要进行测试且预期不引发异常的代码</param>
        /// <param name="message">要包含在异常中的消息，条件是当action 引发类型的异常 T</param>
        /// <exception cref="AssertFailedException">Thrown if action throws exception of type T</exception>
        public static void DoesNotThrow<T>(Action action, string message) where T : Exception
        {
            try
            {
                action();
            }
            catch (T)
            {
                Assert.Fail(message);
            }
            catch (Exception)
            {
                if (typeof(T) != typeof(Exception))
                    Assert.IsTrue(true);
            }

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception 
        /// </summary>
        /// <typeparam name="T">Type of exception expected not to be thrown.</typeparam>
        /// <param name="func">委托到要进行测试且预期不引发异常的代码</param>
        /// <exception cref="AssertFailedException">Thrown if action throws exception of type T</exception>
        public static void DoesNotThrow<T>(Func<object> func) where T : Exception
        {
            try
            {
                func.Invoke();
            }
            catch (T)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                if (typeof(T) != typeof(Exception))
                    Assert.IsTrue(true);
            }

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception 
        /// </summary>
        /// <typeparam name="T">Type of exception expected not to be thrown.</typeparam>
        /// <param name="func">委托到要进行测试且预期将引发异常的代码</param>
        /// <param name="message">要包含在异常中的消息，条件是当action 引发类型的异常 T</param>
        /// <exception cref="AssertFailedException">Thrown if action throws exception of type T</exception>
        public static void DoesNotThrow<T>(Func<object> func, string message) where T : Exception
        {
            try
            {
                func.Invoke();
            }
            catch (T)
            {
                Assert.Fail(message);
            }
            catch (Exception)
            {
                if (typeof(T) != typeof(Exception))
                    Assert.IsTrue(true);
            }

            Assert.IsTrue(true);
        }

    }
}
