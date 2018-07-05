using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorCalculator.Engine
{
    /// <summary>
    ///  Resistance Color Code  repository
    /// </summary>
    public static class ResistorColorCodeRepo
    {
        private  static List<ResistorColorModel> ResistorColorCodes { get; set; }
        static ResistorColorCodeRepo()
        {
            var colorCodes = new List<ResistorColorModel>()
            {
                new ResistorColorModel(){ Color ="Black",Digit=0,Multiplier=0,Tolerance = null },
                new ResistorColorModel(){ Color ="Brown",Digit=1,Multiplier=1,Tolerance = 1 },
                new ResistorColorModel(){ Color ="Red",Digit=2,Multiplier=2,Tolerance = 2 },
                new ResistorColorModel(){ Color ="Orange",Digit=3,Multiplier=3,Tolerance = null },
                new ResistorColorModel(){ Color ="Yellow",Digit=4,Multiplier=4,Tolerance = 5 },
                new ResistorColorModel(){ Color ="Green",Digit=5,Multiplier=5,Tolerance = 0.5f },
                new ResistorColorModel(){ Color ="Blue",Digit=6,Multiplier=6,Tolerance = 0.25f },
                new ResistorColorModel(){ Color ="Violet",Digit=7,Multiplier=7,Tolerance = 0.1f },
                new ResistorColorModel(){ Color ="Grey",Digit=8,Multiplier=8,Tolerance = 0.05f },
                new ResistorColorModel(){ Color ="White",Digit=9,Multiplier=9,Tolerance = null },
                new ResistorColorModel(){ Color ="Gold",Digit= null,Multiplier=-1,Tolerance = 5 },
                new ResistorColorModel(){ Color ="Silver",Digit= null,Multiplier=-2,Tolerance = 10 },
                new ResistorColorModel(){ Color ="Pink",Digit= null,Multiplier=-3,Tolerance = null }

            };

            ResistorColorCodes = colorCodes;
        }

        #region Static Methods

        /// <summary>
        /// Get the applicable colors for a given band
        /// </summary>
        /// <param name="bandName"></param>
        /// <returns>colors</returns>
        public static IEnumerable<string> GetApplicableColorsFor(Band bandName)
        {
            if (bandName == Band.A || bandName == Band.B)
            {
                return ResistorColorCodes.Where(x => x.Digit.HasValue).Select(x => x.Color);
            }
            if (bandName == Band.C)
            {
                return ResistorColorCodes.Select(x => x.Color);
            }
            if (bandName == Band.D)
            {
                return ResistorColorCodes.Where(x => x.Tolerance.HasValue).Select(x => x.Color);
            }

            return new List<string>();
        }

        /// <summary>
        /// Check if a color is applicable for a given band
        /// </summary>
        /// <param name="bandName"></param>
        /// <param name="color"></param>
        /// <returns>true/false</returns>
        public static bool IsValidColor(Band bandName, string color)
        {
            if (bandName == Band.A || bandName == Band.B)
            {
                return ResistorColorCodes.Any(x => x.Digit.HasValue && x.Color.ToUpper() == color.ToUpper());
            }
            if (bandName == Band.C)
            {
                return ResistorColorCodes.Any(x => x.Color.ToUpper() == color.ToUpper());
            }
            if (bandName == Band.D)
            {
                return ResistorColorCodes.Any(x => x.Tolerance.HasValue && x.Color.ToUpper() == color.ToUpper());
            }
            return false;
        }

        /// <summary>
        /// Find the model for a given color.
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public static  ResistorColorModel Find( string colorName)
        {
           return ResistorColorCodes.FirstOrDefault(x => x.Color.ToUpper() == colorName.ToUpper());
        }

        #endregion Static Methods
    }

    /// <summary>
    /// Band Enum
    /// </summary>
    public enum Band
    {
        A,
        B,
        C,
        D
    }
        
}
