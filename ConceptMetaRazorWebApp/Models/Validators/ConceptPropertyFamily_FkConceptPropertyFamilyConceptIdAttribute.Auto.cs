/****************************
 * ConceptPropertyFamily_FkConceptPropertyFamilyConceptIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.ConceptPropertyFamily" /> models meet the requirements of the
    /// FK_ConceptPropertyFamily_ConceptId foreign key constraint
    /// </summary>
    public partial class ConceptPropertyFamily_FkConceptPropertyFamilyConceptIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptPropertyFamily conceptPropertyFamily = (RazorModels.ConceptPropertyFamily)validationContext.ObjectInstance;

            if (conceptPropertyFamily.ConceptId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.Concept referencedConcept = context.Concepts
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.ConceptId == conceptPropertyFamily.ConceptId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedConcept == null)
                {
                    return new ValidationResult("The Concept could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
