using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.Attributes
{ 
    public class DateFormatAttribute : Attribute, IModelValidator
    { 
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            if (!(context.Model is string)) return Enumerable.Empty<ModelValidationResult>();

            DateTime date;
            var str = (string)context.Model;

            if (!DateTime.TryParse(str, out date))
            {
                return new List<ModelValidationResult>
                {
                    new ModelValidationResult(context.ModelMetadata.PropertyName, "has uncorrect format date. It can be dd.mm.yyyy or dd/mm/yyyy")
                };
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}
