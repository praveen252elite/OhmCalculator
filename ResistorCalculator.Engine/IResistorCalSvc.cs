using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorCalculator.Engine
{
    /// <summary>
    /// Ohm Value Calculation service
    /// </summary>
    public interface IResistorCalSvc
    {
        /// <summary>

        /// Calculates the Ohm value of a resistor based on the band colors.

        /// </summary>

        /// <param name="bandAColor">The color of the first figure of component value band.</param>

        /// <param name="bandBColor">The color of the second significant figure band.</param>

        /// <param name="bandCColor">The color of the decimal multiplier band.</param>

        /// <param name="bandDColor">The color of the tolerance value band.</param>

        double CalculateResistorValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

        /// <summary>
        /// Gets the tolerance of the bandD.
        /// </summary>
        /// <param name="bandDColor"></param>
        /// <returns></returns>
        float GetTolerance(string bandDColor);
    }
}
