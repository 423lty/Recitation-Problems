using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Detection
{
    internal class thresholdStrategy: IDetectionStrategy
    {
        public Status Detection(int sensor, int determin = 0)
        {
            int value = Math.Abs(sensor / ThresholPercent * 100 - ThresholPercent);

            if (value < ThresholdWarningNum)
                return Status.Normal;
            else if (value < ThresholdCriticalNum)
                return Status.Warning;
            return Status.Critical;
        }

        readonly int ThresholdWarningNum = 10;

        readonly int ThresholdCriticalNum = 20;

        readonly int ThresholPercent = 80;

    }
}
