using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTDemos;

namespace MsTestCommonUnit
{
    [TestClass]
    public class MathTestUseMsTest : TestBase
    {
        [TestMethod]
        public void AddTestSuccess()
        {
            int a = 1, b = 2, expected = 3;
            var testValue = new MathExtension().Add(a, b);
            Output($"new MathExtension().Add({a}, {b})={testValue},expected is {expected}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().Add({a}, {b})={testValue} 和预期值{expected} 不相等");
        }

        [TestMethod]
        public void AddTestFail()
        {
            int a = 1, b = 2, notExpected = 4;
            var testValue = new MathExtension().Add(a, b);
            Output($"new MathExtension().Add({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().Add({a}, {b})={testValue} 和预期值{notExpected} 相等");
        }

        [TestMethod]
        public void AddTestWithException()
        {
            int a = Int32.MaxValue, b = 1;

            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.ThrowsException<OverflowException>(() => new MathExtension().Add(a, b), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Add({a}, {b}) handler error {abException.GetType()},{abException.Message}");

            int a1 = 1, b1 = Int32.MaxValue;
            Output($"{a1}+{b1}={a1 + b1}");
            var a1b1Rlt = Int32.TryParse((a1 + b1).ToString(), out int a1b1);
            Output($"Int32.TryParse(({a1} + {b1}).ToString(),out int a1b1) result is {a1b1Rlt} a1b1 = {a1b1}");
            var a1b1Exception = Assert.ThrowsException<OverflowException>(() => new MathExtension().Add(a1, b1), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Add({a1}, {b1}) handler error {a1b1Exception.GetType()},{a1b1Exception.Message}");
             
            int c = Int32.MinValue, d = -1;
            Output($"{c}+{d}={c + d}");
            var cdRlt = Int32.TryParse((c + d).ToString(), out int cd);
            Output($"Int32.TryParse(({c} + {d}).ToString(),out int cd) result is {cdRlt} cd = {cd}");
            var cdException = Assert.ThrowsException<OverflowException>(() => new MathExtension().Add(c, d), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Add({c}, {d}) handler error {cdException.GetType()},{cdException.Message}");

            int c1 = -1, d1 = Int32.MinValue;
            Output($"{c1}+{d1}={c1 + d1}");
            var c1d1Rlt = Int32.TryParse((c1 + d1).ToString(), out int c1d1);
            Output($"Int32.TryParse(({c1} + {d1}).ToString(),out int c1d1) result is {c1d1Rlt} c1d1 = {c1d1}");
            var c1d1Exception = Assert.ThrowsException<OverflowException>(() => new MathExtension().Add(c1, d1), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Add({c1}, {d1}) handler error {c1d1Exception.GetType()},{c1d1Exception.Message}");
        }

        [TestMethod]
        public void AddTestWithOutOfException()
        {
            int a = 10, b = 20;
            Output($"{a}+{b}={a + b}"); 
            AssertEx.DoesNotThrow<Exception>(() => new MathExtension().Add(a, b), $"new MathExtension().Add({ a}, { b}), handler error");// ex=null

        }

        [TestMethod]
        public void SubtractTestSuccess()
        {
            int minuend = 101, subtrahend = 1, expected = 100;
            var testValue = new MathExtension().Subtract(minuend, subtrahend);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} 和预期值{expected} 不相等");
        }

        [TestMethod]
        public void SubtractTestFail()
        {
            int minuend = 101, subtrahend = 1, notExpected = 102;
            var testValue = new MathExtension().Subtract(minuend, subtrahend);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} 和预期值{notExpected} 相等");
        }

        [TestMethod]
        public void SubtractTestWithException()
        {
            int minuend = Int32.MinValue, subtrahend = 1;
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");// <Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.ThrowsException<OverflowException>(() => new MathExtension().Subtract(minuend, subtrahend), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Subtract({minuend}, {subtrahend}) handler error {abException.GetType()},{abException.Message}");

            int minuend1 = -2, subtrahend1 = Int32.MaxValue;// <Int32.MinValue
            Output($"{minuend1}-{subtrahend1}={minuend1 - subtrahend1}");
            var cdRlt = Int32.TryParse((minuend1 - subtrahend1).ToString(), out int cd);
            Output($"Int32.TryParse(({minuend1} - {subtrahend1}).ToString(),out int cd) result is {cdRlt} cd = {cd}");
            var cdException = Assert.ThrowsException<OverflowException>(() => new MathExtension().Subtract(minuend1, subtrahend1), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Subtract({minuend1}, {subtrahend1}) handler error {cdException.GetType()},{cdException.Message}");

            int minuend2 = 0, subtrahend2 = Int32.MinValue;
            Output($"{minuend2}-{subtrahend2}={minuend2 - subtrahend2}");// > Int32.MaxValue
            var efRlt = Int32.TryParse((minuend2 - subtrahend2).ToString(), out int ef);
            Output($"Int32.TryParse(({minuend2} - {subtrahend2}).ToString(),out int ef) result is {efRlt} ef = {ef}");
            var efException = Assert.ThrowsException<OverflowException>(() => new MathExtension().Subtract(minuend2, subtrahend2), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().Subtract({minuend2}, {subtrahend2}) handler error {efException.GetType()},{efException.Message}");

        }


        #region TestChecked

        [TestMethod]
        public void AddWitchCheckedTestSuccess()
        {
            int a = 1, b = 2, expected = 3;
            var testValue = new MathExtension().AddWitchChecked(a, b);
            Output($"new MathExtension().AddWitchChecked({a}, {b})={testValue},expected is {testValue}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().AddWitchChecked({a}, {b})={testValue} 和预期值{expected} 不相等");
        }

        [TestMethod]
        public void AddWitchCheckedTestFail()
        {
            int a = 1, b = 2, notExpected = 4;
            var testValue = new MathExtension().AddWitchChecked(a, b);
            Output($"new MathExtension().AddWitchChecked({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().AddWitchChecked({a}, {b})={testValue} 和预期值{notExpected} 相等");
        }

        [TestMethod]
        public void AddWitchCheckedTestWithException()
        {
            int a = Int32.MaxValue, b = 1;

            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.ThrowsException<OverflowException>(() => new MathExtension().AddWitchChecked(a, b), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().AddWitchChecked({a}, {b}) handler error {abException.GetType()},{abException.Message}");

            int a1 = 1, b1 = Int32.MaxValue;
            Output($"{a1}+{b1}={a1 + b1}");
            var a1b1Rlt = Int32.TryParse((a1 + b1).ToString(), out int a1b1);
            Output($"Int32.TryParse(({a1} + {b1}).ToString(),out int a1b1) result is {a1b1Rlt} a1b1 = {a1b1}");
            var a1b1Exception = Assert.ThrowsException<OverflowException>(() => new MathExtension().AddWitchChecked(a1, b1), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().AddWitchChecked({a1}, {b1}) handler error {a1b1Exception.GetType()},{a1b1Exception.Message}");


            int c = Int32.MinValue, d = -1;
            Output($"{c}+{d}={c + d}");
            var cdRlt = Int32.TryParse((c + d).ToString(), out int cd);
            Output($"Int32.TryParse(({c} + {d}).ToString(),out int cd) result is {cdRlt} cd = {cd}");
            var cdException = Assert.ThrowsException<OverflowException>(() => new MathExtension().AddWitchChecked(c, d), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().AddWitchChecked({c}, {d}) handler error {cdException.GetType()},{cdException.Message}");

            int c1 = -1, d1 = Int32.MinValue;
            Output($"{c1}+{d1}={c1 + d1}");
            var c1d1Rlt = Int32.TryParse((c1 + d1).ToString(), out int c1d1);
            Output($"Int32.TryParse(({c1} + {d1}).ToString(),out int c1d1) result is {c1d1Rlt} c1d1 = {c1d1}");
            var c1d1Exception = Assert.ThrowsException<OverflowException>(() => new MathExtension().AddWitchChecked(c1, d1), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().AddWitchChecked({c1}, {d1}) handler error {c1d1Exception.GetType()},{c1d1Exception.Message}");

        }

        [TestMethod]
        public void SubtractWitchCheckedTestSuccess()
        {
            int minuend = 101, subtrahend = 1, expected = 100;
            var testValue = new MathExtension().SubtractWitchChecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue} 和预期值{expected} 不相等");
        }

        [TestMethod]
        public void SubtractWitchCheckedTestFail()
        {
            int minuend = 101, subtrahend = 1, notExpected = 102;
            var testValue = new MathExtension().SubtractWitchChecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue} 和预期值{notExpected} 相等");
        }

        [TestMethod]
        public void SubtractWitchCheckedTestWithException()
        {
            int minuend = Int32.MinValue, subtrahend = 1;
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");// <Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.ThrowsException<OverflowException>(() => new MathExtension().SubtractWitchChecked(minuend, subtrahend), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend}) handler error {abException.GetType()},{abException.Message}");

            int minuend1 = -2, subtrahend1 = Int32.MaxValue;// <Int32.MinValue
            Output($"{minuend1}-{subtrahend1}={minuend1 - subtrahend1}");
            var cdRlt = Int32.TryParse((minuend1 - subtrahend1).ToString(), out int cd);
            Output($"Int32.TryParse(({minuend1} - {subtrahend1}).ToString(),out int cd) result is {cdRlt} cd = {cd}");
            var cdException = Assert.ThrowsException<OverflowException>(() => new MathExtension().SubtractWitchChecked(minuend1, subtrahend1), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().SubtractWitchChecked({minuend1}, {subtrahend1}) handler error {cdException.GetType()},{cdException.Message}");

            int minuend2 = 0, subtrahend2 = Int32.MinValue;
            Output($"{minuend2}-{subtrahend2}={minuend2 - subtrahend2}");// > Int32.MaxValue
            var efRlt = Int32.TryParse((minuend2 - subtrahend2).ToString(), out int ef);
            Output($"Int32.TryParse(({minuend2} - {subtrahend2}).ToString(),out int ef) result is {efRlt} ef = {ef}");
            var efException = Assert.ThrowsException<OverflowException>(() => new MathExtension().SubtractWitchChecked(minuend2, subtrahend2), "未能捕获预期异常OverflowException");
            Output($"new MathExtension().SubtractWitchChecked({minuend2}, {subtrahend2}) handler error {efException.GetType()},{efException.Message}");

        }


        #endregion //end TestChecked

    }
}
