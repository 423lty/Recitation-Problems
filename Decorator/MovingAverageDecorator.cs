using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Decorator
{
    internal class MovingAverageDecorator: Decorator
    {
        private Queue<int> _history = new();

        public MovingAverageDecorator(IProvider _provider)
            : base(_provider) { }

        public override int GetValue()
        {
            int value = _provider.GetValue();

            _history.Enqueue(value);
            if (_history.Count > 3)
                _history.Dequeue();

            return _history.Sum() / _history.Count;
        }
    }
}
