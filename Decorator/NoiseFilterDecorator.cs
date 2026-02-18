using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Decorator
{
    internal class NoiseFilterDecorator: Decorator
    {
        public NoiseFilterDecorator(IProvider _provider) : base(_provider) { }

        public override int GetValue()
        {
            int value = _provider.GetValue();
            return value / NoiseFilter * NoiseFilter; 
        }

        private readonly int NoiseFilter = 5;
    }
}
