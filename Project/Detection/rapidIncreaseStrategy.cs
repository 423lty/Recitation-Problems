using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Detection
{
    internal class rapidIncreaseStrategy : IDetectionStrategy
    {
        public Status Detection(int sensor, int determin = 0)
        {
            if (determin == 0) return Status.Normal;

            int value = Math.Abs(sensor - determin);

            if (value < RapidIncreaseWarningNum)
                return Status.Normal;
            else if (value < RapidIncreaseCriticalNum)
                return Status.Warning;
            return Status.Critical;
        }

        readonly int RapidIncreaseWarningNum = 10;

        readonly int RapidIncreaseCriticalNum = 20;

    }
}
