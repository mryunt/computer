using Computer.DAL.Dtos.Pc;
using FluentValidation;

namespace Computer.Business.Validation.Pc
{
    public class PcUpdateValidator : AbstractValidator<UpdatePcDto>
    {
        public PcUpdateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Bilgisayar İsmi Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("20 Karakterden Fazla Girilemez");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Bilgisauar Ücreti Alanı Boş Bırakılamaz");
        }
    }
}
