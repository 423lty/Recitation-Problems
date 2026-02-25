using _260217.Project.Decorator;
using _260217.Project.Detection;
using _260217.Project.Observer;
using _260217.Project.State;
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
            // センサーの情報初期化処理
            foreach (var item in _sensorTypes.Keys)
            {
                _sensorsDictionary.Add(item, new Sensor(item, _sensorTypes[item]));
                ChangeSensorCheckStrategy(item, new averageStrategy());
                _service.Subscribe(_sensorsDictionary[item].StatusManager);
                _sensorsDictionary[item].AddDecorator<NoiseFilterDecorator>();
            }

            // 一度だけ集計変数にグループごとの異常発生回数の初期化処理を行う
            if (GroupSensorresult is null)
            {
                GroupSensorresult = new ();
                
                foreach (var sensor in _sensorsDictionary.Values)
                    GroupSensorresult[sensor.GroupName] = 
                        Enum.GetValues<Status>().ToDictionary(s => s, s => 0);
            }

            // シングルトンのオブジェクトインスタンスを取得
            _checkSensorStatus = CheckSensorStatus.GetInstance();
        }

        /// <summary>
        /// 格納しているデータの更新を行う為のメソッド
        /// </summary>
        public List<Status> Update()
        {
            List<Status> statusList = new ();

            foreach (var sensor in _sensorsDictionary.Values)
            {
                // 通知の仕方を変更するかどうかの処理を実行
                _service.SubscribeUpdate(sensor.StatusManager);

                 // センサーがnullでないことを確認する。nullの場合はスキップする
                if (sensor is null) continue;

                // センサーの状態を検知する。センサーの状態はStatus型で返される
                var status = sensor.StatusCheck(GetDetermin(sensor.DetectionStrategy.GetDetectionStrategy()));

                // 異常な状態をリストに追加する。正常な状態は追加しない
                if (status is not Status.Normal) statusList.Add(status);
                
                // センサーの状態遷移を管理するオブジェクトの更新処理を行う
                _checkSensorStatus.Update(status);
            }

            // 異常な状態のリストを返す。異常な状態がない場合はnullを返す  
            return statusList.Count > 0 ? statusList : null!;
        }

        /// <summary>
        /// Sensorの検知戦略を変更する為のメソッド
        /// </summary>
        /// <param name="sensorName"></param>
        /// <param name="strategy">戦略名</param>
        public void ChangeSensorCheckStrategy(string sensorName, IDetectionStrategy strategy)
        {
            if (_sensorsDictionary.ContainsKey(sensorName)) _sensorsDictionary[sensorName].DetectionStrategy.Switch(strategy);
        }

        public Dictionary<string, Sensor> GetSensors()
            => _sensorsDictionary;

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
            if (_strategy.GetType() == typeof(averageStrategy)) return _sensorsDictionary.Values.Sum(x => x.Value) / _sensorsDictionary.Values.Count;
            else if (_strategy.GetType() == typeof(rapidIncreaseStrategy)) return 0;
            return 0;
        }

        private readonly Dictionary<string, Tuple<int, int>> _sensorTypes = new(){
            {"temperature",Tuple.Create(0,120)},
            {"humidity",Tuple.Create(0,100)},
            {"pressure",Tuple.Create(0,200)},
        };

        public static Dictionary<string,Dictionary<Status,int>>? GroupSensorresult = null;


        private Dictionary<string,Sensor> _sensorsDictionary = new();

        private Service _service = new ();

        private CheckSensorStatus _checkSensorStatus;

    }
}
