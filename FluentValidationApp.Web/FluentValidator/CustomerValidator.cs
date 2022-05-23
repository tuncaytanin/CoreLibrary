using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidator
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public string NotEmpyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmpyMessage).MinimumLength(3).WithMessage("En az 3 karakter olmalı").MaximumLength(30).WithMessage("Maksimum 30 karakter olabilir");

            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmpyMessage).EmailAddress().WithMessage("Doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmpyMessage).InclusiveBetween(18, 60).WithMessage("yaş aralığı 18 ile 60 arasında olmalıdır");

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmpyMessage).Must(x=>{
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalırıdır");


            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek için 1 Kadın için 2 olmalıdır");

            RuleForEach(x => x.Adresses).SetValidator(new AdressValidator());
        }
    }
}
