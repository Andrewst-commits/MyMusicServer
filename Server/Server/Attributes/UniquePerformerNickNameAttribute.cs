using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Server.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Attributes
{
    public class UniquePerformerNickNameAttribute // : Attribute, IModelValidator
    {
        //MusicServerDbContext _db;
        //public string ErrMes { get; set; }

        //public UniquePerformerNickNameAttribute()
        //{
        //    _db = new MusicServerDbContext();
        //}

        //public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        //{
          
        //    if (!(context.Model is string))
        //        return Enumerable.Empty<ModelValidationResult>();

        //    var inputNickName = (string)context.Model;
        //    var dbPerformers = _db.Performers.ToList();

        //    foreach(var dbPerformer in dbPerformers)
        //    {
        //        if (inputNickName != dbPerformer.NickName)
        //            continue;

        //        return new List<ModelValidationResult>
        //        {
        //           new ModelValidationResult(context.ModelMetadata.PropertyName, $"{ErrMes}")
        //        };


        //    }

        //    return Enumerable.Empty<ModelValidationResult>();
        //}
    }
}
