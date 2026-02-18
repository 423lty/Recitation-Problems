using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.State
{
    internal class WarningState: IState
    {
        public string Log()
          =>  "警告";
    }
}
