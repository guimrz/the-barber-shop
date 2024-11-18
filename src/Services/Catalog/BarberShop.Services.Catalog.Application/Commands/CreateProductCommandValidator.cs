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

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.BrandId)
                .NotEmpty();

            RuleFor(p => p.TypeId)
                .GreaterThan(0);
        }
    }
}
