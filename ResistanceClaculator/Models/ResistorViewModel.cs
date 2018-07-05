
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ResistanceClaculator.Models
{
    /// <summary>
    /// View Model which will
    /// </summary>
    public class ResistorViewModel
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResistorViewModel()
        {           
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all the available Resistor Colors BandA
        /// </summary>
        public SelectList ColorsA { get; set; }
        /// <summary>
        /// List of all the available Resistor Colors BandB
        /// </summary>
        public SelectList ColorsB { get; set; }
        /// <summary>
        /// List of all the available Resistor Colors for BandC
        /// </summary>
        public SelectList ColorsC { get; set; }
        /// <summary>
        /// List of all the available Resistor Colors for BandD
        /// </summary>
        public SelectList ColorsD { get; set; }

        /// <summary>
        /// Selected BandA color
        /// </summary>
        [Required(ErrorMessage = "You must select BandA color", AllowEmptyStrings = false)]
        public string SelectedColorA { get; set; }

        /// <summary>
        /// Selected BandB color
        /// </summary>
        [Required(ErrorMessage = "You must select BandB color", AllowEmptyStrings = false)]
        public string SelectedColorB { get; set; }

        /// <summary>
        /// Selected BandC color
        /// </summary>
        [Required(ErrorMessage = "You must select BandC color", AllowEmptyStrings = false)]
        public string SelectedColorC { get; set; }

        /// <summary>
        /// Selected BandD color
        /// </summary>       
        public string SelectedColorD { get; set; }

        /// <summary>
        /// Resistance compted value
        /// </summary>
        public string ComputedResult { get; set; }
        #endregion


    }
}