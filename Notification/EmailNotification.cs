using _260217.Observer;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Notification
{
    internal class EmailNotification:INotificationStrategy
    {
        public void Notify(object? sender, StatusChangedEventArgs e)
        {
            Console.WriteLine("=== Notification ===");
            Console.WriteLine("To: admin@example.com");
            Console.WriteLine($"Subject: センサー変更通知");
            Console.WriteLine($"Body: {e.Name} の状態が {e.Status} に変化しました。");
            Console.WriteLine($"Body: {e.State.Log()}");
            Console.WriteLine("=============================");
        }
    }
}
