using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool // bu tür araçlar genellikle static tanımlanır tekrar tekrar newlememek için
    {
        // static bir sınıfın metodları da static olmalıdır
        public static void  Validate(IValidator validator,object entity)
        {

            var context = new ValidationContext<object>(entity); // product türü için bir doğrulama contexti oluştur
            var result = validator.Validate(context); // buradaki context product
            if (!result.IsValid) // sonuç geçerli değilse
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
