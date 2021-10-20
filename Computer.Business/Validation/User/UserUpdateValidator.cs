using Computer.DAL.Dtos.User;
using FluentValidation;

namespace Computer.Business.Validation.User
{
    public class UserUpdateValidator : AbstractValidator<UpdateUserDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı İsmi Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("20 Karakterden Fazla Girilemez");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Kullanıcı Soyismi Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("20 Karakterden Fazla Girilemez");
        }
    }
}
