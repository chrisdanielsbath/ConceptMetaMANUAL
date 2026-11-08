/****************************
 * ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptPropertyFamilyIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> models meet the requirements of the
    /// FK_ConceptSubTypePropertyFamilyRef_ConceptPropertyFamilyId foreign key constraint
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptPropertyFamilyIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef = (RazorModels.ConceptSubTypePropertyFamilyRef)validationContext.ObjectInstance;

            if (conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.ConceptPropertyFamily referencedConceptPropertyFamily = context.ConceptPropertyFamilies
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.ConceptPropertyFamilyId == conceptSubTypePropertyFamilyRef.ConceptPropertyFamilyId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedConceptPropertyFamily == null)
                {
                    return new ValidationResult("The Concept Property Family could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
