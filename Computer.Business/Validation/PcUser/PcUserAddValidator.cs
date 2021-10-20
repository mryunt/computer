using Computer.DAL.Dtos.PcUser;
using FluentValidation;

namespace Computer.Business.Validation.PcUser
{
    public class PcUserAddValidator : AbstractValidator<AddPcUserDto>
    {
        public PcUserAddValidator()
        {
            RuleFor(p => p.PcId).NotEmpty().WithMessage("Bilgisayar ID Alanı Boş Bırakılamaz");
            RuleFor(p => p.UserId).NotEmpty().WithMessage("KUllanıcı ID Alanı Boş Bırakılamaz");
        }
    }
}
