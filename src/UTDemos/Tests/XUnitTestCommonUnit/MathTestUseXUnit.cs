using System;
using UTDemos;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestCommonUnit
{
    public class MathTestUseXUnit : TestBase
    {
        public MathTestUseXUnit(ITestOutputHelper outputHelper) : base(outputHelper)
        {

        }

        //[Fact(DisplayName = "AddTestSuccess")]
        [Theory(DisplayName = "AddTestSuccess")]
        [InlineData(1, 2, 3)]
        public void AddTestSuccess(int a, int b, int expected)
        {
            var testValue = new MathExtension().Add(a, b);
            Output($"new MathExtension().Add({a}, {b})={testValue},expected is {expected}");
            Assert.True(expected == testValue, $"new MathExtension().Add({a}, {b})={testValue} 和预期值{expected} 不相等");
        }

        //[Fact(DisplayName = "AddTestFail")]
        [Theory(DisplayName = "AddTestFail")]
        [InlineData(1, 2, 4)]
        public void AddTestFail(int a, int b, int notExpected)
        {
            var testValue = new MathExtension().Add(a, b);
            Output($"new MathExtension().Add({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().Add({a}, {b})={testValue} 和预期值{notExpected} 相等");
        }

        //[Fact(DisplayName = "AddTestWithException")]
        [Theory(DisplayName = "AddTestWithException")]
        [InlineData(Int32.MaxValue, 1)]
        [InlineData(1, Int32.MaxValue)]
        [InlineData(-1, Int32.MinValue)]
        [InlineData(Int32.MinValue, -1)]
        public void AddTestWithException(int a, int b)
        {
            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Record.Exception(() => new MathExtension().Add(a, b));
            Assert.NotNull(abException);
            Assert.IsType<OverflowException>(abException);
            Output($"new MathExtension().Add({a}, {b}) handler error {abException.GetType()},{abException.Message}");
        }


        [Theory(DisplayName = "AddTestWithOutOfException")]
        [InlineData(10, 20)]
        public void AddTestWithOutOfException(int a, int b)
        {
            Output($"{a}+{b}={a + b}");
            var abException = Record.Exception(() => new MathExtension().Add(a, b));
            Assert.Null(abException);
        }

        // [Fact(DisplayName = "SubtractTestSuccess")]
        [Theory(DisplayName = "SubtractTestSuccess")]
        [InlineData(101, 1, 100)]
        public void SubtractTestSuccess(int minuend, int subtrahend, int expected)
        {
            var testValue = new MathExtension().Subtract(minuend, subtrahend);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.True(expected == testValue, $"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} 和预期值{expected} 不相等");
        }

        //[Fact(DisplayName = "SubtractTestFail")]
        [Theory(DisplayName = "SubtractTestFail")]
        [InlineData(101, 1, 102)]
        public void SubtractTestFail(int minuend, int subtrahend, int notExpected)
        {
            var testValue = new MathExtension().Subtract(minuend, subtrahend);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().Subtract({minuend}, {subtrahend})={testValue} 和预期值{notExpected} 相等");
        }

        //[Fact(DisplayName = "SubtractTestWithException")]
        [Theory(DisplayName = "SubtractTestWithException")]
        [InlineData(Int32.MinValue, 1)]
        [InlineData(-2, Int32.MaxValue)]
        [InlineData(0, Int32.MinValue)]
        public void SubtractTestWithException(int minuend, int subtrahend)
        {
            //int minuend = Int32.MinValue, subtrahend = 1;
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");//<Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Record.Exception(() => new MathExtension().Subtract(minuend, subtrahend));
            Assert.NotNull(abException);
            Assert.IsType<OverflowException>(abException);
            Output($"new MathExtension().Subtract({minuend}, {subtrahend}) handler error {abException.GetType()},{abException.Message}");

        }

        #region TestChecked

        [Theory(DisplayName = "AddWitchCheckedTestSuccess")]
        [InlineData(1, 2, 3)]
        public void AddWitchCheckedTestSuccess(int a, int b, int expected)
        {
            var testValue = new MathExtension().AddWitchChecked(a, b);
            Output($"new MathExtension().AddWitchChecked({a}, {b})={testValue},expected is {testValue}");
            Assert.True(expected == testValue, $"new MathExtension().AddWitchChecked({a}, {b})={testValue} 和预期值{expected} 不相等");
        }

        [Theory(DisplayName = "AddWitchChecTestNamekedTestSuccess")]
        [InlineData(1, 2, 4)]
        public void AddWitchCheckedTestFail(int a, int b, int notExpected)
        {
            var testValue = new MathExtension().AddWitchChecked(a, b);
            Output($"new MathExtension().AddWitchChecked({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().AddWitchChecked({a}, {b})={testValue} 和预期值{notExpected} 相等");
        }

        [Theory(DisplayName = "AddWitchCheckedTestWithException")]
        [InlineData(Int32.MaxValue, 1)]
        [InlineData(1, Int32.MaxValue)]
        [InlineData(Int32.MinValue, -1)]
        [InlineData(-1, Int32.MinValue)]
        public void AddWitchCheckedTestWithException(int a, int b)
        {
            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Record.Exception(() => new MathExtension().AddWitchChecked(a, b));
            Assert.NotNull(abException);
            Assert.IsType<OverflowException>(abException);
            Output($"new MathExtension().AddWitchChecked({a}, {b}) handler error {abException.GetType()},{abException.Message}");
        }

        [Theory(DisplayName = "SubtractWitchCheckedTestSuccess")]
        [InlineData(101, 1, 100)]
        public void SubtractWitchCheckedTestSuccess(int minuend, int subtrahend, int expected)
        {
            var testValue = new MathExtension().SubtractWitchChecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.True(expected == testValue, $"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue} 和预期值{expected} 不相等");
        }

        [Theory(DisplayName = "SubtractWitchCheckedTestFail")]
        [InlineData(101, 1, 102)]
        public void SubtractWitchCheckedTestFail(int minuend, int subtrahend, int notExpected)
        {
            var testValue = new MathExtension().SubtractWitchChecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend})={testValue} 和预期值{notExpected} 相等");
        }

        [Theory(DisplayName = "SubtractWitchCheckedTestWithException")]
        [InlineData(Int32.MinValue, 1)]  // < Int32.MinValue
        [InlineData(-2, Int32.MaxValue)] // < Int32.MinValue
        [InlineData(0, Int32.MinValue)]  // > Int32.MinValue
        public void SubtractWitchCheckedTestWithException(int minuend, int subtrahend)
        {
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");// <Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Record.Exception(() => new MathExtension().SubtractWitchChecked(minuend, subtrahend));
            Assert.NotNull(abException);
            Assert.IsType<OverflowException>(abException);

            Output($"new MathExtension().SubtractWitchChecked({minuend}, {subtrahend}) handler error {abException.GetType()},{abException.Message}");

        }

        #endregion //end TestChecked

        #region TestUnchecked

        [Theory(DisplayName = "AddWitchUncheckedTestSuccess")]
        [InlineData(1, 2, 3)]
        public void AddWitchUncheckedTestSuccess(int a, int b, int expected)
        {
            var testValue = new MathExtension().AddWitchUnchecked(a, b);
            Output($"new MathExtension().AddWitchUnchecked({a}, {b})={testValue},expected is {testValue}");
            Assert.True(expected == testValue, $"new MathExtension().AddWitchUnchecked({a}, {b})={testValue} 和预期值{expected} 不相等");
        }

        [Theory(DisplayName = "AddWitchUncheckedTestFail")]
        [InlineData(1, 2, 4)]
        public void AddWitchUncheckedTestFail(int a, int b, int notExpected)
        {
            var testValue = new MathExtension().AddWitchUnchecked(a, b);
            Output($"new MathExtension().AddWitchUnchecked({a}, {b})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().AddWitchUnchecked({a}, {b})={testValue} 和预期值{notExpected} 相等");
        }

        [Theory(DisplayName = "AddWitchUncheckedWithOutOfException")]
        [InlineData(Int32.MaxValue, 1)]
        [InlineData(1, Int32.MaxValue)]
        [InlineData(Int32.MinValue, -1)]
        [InlineData(-1, Int32.MinValue)]
        [InlineData(Int32.MaxValue, Int32.MaxValue)]
        public void AddWitchUncheckedWithOutOfException(int a, int b)
        {
            Output($"{a}+{b}={a + b}");
            var abRlt = Int32.TryParse((a + b).ToString(), out int ab);
            Output($"Int32.TryParse(({a} + {b}).ToString(),out int ab) uncheck result is {abRlt} ab = {ab}");
            var abException = Record.Exception(() => new MathExtension().AddWitchUnchecked(a, b));
            Assert.Null(abException);
        }

        [Theory(DisplayName = "SubtractWitchCheckedTestSuccess")]
        [InlineData(101, 1, 100)]
        public void SubtractWitchUncheckedTestSuccess(int minuend, int subtrahend, int expected)
        {
            var testValue = new MathExtension().SubtractWitchUnchecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchUnchecked({minuend}, {subtrahend})={testValue},expected is {testValue}");
            Assert.True(expected == testValue, $"new MathExtension().SubtractWitchUnchecked({minuend}, {subtrahend})={testValue} 和预期值{expected} 不相等");
        }

        [Theory(DisplayName = "SubtractWitchUncheckedTestFail")]
        [InlineData(101, 1, 102)]
        public void SubtractWitchUncheckedTestFail(int minuend, int subtrahend, int notExpected)
        {
            var testValue = new MathExtension().SubtractWitchUnchecked(minuend, subtrahend);
            Output($"new MathExtension().SubtractWitchUnchecked({minuend}, {subtrahend})={testValue},notExpected is {notExpected}");
            Assert.False(notExpected == testValue, $"new MathExtension().SubtractWitchUnchecked({minuend}, {subtrahend})={testValue} 和预期值{notExpected} 相等");
        }

        [Theory(DisplayName = "SubtractWitchUncheckedTestWithOutOfException")]
        [InlineData(Int32.MinValue, 1)]  // < Int32.MinValue
        [InlineData(-2, Int32.MaxValue)] // < Int32.MinValue
        [InlineData(0, Int32.MinValue)]  // > Int32.MinValue
        public void SubtractWitchUncheckedTestWithOutOfException(int minuend, int subtrahend)
        {
            Output($"{minuend}-{subtrahend}={minuend - subtrahend}");// <Int32.MinValue
            var abRlt = Int32.TryParse((minuend - subtrahend).ToString(), out int ab);
            Output($"Int32.TryParse(({minuend} - {subtrahend}).ToString(),out int ab) result is {abRlt} ab = {ab}");
            var abException = Record.Exception(() => new MathExtension().SubtractWitchUnchecked(minuend, subtrahend));
            Assert.Null(abException);
        }

        #endregion //end TestChecked
    }
}
