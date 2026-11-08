/****************************
 * Logout.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Account
{
    /// <summary>
    /// Logout page for the ConceptMeta Razor Web App
    /// </summary>
    public partial class LogoutModel
        : PageModel
    {

        #region Instance Methods
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("ConceptMetaAuth");
            return RedirectToPage("/Index");
        }

        #endregion
    }
}
