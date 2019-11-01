using System;

namespace UTDemos
{
    public class MathExtension
    {
        public Int32 Add(Int32 t1, Int32 t2)
        {
            // tip: 判断并不严谨
            if ((t1 == Int32.MaxValue && t2 > 0) || (t2 == Int32.MaxValue && t1 > 0))
            {
                throw new OverflowException(
                    $"Sum of two numbers({t1},{t2}) can not greater than System.Int32.MaxValue({Int32.MaxValue}).");
            }

            // tip: 判断并不严谨
            if ((t1 == Int32.MinValue && t2 < 0) || (t2 == Int32.MinValue && t1 < 0))
            {
                throw new OverflowException(
                    $"Sum of two numbers({t1},{t2}) can not less than System.Int32.MinValue({Int32.MinValue}).");
            }

            return t1 + t2;
        }


        public Int32 Subtract(Int32 minuend, Int32 subtrahend)
        {
            // tip: 判断并不严谨
            if ((minuend == Int32.MinValue && subtrahend > 0) || (subtrahend == Int32.MaxValue && minuend < -1))
            {
                throw new OverflowException($"Difference between two numbers(minuend:{minuend},subtrahend:{subtrahend}) can not less than System.Int32.MinValue({Int32.MinValue}).");
            }

            // tip: 判断并不严谨
            if ((subtrahend == Int32.MinValue && minuend > -1))
            {
                throw new OverflowException($"Difference between two numbers(minuend:{minuend},subtrahend:{subtrahend}) can not greater than System.Int32.MaxValue({Int32.MaxValue}).");
            }

            return minuend - subtrahend;
        }

        #region Checked

        public Int32 AddWitchChecked(Int32 t1, Int32 t2)
        {
            checked
            {
                return t1 + t2;
            }
        }


        public Int32 SubtractWitchChecked(Int32 minuend, Int32 subtrahend)
        {
            checked
            {
                return minuend - subtrahend;
            }
        }

        #endregion //end Checked

        #region Unchecked

        public Int32 AddWitchUnchecked(Int32 t1, Int32 t2)
        {
            unchecked
            {
                return t1 + t2;
            }
        }

        public Int32 SubtractWitchUnchecked(Int32 minuend, Int32 subtrahend)
        {
            unchecked
            {
                return minuend - subtrahend;
            }
        }

        #endregion //end Unchecked


    }
}
