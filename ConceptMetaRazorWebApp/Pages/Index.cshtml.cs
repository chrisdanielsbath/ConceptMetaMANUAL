/****************************
 * Index.cshtml.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages
{
    /// <summary>
    /// Index page for the ConceptMeta Razor Web App
    /// </summary>
    [Authorize]
    public partial class IndexModel
        : PageModel
    {

        #region Instance Methods
        public void OnGet()
        {
        }

        #endregion
    }
}
