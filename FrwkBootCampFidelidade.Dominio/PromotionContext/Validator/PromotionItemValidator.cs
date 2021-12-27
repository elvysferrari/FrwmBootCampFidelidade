using FluentValidation;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Validator
{
    public class PromotionItemValidator : AbstractValidator<PromotionItem> 
    {
        public PromotionItemValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEmpty()
                .WithMessage("ProductId é obrigatório.");

            RuleFor(x => x.PromotionId)
                .NotNull()
                .NotEmpty()
                .WithMessage("PromotionId é obrigatório.");

            RuleFor(x => x.DiscountPercentage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("DiscountPercentage deve ser maior ou igual a zero.");
        }
    }
}
