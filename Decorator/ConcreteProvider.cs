using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Decorator
{
    internal class ConcreteProvider: IProvider
    {
        private Sensor.Sensor _sensor;

        public ConcreteProvider(Sensor.Sensor sensor)
            =>  _sensor = sensor;

        public int GetValue()
            => _sensor.Value;
    }
}
