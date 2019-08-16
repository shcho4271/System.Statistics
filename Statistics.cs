namespace System
{
    /// <summary>
    /// Specifies constant that define the sorting order at <see cref="System.Statistics.Rank(double, Orderby, double[])"/>.
    /// </summary>
    public enum Orderby
    {
        /// <summary>
        /// Sort by ascending.
        /// </summary>
        Ascending,
        /// <summary>
        /// Sort by descending.
        /// </summary>
        Descending
    };
    /// <summary>
    /// Provides static methods for statistical functions.
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Returns the average of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The average of a. If a is blanked array, it returns NaN.</returns>
        public static double Average(params double[] a)
        {
            double result = 0;
            foreach (double i in a) result += i;
            return result / a.Length;
        }
        /// <summary>
        /// Returns the quantity of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The quantity of a.</returns>
        public static int Count(params double[] a)
        {
            return a.Length;
        }
        /// <summary>
        /// Returns the geometric mean of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The geometric mean of a.</returns>
        public static double GeometricMean(params double[] a)
        {
            double result = 1;
            foreach (double i in a) result *= i;
            return Math.Pow(result, 1.0 / a.Length);
        }
        /// <summary>
        /// Returns the harmonic mean of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The harmonic mean of a.</returns>
        public static double HarmonicMean(params double[] a)
        {
            double result = 0;
            foreach (double i in a) result += (1.0 / i);
            return a.Length / result;
        }
        /// <summary>
        /// Returns the k-th largest value from data array.
        /// </summary>
        /// <param name="k">The position from the largest in the a.</param>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The k-th largest value from the a.</returns>
        public static double Large(int k, double[] a)
        {
            Array.Sort(a);
            return a[a.Length - k];
        }
        /// <summary>
        /// Returns the maximum value of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The maximum value of a.</returns>
        public static double Max(params double[] a)
        {
            Array.Sort(a);
            return a[a.Length - 1];
        }
        /// <summary>
        /// Returns the median value of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The median value of a.</returns>
        public static double Median(params double[] a)
        {
            if (a.Length == 0) return double.NaN;
            else if (a.Length == 1) return a[0];
            Array.Sort(a);
            if (a.Length % 2 == 0)
                return a[a.Length / 2 - 1] + ((a[a.Length / 2] - a[a.Length / 2 - 1]) / 2);
            else if (a.Length % 2 == 1)
                return a[a.Length / 2];
            else return double.NaN;
        }
        /// <summary>
        /// Returns the minimum value of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The minimum value of a.</returns>
        public static double Min(params double[] a)
        {
            Array.Sort(a);
            return a[0];
        }
        /// <summary>
        /// Returns the population standard deviation of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The population standard deviation of a.</returns>
        public static double PStdev(params double[] a)
        {
            return Math.Sqrt(PVariance(a));
        }
        /// <summary>
        /// Returns the population variance of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The population variance of a.</returns>
        public static double PVariance(params double[] a)
        {
            double result = 0;
            double avr = Average(a);
            foreach (double i in a) result += Math.Pow(i - avr, 2);
            return result / a.Length;
        }
        /// <summary>
        /// Returns the ranking of value from data array.
        /// </summary>
        /// <param name="value">The value for which you want to find the rank</param>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The rank of value about a.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When</exception>
        public static int Rank(double value, params double[] a)
        {
            return Rank(value, Orderby.Descending, a);
            
        }
        /// <summary>
        /// Returns the ranking of value from data array.
        /// </summary>
        /// <param name="value">A value for which you want to find the rank</param>
        /// <param name="orderby">The sorting order of a</param>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The rank of value about a.</returns>
        public static int Rank(double value, Orderby orderby, params double[] a)
        {
            Array.Sort(a);
            for(int i = 0; i < a.Length; i++)
                if(a[i] == value)
                    if (orderby == Orderby.Descending) return a.Length - i;
                    else return i + 1;
            throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Returns the k-th smallest value from data array.
        /// </summary>
        /// <param name="k">The position from the smallest in the a.</param>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The k-th smallest value from the a.</returns>
        public static double Small(int k, params double[] a)
        {
            Array.Sort(a);
            return a[k - 1];
        }
        /// <summary>
        /// Returns the sample standard deviation of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The sample standard deviation of a.</returns>
        public static double Stdev(params double[] a)
        {
            return Math.Sqrt(Variance(a));
        }
        /// <summary>
        /// Returns the sum of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The sum of a.</returns>
        public static double Sum(params double[] a)
        {
            double result = 0;
            foreach (double i in a) result += i;
            return result;
        }
        /// <summary>
        /// Returns the sample variance of parameters.
        /// </summary>
        /// <param name="a">A real numbers array.</param>
        /// <returns>The sample variance of a.</returns>
        public static double Variance(params double[] a)
        {
            double result = 0;
            double avr = Average(a);
            foreach (double i in a) result += Math.Pow(i - avr, 2);
            return result / (a.Length - 1);
        }
    }
}
