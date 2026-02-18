using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Detection
{
    internal class averageStrategy : IDetectionStrategy
    {
        public Status Detection(int sensor, int determin = 0)
        {
            int value = Math.Abs(sensor - determin);

            if (value < AverageWarningNum)
                return Status.Normal;
            else if (value < AverageCriticalNum)
                return Status.Warning;
            return Status.Critical;
        }

        readonly int AverageWarningNum = 10;

        readonly int AverageCriticalNum = 20;

    }

}
