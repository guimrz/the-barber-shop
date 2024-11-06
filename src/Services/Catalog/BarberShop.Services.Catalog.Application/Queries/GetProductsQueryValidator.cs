using FluentValidation;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsQueryValidator()
        {
            RuleFor(p => p.Page)
                .GreaterThan(1);

            RuleFor(p => p.PageSize)
                .GreaterThan(1);
        }
    }
}
