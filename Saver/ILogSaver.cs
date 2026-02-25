using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Saver
{
    internal interface ILogSaver
    {
        void Save(SensorSaver saver);
    }
}
