/****************************
 * Error.cshtml.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages
{
    /// <summary>
    /// Error page for the ConceptMeta Razor Web App
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public partial class ErrorModel
        : PageModel
    {

        #region Instance Properties
        public string RequestId { get; set; }
        public bool ShowRequestId
        {
            get
            {
                return !string.IsNullOrEmpty(RequestId);
            }
        }

        #endregion

        #region Instance Methods
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }

        #endregion
    }
}
