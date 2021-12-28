﻿using SafraTestBackend.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace SafraTestBackend.Business.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HaveNotifications()
        {
            return _notifications.Any();
        }

    }
}