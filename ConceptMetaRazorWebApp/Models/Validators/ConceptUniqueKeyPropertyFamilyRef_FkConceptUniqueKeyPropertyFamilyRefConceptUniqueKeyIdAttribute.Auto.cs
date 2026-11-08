/****************************
 * ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.ConceptUniqueKeyPropertyFamilyRef" /> models meet the requirements of the
    /// FK_ConceptUniqueKeyPropertyFamilyRef_ConceptUniqueKeyId foreign key constraint
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef = (RazorModels.ConceptUniqueKeyPropertyFamilyRef)validationContext.ObjectInstance;

            if (conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.ConceptUniqueKey referencedConceptUniqueKey = context.ConceptUniqueKeys
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.ConceptUniqueKeyId == conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedConceptUniqueKey == null)
                {
                    return new ValidationResult("The Concept Unique Key could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
