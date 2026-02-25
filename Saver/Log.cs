using _260217.Project.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Saver
{
    internal class Log
    {

        private readonly ILogSaver _logSaver;

        public Log(ILogSaver logSaver)
           => _logSaver = logSaver;

        public void Save(Sensor sensor)
        {
            var log = new SensorSaver
            {
                Id = sensor.ID,
                Name = sensor.Name,
                Value = sensor.Value,
                Status = sensor.StatusManager.Status,
                Timestamp = DateTime.Now
            };

            _logSaver.Save(log);
        }
    }
}
