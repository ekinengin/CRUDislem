using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Utilities
{
    public static class ValidationTool //static class açtık çünki çoğu zaman kullanacağız
    {
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors); //Hata mesajlarımız şuan çalışır, kurallar(rules) da...
            }
        }
    }
}
