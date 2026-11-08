/****************************
 * DataType_FkDataTypeConceptModelIdAttribute.Auto.cs
 ****************************/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators
{
    /// <summary>
    /// Validator to ensure <see cref="RazorModels.DataType" /> models meet the requirements of the
    /// FK_DataType_ConceptModelId foreign key constraint
    /// </summary>
    public partial class DataType_FkDataTypeConceptModelIdAttribute
        : ValidationAttribute
    {

        #region Instance Methods
#nullable enable
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            RazorModels.DataType dataType = (RazorModels.DataType)validationContext.ObjectInstance;

            if (dataType.ConceptModelId != null)
            {
                ConceptMetaDbModelsContext context = new ConceptMetaDbModelsContext();

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RazorModels.ConceptModel referencedConceptModel = context.ConceptModels
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e =>
                                // find any matching item
                                (e.ConceptModelId == dataType.ConceptModelId)
                         )
                        .GetAwaiter()
                        .GetResult();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (referencedConceptModel == null)
                {
                    return new ValidationResult("The Concept Model could not be found");
                }
            }
            return ValidationResult.Success;
        }
#nullable disable

        #endregion
    }
}
