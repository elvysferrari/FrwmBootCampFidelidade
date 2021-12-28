using FluentValidation;

namespace FrwkBootCampFidelidade.DTO.PromotionContext.Validator
{
    public class PromotionItemUpdateDeleteValidator : AbstractValidator<PromotionItemUpdateDeleteDTO>
    {
        public PromotionItemUpdateDeleteValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

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
