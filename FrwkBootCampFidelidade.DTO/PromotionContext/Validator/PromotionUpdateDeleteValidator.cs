using FluentValidation;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionUpdateDeleteValidator : AbstractValidator<PromotionUpdateDeleteDTO>
    {
        public PromotionUpdateDeleteValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description é obrigatório.");

            RuleFor(x => x.DiscountPercentage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("DiscountPercentage deve ser maior ou igual a zero.");

            RuleFor(x => x.StartDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("StartDate é obrigatório.");

            RuleFor(x => x.EndDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("StartDate é obrigatório.");
        }
    }
}
