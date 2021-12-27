﻿using FluentValidation;
using FrwkBootCampFidelidade.Dominio.PromotionContext.Entities;

namespace FrwkBootCampFidelidade.Dominio.PromotionContext.Validator
{
    public class PromotionValidator : AbstractValidator<Promotion>
    {
        public PromotionValidator()
        {
            RuleFor(x => x.Active)
                .NotNull()
                .NotEmpty()
                .WithMessage("Active é obrigatório.");

            RuleFor(x => x.DrugstoreId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("DrugstoreId é obrigatório.");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description é obrigatório.");

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
