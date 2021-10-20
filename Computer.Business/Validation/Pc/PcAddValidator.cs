using Computer.DAL.Dtos.Pc;
using FluentValidation;

namespace Computer.Business.Validation.Pc
{
    public class PcAddValidator : AbstractValidator<AddPcDto>
    {
        public PcAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Bilgisayar İsmi Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("20 Karakterden Fazla Girilemez");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Bilgisayar Ücreti Alanı Boş Bırakılamaz");
        }
    }
}
