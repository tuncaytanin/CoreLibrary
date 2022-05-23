using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidator
{
    public class AdressValidator:AbstractValidator<Adress>
    {
        public string NotEmpyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public AdressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmpyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmpyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmpyMessage).MaximumLength(5).WithMessage("{PropertyName} En fazla {MaxLength} karakter olmalıdır.");
        }
    }
}
