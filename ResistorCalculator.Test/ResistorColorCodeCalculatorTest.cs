
using NUnit.Framework;
using ResistanceClaculator.Controllers;
using ResistorCalculator.Engine;
using  ResistanceClaculator.Extensions;

namespace ResistorCalculator.Test
{
    [TestFixture]
    public class ResistorColorCodeCalculatorTest
    {
       private  IResistorCalSvc _calcSvc;

        [SetUp]
        public void Initialize()
        {
            _calcSvc = new ResistorCalSvc();
        }

        [TestCase("red","brown","brown","violet",210)]
        [TestCase("orange", "BROwn", "gold", "VIOLET", 3.1)]
        [TestCase("orange", "brown", "silver", "violet", 0.31)]
        [TestCase("red", "Brown", "white", "Violet", 21000000000)]
        [TestCase("ORANGE", "brown", "GOLD", "violet", 3.1)]
        [TestCase("orange", "Brown", "silver", "violet", 0.31)]
        public void CalculateResitorValue_Valid_CaseInsenstive_Inputs(string bandAColor, string bandBColor, string bandCColor,string bandDColor, double expectedValue)
        {
            double actualValue = _calcSvc.CalculateResistorValue(bandAColor, bandBColor, bandCColor, bandDColor);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("gold", "Brown", "silver", "violet", -999)]
        [TestCase("silver", "Brown", "silver", "violet", -999)]
        [TestCase("ROSEGold", "Brown", "silver", "violet", -999)]
        public void CalculateResitorValue_InValid_BandA_Colors(string bandAColor, string bandBColor, string bandCColor, string bandDColor, double expectedValue)
        {
            Assert.Throws<System.ArgumentException>(()=> _calcSvc.CalculateResistorValue(bandAColor, bandBColor, bandCColor, bandDColor));
            
        }

        [TestCase("gold", "Brown", "xyzColor", "violet", -999)]       
        public void CalculateResitorValue_InValid_BandC_Colors(string bandAColor, string bandBColor, string bandCColor, string bandDColor, double expectedValue)
        {

            Assert.Throws<System.ArgumentException>(() => _calcSvc.CalculateResistorValue(bandAColor, bandBColor, bandCColor, bandDColor));
        }

        [TestCase("violet",0.1f)]
        [TestCase("greeN", 0.5f)]
        [TestCase("BLUE", 0.25f)]       
        public void CalculateTolrence_CaseInsensitive_Valid_BandD_Colors(string bandDColor, double expectedValue)
        {
            double actualValue = _calcSvc.GetTolerance( bandDColor);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("xyz", -999)]
        [TestCase("orange", -999)]
        public void CalculateTolrence_CaseInsensitive_InValid_BandD_Colors(string bandDColor, double expectedValue)
        {         
            Assert.Throws<System.ArgumentException>(() => _calcSvc.GetTolerance(bandDColor));           
        }

        [TestCase( 1, "1")]
        [TestCase(10, "10")]
        [TestCase(1000, "1K")]
        [TestCase(1000000, "1M")]       
        public void Test_SI_Conversions( double actual, string expected)
        {
            Assert.AreEqual(actual.ToSI(), expected);
        }
    }
}
