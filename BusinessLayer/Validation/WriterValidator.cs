using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş bırakılamaz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail boş bırakılamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan boş bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Bu kısım boş bırakılamaz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("3 karakterden az girilemez");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("En fazla 100 karakter girilebilir");
        }

    }
}
