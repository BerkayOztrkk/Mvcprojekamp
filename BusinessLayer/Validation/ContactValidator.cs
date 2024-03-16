using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden kısa olamaz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı 3 karakterden kısa olamaz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("50 karakterden fazla giriş yapılamaz");
        }

    }
}
