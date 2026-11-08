/****************************
 * EnumerationMember_FkEnumerationMemberEnumerationIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.EnumerationMember" /> models meet the requirements of the
    /// FK_EnumerationMember_EnumerationId foreign key constraint
    /// </summary>
    public partial class EnumerationMember_FkEnumerationMemberEnumerationIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.EnumerationMember enumerationMember = (RazorModels.EnumerationMember)validationContext.ObjectInstance;

            if (enumerationMember.EnumerationId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.Enumeration referencedEnumeration = context.Enumerations
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.EnumerationId == enumerationMember.EnumerationId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedEnumeration == null)
                {
                    return new ValidationResult("The Enumeration could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
