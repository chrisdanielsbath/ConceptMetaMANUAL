/****************************
 * Login.cshtml.cs
 ****************************/
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Pages.Account
{
    /// <summary>
    /// Login page for the ConceptMeta Razor Web App
    /// </summary>
    public partial class LoginModel
        : PageModel
    {

        #region Instance Properties

        [BindProperty]
        public RazorModels.LoginCredentials LoginCredentials { get; set; }

        #endregion

        #region Instance Methods
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // verify the supplied login credentials
            if (LoginCredentials.UserName == "admin" && LoginCredentials.Password == "password")
            {
                // create the security context (comprising claims within an identity within a principal)

                // create the claims
                IList<Claim> claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name, "admin"),
                    new Claim (ClaimTypes.Email, "admin@mywebsite.com"),
                };

                // create the identity
                ClaimsIdentity identity = new ClaimsIdentity(claims, "ConceptMetaAuth");

                // create the principal
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                // create the cookie that will hold the security context
                await HttpContext.SignInAsync("ConceptMetaAuth", principal);

                if (Request.Query.TryGetValue("ReturnUrl", out var returnUrl))
                {
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                }
                return RedirectToPage("/Index");
            }
            else
            {
                LoginCredentials.PasswordIsWrong = true;
            }

            return Page();
        }

        #endregion
    }
}
