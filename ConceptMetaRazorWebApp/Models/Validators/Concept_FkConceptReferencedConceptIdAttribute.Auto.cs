/****************************
 * Concept_FkConceptReferencedConceptIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.Concept" /> models meet the requirements of the
    /// FK_Concept_ReferencedConceptId foreign key constraint
    /// </summary>
    public partial class Concept_FkConceptReferencedConceptIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.Concept concept = (RazorModels.Concept)validationContext.ObjectInstance;

            if (concept.ReferencedConceptId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.Concept referencedConcept = context.Concepts
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.ConceptId == concept.ReferencedConceptId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedConcept == null)
                {
                    return new ValidationResult("The Referenced Concept could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
