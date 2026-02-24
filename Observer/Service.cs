using _260217.Notification;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Observer
{
    internal class Service
    {
        public void Subscribe(StatusManager manager)
        {
            manager.OnStatusChanged += _notificationManager.GetHandle;
        }

        public void SubscribeUpdate(StatusManager manager)
        {
            manager.OnStatusChanged -= _notificationManager.GetHandle;
            _notificationManager.SelectStrategy();
            manager.OnStatusChanged += _notificationManager.GetHandle;
        }



        private NotificationStrategyManager _notificationManager = new();

    }
}
