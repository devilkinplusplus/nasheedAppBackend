using FluentValidation;
using NasheedAppBack.Consts;
using NasheedAppBack.DTOs.RequestParams;

namespace NasheedAppBack.Validators
{
    public class CreatePlaylistValidator : AbstractValidator<CreatePlaylistDto>
    {
        public CreatePlaylistValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage(Messages.NotEmptyMessage)
                                .MaximumLength(30).WithMessage(Messages.MaximumLenghtMessage)
                                .MinimumLength(2).WithMessage(Messages.MinimumLenghtMessage);

            RuleFor(x => x.UserId).NotEmpty().WithMessage(Messages.NotEmptyMessage);
        }
    }
}
