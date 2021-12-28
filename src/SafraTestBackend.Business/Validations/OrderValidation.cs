using FluentValidation;
using SafraTestBackend.Domain.Entities;
using System;

namespace SafraTestBackend.Business.Validations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(s => s.Price)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");

            RuleFor(s => s.Quantity)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");

            RuleFor(s => s.Date)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");               

            RuleFor(s => s.ValueService)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");

            RuleFor(s => s.TaxService)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");

            RuleFor(s => s.OrderType)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");

            RuleFor(s => s.StocksId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");

        }        
    }
}
