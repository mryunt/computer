using Computer.DAL.Dtos.PcUser;
using FluentValidation;

namespace Computer.Business.Validation.PcUser
{
    public class PcUserUpdateValidator : AbstractValidator<UpdatePcUserDto>
    {
        public PcUserUpdateValidator()
        {
            RuleFor(p => p.PcId).NotEmpty().WithMessage("Bilgisayar ID Alanı Boş Bırakılamaz");
            RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı ID Alanı Boş Bırakılamaz");
        }
    }
}
