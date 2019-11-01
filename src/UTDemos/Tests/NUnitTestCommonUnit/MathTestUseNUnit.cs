using System;
using NUnit.Framework;
using UTDemos;

namespace NUnitTestCommonUnit
{
    public class MathTestUseNUnit : TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        [TestCase(1, 2, 3, TestName = "AddTestSuccess")]
        public void AddTestSuccess(int a, int b, int expected)
        {
            var testValue = new MathExtension().Add(a, b);
            Output($"new MathExtension().Add({a}, {b})={testValue},expected is {expected}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().Add({a}, {b})={testValue} ��Ԥ��ֵ{expected} �����");
            Assert.Pass($"new MathExtension().Add({a}, {b})={testValue} ��Ԥ��ֵ{expected} ���");
        }

        //[Test]
        [TestCase(1, 2, 4, TestName = "AddTestFail")]
        public void AddTestFail(int a, int b, int notExpected)
        {
            var testValue = new MathExtension().Add(a, b);
            Output($"new MathExtension().Add({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().Add({a}, {b})={testValue} ��Ԥ��ֵ{notExpected} ���");
            Assert.Pass($"new MathExtension().Add({a}, {b})={testValue} ��Ԥ��ֵ{notExpected} �����");
        }

        // [Test]
        [TestCase(10, 20, 30, TestName = "AddTestWithOutOfException")]
        public void AddTestWithOutOfException(int a, int b, int expected)
        {
            Output($"{a}+{b}={a + b}");
            Assert.DoesNotThrow(() => new MathExtension().Add(a, b), $"new MathExtension().Add({a}, {b}), handler error  ");
            Assert.Pass($"new MathExtension().Add({a}, {b}),no Exceptions ");
        }


        // [Test]
        [TestCase(Int32.MaxValue, 1, TestName = "AddTestWithException")]
        [TestCase(1, Int32.MaxValue, TestName = "AddTestWithException")]
        [TestCase(Int32.MinValue, -1, TestName = "AddTestWithException")]
        [TestCase(-1, Int32.MinValue, TestName = "AddTestWithException")]
        public void AddTestWithException(int a, int b)
        {
            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.Throws<OverflowException>(() => new MathExtension().Add(a, b), "δ�ܲ���Ԥ���쳣OverflowException");
            Output($"new MathExtension().Add({a}, {b}) handler error {abException.GetType()},{abException.Message}");
            Assert.Pass($"new MathExtension().Add({a}, {b}), handler error {abException.GetType()},{abException.Message}");
        }

        //[Test]
        [TestCase(101, 1, 100, TestName = "SubtractTestSuccess")]
        public void SubtractTestSuccess(int minuend, int subtrahend, int expected)
        {
            var testValue = new MathExtension().Subtract(minuend, subtrahend);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} ��Ԥ��ֵ{expected} �����");
            Assert.Pass($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} ��Ԥ��ֵ{expected} ���");

        }

        //[Test]
        [TestCase(101, 1, 102, TestName = "SubtractTestFail")]
        public void SubtractTestFail(int minuend, int subtrahend, int notExpected)
        {
            var testValue = new MathExtension().Subtract(minuend, subtrahend);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} ��Ԥ��ֵ{notExpected} ���");
            Assert.Pass($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} ��Ԥ��ֵ{notExpected} �����");
        }

        //[Test]

        [TestCase(Int32.MinValue, 1, TestName = "SubtractTestWithException")]  // < Int32.MinValue
        [TestCase(-2, Int32.MaxValue, TestName = "SubtractTestWithException")] // < Int32.MinValue
        [TestCase(0, Int32.MinValue, TestName = "SubtractTestWithException")]  // > Int32.MinValue
        public void SubtractTestWithException(int minuend, int subtrahend)
        {
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");//<Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.Throws<OverflowException>(() => new MathExtension().Subtract(minuend, subtrahend), "δ�ܲ���Ԥ���쳣OverflowException");
            var exOutput = $"new MathExtension().Subtract({minuend}, {subtrahend}) handler error {abException.GetType()},{abException.Message}";
            Output(exOutput);
            Assert.Pass(exOutput);
        }



        #region TestChecked

        [TestCase(1, 2, 3, TestName = "AddWitchCheckedTestSuccess")]
        public void AddWitchCheckedTestSuccess(int a, int b, int expected)
        {
            var testValue = new MathExtension().AddWitchChecked(a, b);
            Output($"new MathExtension().AddWitchChecked({a}, {b})={testValue},expected is {testValue}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().AddWitchChecked({a}, {b})={testValue} ��Ԥ��ֵ{expected} �����");
        }

        [TestCase(1, 2, 4, TestName = "AddWitchCheckedTestFail")]
        public void AddWitchCheckedTestFail(int a, int b, int notExpected)
        {
            var testValue = new MathExtension().AddWitchChecked(a, b);
            Output($"new MathExtension().AddWitchChecked({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().AddWitchChecked({a}, {b})={testValue} ��Ԥ��ֵ{notExpected} ���");
        }

        [TestCase(Int32.MaxValue, 1, TestName = "AddWitchCheckedTestWithException")]
        [TestCase(1, Int32.MaxValue, TestName = "AddWitchCheckedTestWithException")]
        [TestCase(Int32.MinValue, -1, TestName = "AddWitchCheckedTestWithException")]
        [TestCase(-1, Int32.MinValue, TestName = "AddWitchCheckedTestWithException")]
        public void AddWitchCheckedTestWithException(int a, int b)
        {
            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.Throws<OverflowException>(() => new MathExtension().AddWitchChecked(a, b), "δ�ܲ���Ԥ���쳣OverflowException");
            Output($"new MathExtension().AddWitchChecked({a}, {b}) handler error {abException.GetType()},{abException.Message}");
        }

        [TestCase(101, 1, 100, TestName = "SubtractWitchCheckedTestSuccess")]
        public void SubtractWitchCheckedTestSuccess(int minuend, int subtrahend, int expected)
        {
            var testValue = new MathExtension().SubtractWitchChecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.AreEqual(expected, testValue, $"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue} ��Ԥ��ֵ{expected} �����");
        }

        [TestCase(101, 1, 102, TestName = "SubtractWitchCheckedTestFail", Category = "SubtractTest")]
        public void SubtractWitchCheckedTestFail(int minuend, int subtrahend, int notExpected)
        {
            var testValue = new MathExtension().SubtractWitchChecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.AreNotEqual(notExpected, testValue, $"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue} ��Ԥ��ֵ{notExpected} ���");
        }

        [TestCase(Int32.MinValue, 1, TestName = "SubtractWitchCheckedTestWithException")]  // < Int32.MinValue
        [TestCase(-2, Int32.MaxValue, TestName = "SubtractWitchCheckedTestWithException")] // < Int32.MinValue
        [TestCase(0, Int32.MinValue, TestName = "SubtractWitchCheckedTestWithException")]  // > Int32.MinValue
        public void SubtractWitchCheckedTestWithException(int minuend, int subtrahend)
        {
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");// <Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Assert.Throws<OverflowException>(() => new MathExtension().SubtractWitchChecked(minuend, subtrahend), "δ�ܲ���Ԥ���쳣OverflowException");
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend}) handler error {abException.GetType()},{abException.Message}");
        }

        #endregion //end TestChecked

    }
}