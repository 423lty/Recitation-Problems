using _260217.Observer;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Notification
{
    internal class ConsoleNotification : INotificationStrategy
    {
        public void Notify(object? sender, StatusChangedEventArgs e)
        {
            Console.WriteLine($"[Console] {e.Name} の状態が {e.Status} に変化しました。");
            Console.WriteLine($"{e.State.Log()}");

        }
    }
}
