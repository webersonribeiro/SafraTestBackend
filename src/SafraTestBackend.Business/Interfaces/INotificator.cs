using SafraTestBackend.Business.Notifications;
using System.Collections.Generic;

namespace SafraTestBackend.Business.Interfaces
{
    public interface INotificator
    {
        bool HaveNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
