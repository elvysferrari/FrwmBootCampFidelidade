using FluentValidation;

namespace FrwkBootCampFidelidade.DTO.PromotionContext
{
    public class PromotionCreateValidator: AbstractValidator<PromotionCreateDTO>
    {
        public PromotionCreateValidator()
        {
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
