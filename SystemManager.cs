using _260217.Project.Sensor;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project
{
    internal class SystemManager
    {

        private SystemManager() {}

        private static SystemManager? Instance { get; set; } = null;

        /// <summary>
        /// シングルトンを取得する為のメソッド
        /// </summary>
        /// <returns></returns>
        public static SystemManager GetInstance()
        {
            if (Instance == null) Instance = new SystemManager();
            return Instance;
        }

        /// <summary>
        /// SensorManagerのリスト を追加する為のメソッド
        /// </summary>
        public void Add(int i)
        {
            SensorManagerList ??= new();
            SensorManagerList.Add(new SensorManager(i));
        }

        /// <summary>
        /// リスト内のデータの更新を行う為のメソッド
        /// </summary>
        public void Update(SensorManager manager)
        {
            Console.WriteLine($"試行回数 {trialCount++}:======================================\n");
            manager.Update();
            Console.WriteLine(manager.ToString());
        }

        public void Result()
        {
            Console.WriteLine("異常発生回数 ======================================");
            _checkSensorStatus?.Result();
            DrawGroupSensorResult();
        }

        /// <summary>
        /// グループごとの集計を実行する
        /// </summary>
        private void AggregationGroupSensorResult()
        {
            // 総合のセンサーをしゅとく
            foreach(var sensorManager in SensorManagerList!)
            {
                foreach(var sensor in sensorManager.GetSensors().Values)
                {
                    // nullの場合はスキップする
                    if (sensor is null) continue;

                    // センサーの状態を取得,センサーのグループ名を取得して、センサーの状態をグループごとにカウントする
                    var status = sensor.StatusManager.Status;
                    SensorManager.GroupSensorresult![sensor.GroupName][status]++;
                }
            }
        }

        /// <summary>
        /// グループごとの集計を描画する
        /// </summary>
        private void DrawGroupSensorResult()
        {
            // データを集計する
            AggregationGroupSensorResult();

            Console.WriteLine("\n--- グループ別統計レポート ---");

            foreach (var group in SensorManager.GroupSensorresult!)
            {
                Console.WriteLine($"[グループ: {group.Key}]");
                Console.Write($"  状態:");
                int totalCount = group.Value.Values.Sum();
                int abnormalCount = 0;
                foreach (var status in group.Value)
                {
                    if (status.Key != Status.Normal) abnormalCount += status.Value;
                    Console.Write($"{status.Key}:[{status.Value}] ,");
                }
                double abnormalRate = totalCount == 0 ? 0 : (double)abnormalCount / totalCount * 100;
                Console.WriteLine($"\n  異常発生率: {abnormalRate} %");
            }
        }

        public List<SensorManager> GetSensorManagers()
            => SensorManagerList ?? new ();

        // SensorManagerのリスト
        private List<SensorManager>? SensorManagerList = new();

        // CheckSensorStatusのシングルトンの読み取り専用オブジェクトインスタンス
        private readonly CheckSensorStatus? _checkSensorStatus = CheckSensorStatus.GetInstance();

        // 試行回数をカウントするための変数
        private int trialCount = 1;
    }
}
