using _260217.Observer;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Notification
{
    internal class NotificationStrategyManager
    {
        // デフォルトはコンソール通知
        private INotificationStrategy _strategy = new ConsoleNotification();

        public NotificationStrategyManager(){ }

        /// <summary>
        /// 通知の法法を選択する為のメソッド
        /// </summary>
        public void SelectStrategy()
        {
            // 利用可能な通知方法を表示して選択させる
            Console.WriteLine("=== 通知方法を選択してください ===");
            for (int i = 0; i < _strategies.Count; i++) Console.WriteLine($"{i + 1}. {_strategies[i].Name}");

            // ユーザーの入力を受け取って、対応する通知方法を選択する
            Console.Write("番号を入力: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                // 入力が有効な番号であれば、対応する通知方法を選択する
                if (choice >= 1 && choice <= _strategies.Count)
                {
                    // 選択された通知方法のインスタンスを作成して、設定する
                    var selectedType = _strategies[choice - 1];
                    var instance = (INotificationStrategy)Activator.CreateInstance(selectedType)!;
                    _strategy = instance;
                    Console.WriteLine($" → {_strategy.GetType().Name} に切り替えました。");
                }
                else Console.WriteLine("無効な番号です。");
            }
        }


        public void GetHandle(object? sender, StatusChangedEventArgs e) 
            => _strategy.Notify(sender, e);


        public void SetStrategy(INotificationStrategy strategy)
        {
            if (_strategies.Contains(strategy.GetType())) _strategy = strategy;
        }

        private readonly List<Type> _strategies = new()
        {
            typeof(EmailNotification),
            typeof(SlackNotification),
            typeof(ConsoleNotification),
        };


    }
}
