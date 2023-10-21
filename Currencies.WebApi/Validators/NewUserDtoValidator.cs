using Currencies.Common.DTO.User;
using FluentValidation;

namespace Currencies.WebApi.Validators
{
    public class NewUserDtoValidator : AbstractValidator<NewUserDto>
    {
        public NewUserDtoValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                    .WithMessage("Username is mandatory.")
                .MinimumLength(3)
                    .WithMessage("Username should be minimum 3 character.");

            RuleFor(u => u.Email)
                .EmailAddress();

            RuleFor(u => u.Password)
                .Length(4, 16)
                .WithMessage("Password must be from 4 to 16 characters.");
        }
    }
}
