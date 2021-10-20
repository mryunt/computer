using Computer.DAL.Dtos.User;
using FluentValidation;

namespace Computer.Business.Validation.User
{
    public class UserAddValidator : AbstractValidator<AddUserDto>
    {
        public UserAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("20 Karakterden Fazla Girilemez");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("20 Karakterden Fazla Girilemez");
        }
    }
}
