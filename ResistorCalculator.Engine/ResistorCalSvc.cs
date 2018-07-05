using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorCalculator.Engine
{
    /// <summary>
    /// <see cref="IResistorCalSvc"/>
    /// </summary>
    public class ResistorCalSvc: IResistorCalSvc
    {
        #region Interface Implemetation

        /// <summary>
        /// <see cref="IResistorCalSvc.CalculateResistorValue(string, string, string, string)"/>
        /// </summary>
        /// <param name="bandAColor"></param>
        /// <param name="bandBColor"></param>
        /// <param name="bandCColor"></param>
        /// <param name="bandDColor"></param>
        /// <returns></returns>
        public double CalculateResistorValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            double ohmValue =-999;

            if (ResistorColorCodeRepo.IsValidColor(Band.A, bandAColor) &&
                ResistorColorCodeRepo.IsValidColor(Band.B, bandBColor) &&
                ResistorColorCodeRepo.IsValidColor(Band.C, bandCColor))
            {
                ResistorColorModel bandA = ResistorColorCodeRepo.Find(bandAColor);
                ResistorColorModel bandB = ResistorColorCodeRepo.Find(bandBColor);
                ResistorColorModel bandC = ResistorColorCodeRepo.Find(bandCColor);               

                int digit1 = bandA.Digit.Value;
                int digit2 = bandB.Digit.Value;
                double multiplier =  Math.Pow(10,bandC.Multiplier);
                ohmValue = Convert.ToDouble(int.Parse(digit1.ToString() + digit2.ToString()) * multiplier);
            }
            else
                throw new ArgumentException("One of the color code provided is invalid.");

            return ohmValue;
        }

        /// <summary>
        /// <see cref="IResistorCalSvc.GetTolerance(string)"/>
        /// </summary>
        /// <param name="bandDColor"></param>
        /// <returns></returns>
        public float GetTolerance(string bandDColor)
        {
            if ( ResistorColorCodeRepo.IsValidColor(Band.D, bandDColor))
            {
                ResistorColorModel bandD = ResistorColorCodeRepo.Find(bandDColor);
                return bandD.Tolerance.Value;
            }
            else
                throw new System.ArgumentException("BandD color code provided is invalid.");
        }

        #endregion Interface Implementation.
    }
}
