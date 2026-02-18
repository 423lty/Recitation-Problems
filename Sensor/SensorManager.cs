using _260217.Project.Decorator;
using _260217.Project.Detection;
using _260217.Project.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Sensor
{
    internal class SensorManager
    {
        public SensorManager()
        {
            foreach (var item in _sensorTypes.Keys)
            {
                _sensorsDictionary.Add(item, new Sensor(item, _sensorTypes[item]));
                ChangeSensorCheckStrategy(item, new averageStrategy());
                _service.Subscribe(_sensorsDictionary[item].StatusManager);
                _sensorsDictionary[item].AddDecorator<NoiseFilterDecorator>();
            }
        }

        /// <summary>
        /// 格納しているデータの更新を行う為のメソッド
        /// </summary>
        public void Update()
        {
            foreach (var sensor in _sensorsDictionary.Values)
            {
                if (sensor is null) continue;
                sensor.StatusCheck(GetDetermin(sensor.DetectionStrategy.GetDetectionStrategy()));   
            }
        }

        /// <summary>
        /// Sensorの検知戦略を変更する為のメソッド
        /// </summary>
        /// <param name="sensorName"></param>
        /// <param name="strategy">戦略名</param>
        public void ChangeSensorCheckStrategy(string sensorName, IDetectionStrategy strategy)
        {
            if (_sensorsDictionary.ContainsKey(sensorName))
                _sensorsDictionary[sensorName].DetectionStrategy.Switch(strategy);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var sensor in _sensorsDictionary.Values)
            {
                if (sensor is null) continue;
                result += sensor.ToString() + "\n";
            }

            return result;
        }

        private int GetDetermin(IDetectionStrategy _strategy)
        {
            if (_strategy.GetType() == typeof(averageStrategy))
                return _sensorsDictionary.Values.Sum(x => x.Value) / _sensorsDictionary.Values.Count;
            else if (_strategy.GetType() == typeof(rapidIncreaseStrategy))
                return 0;

            return 0;
        }

        private Dictionary<string, Tuple<int, int>> _sensorTypes = new(){
            {"temperature",Tuple.Create(0,120)},
            {"humidity",Tuple.Create(0,100)},
            {"pressure",Tuple.Create(0,200)},
        };


        private Dictionary<string,Sensor> _sensorsDictionary = new();

        private Service _service = new ();
    }
}
