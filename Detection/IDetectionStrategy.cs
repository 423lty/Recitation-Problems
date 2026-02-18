using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Detection
{
    internal interface IDetectionStrategy
    {
        /// <summary>
        /// 状態を検出する為のメソッド
        /// </summary>
        /// <param name="sensor">センサーの温度</param>
        /// <param name="determin">検知する温度</param>
        /// <returns></returns>
        public Status Detection(int sensor, int determin = 0);
    }
}
