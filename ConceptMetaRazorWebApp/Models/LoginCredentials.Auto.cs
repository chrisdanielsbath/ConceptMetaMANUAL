/****************************
 * LoginCredentials.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// A username/password combination for the ConceptMeta Razor Web App
    /// </summary>
    public partial class LoginCredentials
    {

        #region Instance Properties

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool PasswordIsWrong { get; set; } = false;

        #endregion
    }
}
