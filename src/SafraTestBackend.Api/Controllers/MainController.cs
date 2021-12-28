using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Notifications;
using System.Linq;

namespace SafraTestBackend.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
                
        protected MainController(INotificator notificator)
        {
            _notificator = notificator;            
        }

        protected bool ValidOperation()
        {
            return !_notificator.HaveNotifications();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyErrors(errorMsg);
            }
        }

        protected void NotifyErrors(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}
