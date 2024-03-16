using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adı boş bırakılamaz");
            RuleFor(x => x.Writer.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş bırakılamaz");
            RuleFor(x => x.Category.CategoryName).NotEmpty().WithMessage("Kategori boş bırakılamaz");
        }
    }
}
