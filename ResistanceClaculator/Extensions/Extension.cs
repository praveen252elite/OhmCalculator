using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResistanceClaculator.Extensions
{
    /// <summary>
    /// Common Extensions
    /// </summary>
    public static class  Extension
    {
        /// <summary>
        /// Converts Double value to SI . example 1000->1K, 10000000 -> 10M ..
        /// </summary>
        /// <param name="d">double value</param>
        /// <returns></returns>
        public  static string ToSI( this double d)
        {
            char[] incPrefixes = new[] { 'K', 'M', 'G' };
            char? prefix = null;

            int degree = (int)Math.Floor(Math.Log10(Math.Abs(d)) / 3);
            double scaled = d * Math.Pow(1000, -degree);
            if (degree > 0)
            {
                prefix = incPrefixes[degree - 1];
                return scaled.ToString() + prefix;
            }
            else
            {
                return d.ToString();
            }
        }
    }
}