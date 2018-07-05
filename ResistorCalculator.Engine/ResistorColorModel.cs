using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorCalculator.Engine
{
    /// <summary>
    /// Resistor  mappings
    /// </summary>
    public class ResistorColorModel
    {
        /// <summary>
        /// Color of the Resistor
        /// </summary>
        public  string Color { get; set; }
        /// <summary>
        /// Multiplier
        /// </summary>
        public int Multiplier { get; set; }
        /// <summary>
        /// Tolarance
        /// </summary>
        public float? Tolerance { get; set; }
        /// <summary>
        /// Digit
        /// </summary>
        public int? Digit { get; set; }
    }
}
