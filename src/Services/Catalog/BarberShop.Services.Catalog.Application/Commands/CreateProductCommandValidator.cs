using FluentValidation;

namespace BarberShop.Services.Catalog.Application.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
