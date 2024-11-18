using FluentValidation;

namespace BarberShop.Services.Catalog.Application.Commands
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
