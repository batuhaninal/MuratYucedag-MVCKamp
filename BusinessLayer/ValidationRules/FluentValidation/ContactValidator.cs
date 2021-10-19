using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcıyı boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfem en az 3 karakter girişi yapınız");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfem en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfem en fazla 50 karakter girişi yapınız");
        }
    }
}
