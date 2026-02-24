using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217
{
    internal class CheckSensorStatus
    {
        private static CheckSensorStatus Instance = null!;

        /// <summary>
        /// privateコンストラクタの定義
        /// </summary>
        private CheckSensorStatus() {}

        /// <summary>
        /// シングルトンを取得する為のメソッド   
        /// </summary>
        /// <returns></returns>
        public static CheckSensorStatus GetInstance()
        {
            if (Instance is null) Instance = new ();
            return Instance;
        }

        /// <summary>
        /// 追加されたときに実行する
        /// </summary>
        /// <param name="status"></param>
        public void Update(Status status)
        {
            // 状態の数をカウントし指定の数以下の場合リストに格納
            if (statusList.Count < MaxRemenberStatus) statusList.Add(status);
            else {
                // 状態の数が指定の数を超えた場合、最初の状態を削除してからリストに格納
                statusList.RemoveAt(0);
                statusList.Add(status);
            }

            // 型を取得して指定の場合指定の数を加算する
            var type = status switch
            {
                Status.Normal => typeof(NormalState),
                Status.Warning => typeof(WarningState),
                Status.Critical => typeof(CriticalState),
                _ => throw new ArgumentException("不正な状態です。")
            };

            // 状態の数をカウントする
            if (statesCounts.ContainsKey(type)) statesCounts[type]++;

            // 状態のリストを出力するs
            Log();
        }

        public void Log()
        {
            for (int i = 0; i < statusList.Count; i++)
            {
                Console.Write(statusList[i]);
                if (i < statusList.Count - 1)
                    Console.Write(" => ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 異常発生回数の出力
        /// </summary>
        public void Result()
        {
            // 状態の数を出力する
            foreach (var kvp in statesCounts) if (kvp.Key.Name != "NormalState") Console.WriteLine($"{kvp.Key.Name}: {kvp.Value}");
        }

        // 状態のリスト
        List<Status> statusList = new ();

        // 状態の数をカウントする
        Dictionary<Type, int> statesCounts = new()
        {
            { typeof(NormalState), 0 },
            { typeof(WarningState), 0 },
            { typeof(CriticalState), 0 },
        };

        // 覚えておく最大の数
        private readonly int MaxRemenberStatus = 5;
    }
}
