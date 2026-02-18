using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Detection
{
    internal class DetectionManager
    {
        private IDetectionStrategy? detectionStrategy = null;

        public DetectionManager(IDetectionStrategy detectionStrategy)
            => this.detectionStrategy = detectionStrategy;

        /// <summary>
        /// strategy パターンの戦略を切り替える為のメソッド
        /// </summary>
        /// <param name="detectionStrategy">次のパターン</param>
        public void Switch(IDetectionStrategy detectionStrategy)
        {
            if (detectionStrategy == null) return;
            this.detectionStrategy = detectionStrategy;
        }

        /// <summary>
        /// 現在の戦略を取得する為のメソッド
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IDetectionStrategy GetDetectionStrategy()
            => detectionStrategy ?? throw new Exception();

    }
}
