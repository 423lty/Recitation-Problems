using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Decorator
{
    internal abstract class Decorator:IProvider
    {
        public Decorator(IProvider _provider)
            => this._provider = _provider;

        public abstract int GetValue();
  
        protected readonly IProvider _provider;
    }
}
