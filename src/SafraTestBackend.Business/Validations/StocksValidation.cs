using FluentValidation;
using SafraTestBackend.Domain.Entities;

namespace SafraTestBackend.Business.Validations
{
    public class StocksValidation : AbstractValidator<Stocks>
    {
        public StocksValidation()
        {
            RuleFor(s => s.Symbol)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
                .Length(4, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
                .Length(4, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
