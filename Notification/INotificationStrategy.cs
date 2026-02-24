using _260217.Observer;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Notification
{
    interface INotificationStrategy
    {
        void Notify(object? sender, StatusChangedEventArgs e);
    }
}
