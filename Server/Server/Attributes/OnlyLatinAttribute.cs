using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Attributes
{
    public class OnlyLatinAttribute : Attribute, IModelValidator
    {
        public string ErrMes { get; set; }

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            if (!(context.Model is string))
                return Enumerable.Empty<ModelValidationResult>();

            var str = (string)context.Model;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
                    continue;

                return new List<ModelValidationResult>
                {
                   new ModelValidationResult(context.ModelMetadata.PropertyName, $"{ErrMes}")
                };

            }
            
            return Enumerable.Empty<ModelValidationResult>(); 
        }

    }
}

