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
            manager.OnStatusChanged += InfoHandle;
            manager.OnStateChanged += LogHandle;
        }

        private void InfoHandle(object? sender, Status status)
        {
            Console.WriteLine($"状態が変化 → {status}");
        }

        private void LogHandle(object? sender, IState state)
        {
            Console.WriteLine($"{state.Log()}");
        }
    }
}
