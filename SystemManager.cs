using _260217.Project.Sensor;
using System;
using System.Collections.Generic;
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
            if (Instance == null)
                Instance = new SystemManager();
            return Instance;
        }

        /// <summary>
        /// SensorManagerのリスト を追加する為のメソッド
        /// </summary>
        public void Add()
        {
            SensorManagerList ??= new();
            SensorManagerList.Add(new SensorManager());
        }

        /// <summary>
        /// リスト内のデータの更新を行う為のメソッド
        /// </summary>
        public void Update(SensorManager manager)
        {
            Console.WriteLine("======================================");
            manager.Update();
            Console.WriteLine(manager.ToString());
        }

        public List<SensorManager> GetSensorManagers()
            => SensorManagerList ?? new ();

        // SensorManagerのリスト
        private List<SensorManager>? SensorManagerList = new();
    }
}
