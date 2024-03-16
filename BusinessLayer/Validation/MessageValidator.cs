using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail adresi boş geçilemez");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mesaj boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage(" 3 karakterden kısa olamaz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("100 karakterden fazla değer girişi yapmayın");
        }

    }
}
