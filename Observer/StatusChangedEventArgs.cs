using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Observer
{
    internal class StatusChangedEventArgs : EventArgs
    {
        public string Name { get; }
        public Status Status { get; }

        public IState State { get; }    

        public StatusChangedEventArgs(string name, Status status,IState state)
        {
            Name = name;
            Status = status;
            State = state;
        }
    }
}
