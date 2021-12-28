using FluentValidation;
using FluentValidation.Results;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Notifications;
using SafraTestBackend.Domain.Entities;

namespace SafraTestBackend.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : EntityBase
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
