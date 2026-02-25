using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Saver
{
    internal class SensorSaver
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Value { get; set; }
        public Status Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
