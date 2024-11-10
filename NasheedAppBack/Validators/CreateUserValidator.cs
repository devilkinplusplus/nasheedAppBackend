using FluentValidation;
using NasheedAppBack.Consts;
using NasheedAppBack.DTOs.RequestParams;

namespace NasheedAppBack.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage(Messages.NotEmptyMessage)
                                   .MaximumLength(30).WithMessage(Messages.MaximumLenghtMessage)
                                   .MinimumLength(2).WithMessage(Messages.MinimumLenghtMessage);

            RuleFor(x => x.LastName).NotEmpty().WithMessage(Messages.NotEmptyMessage)
                       .MaximumLength(30).WithMessage(Messages.MaximumLenghtMessage)
                       .MinimumLength(2).WithMessage(Messages.MinimumLenghtMessage);

            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.NotEmptyMessage)
                               .EmailAddress().WithMessage(Messages.NotValidMessage)
                               .MaximumLength(30).WithMessage(Messages.MaximumLenghtMessage);

            RuleFor(x => x.Username).NotEmpty().WithMessage(Messages.NotEmptyMessage)
                       .MaximumLength(30).WithMessage(Messages.MaximumLenghtMessage)
                       .MinimumLength(2).WithMessage(Messages.MinimumLenghtMessage);

        }
    }
}
