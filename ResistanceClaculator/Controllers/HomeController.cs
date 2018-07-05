using ResistanceClaculator.Extensions;
using ResistanceClaculator.Models;
using ResistorCalculator.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ResistanceClaculator.Controllers
{
    /// <summary>
    /// Home controller for the resisitvity calculator
    /// </summary>
    public class HomeController : Controller
    {
        #region Private variables

        private readonly IResistorCalSvc _resCalSvc;

        #endregion Private variables

        #region Constuctor
        public HomeController(IResistorCalSvc resCalSvc)
        {
            _resCalSvc = resCalSvc;
        }

        #endregion Constructor

        #region Public Methods
        
        // GET: Home
        public ActionResult Index()
        {
            var viewModel = new ResistorViewModel()
            {
                ColorsA = GenerateSelectList(Band.A),
                ColorsB = GenerateSelectList(Band.B),
                ColorsC = GenerateSelectList(Band.C),
                ColorsD = GenerateSelectList(Band.D)
            };

            return View(viewModel);
        }        

        [HttpPost]
        public JsonResult Calculate(ResistorViewModel resistorModel)        
        {
            resistorModel.ComputedResult = "";
            if (!ModelState.IsValid)
            {
                return Json(new { Success = false,Result = "", Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);                
            }
            else
            {
                try
                {
                    float tolerance = 0f;
                    double ohmValue = _resCalSvc.CalculateResistorValue(resistorModel.SelectedColorA, resistorModel.SelectedColorB, resistorModel.SelectedColorC, resistorModel.SelectedColorD);
                    if (!string.IsNullOrEmpty(resistorModel.SelectedColorD))
                    {
                        tolerance = _resCalSvc.GetTolerance(resistorModel.SelectedColorD);
                    }                    
                    string result  = $"Resistor value: { ohmValue.ToSI() } &ohm; +/- { tolerance } %";
                    return Json(new { Success = true,Result = result , Errors = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (ArgumentException ex)
                {
                    resistorModel.ComputedResult = "";                    
                    return Json(new { Success = false,Result = "", Errors = new List<string>(1) { ex.Message } }, JsonRequestBehavior.AllowGet);
                }
                catch ( Exception)
                {
                    resistorModel.ComputedResult = "";   
                    //logger.log exception
                    return Json(new { Success = false, Result = "", Errors = new List<string>(1) { "Unknown error occured." } }, JsonRequestBehavior.AllowGet);
                }             

            }           
        }

        #endregion Public Methods

        #region PrivateMethods

        /// <summary>
        ///For a given Band, Generates the applicable Colors 
        /// </summary>
        /// <param name="band">Band Enum</param>
        /// <returns>Mvc Selectlist</returns>
        private SelectList GenerateSelectList(Band band)
        {
            List<SelectListItem> colorsSelectList = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "---Select---", Value = "" }
            };

            IEnumerable<string> colors = ResistorColorCodeRepo.GetApplicableColorsFor(band);
            foreach (var color in colors)
            {
                colorsSelectList.Add(new SelectListItem() { Text = color, Value = color });
            }
           return  new SelectList(colorsSelectList, "Value", "Text", "---Select---");
        }
        #endregion PrivateMethods
    }
}