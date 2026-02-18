using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Decorator
{
    internal class ScaleDecorator: Decorator
    {
        public ScaleDecorator(IProvider _provider, double scale = 1.1): base(_provider)
            => _scale = scale;

        public override int GetValue()
            => (int)(_provider.GetValue() * _scale);

        double _scale;
    }
}
