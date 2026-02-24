using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project
{
    internal class _2306010014下尾葉月
    {
        static readonly int LoopNum = 10;


        public static void Main(string[] args)
        {
            try
            {
                // 初期化
                var system = SystemManager.GetInstance();

                // 新しい要素を追加
                for (int i = 0; i < LoopNum; i++) system.Add();

                // データの更新
                system.GetSensorManagers().ForEach(m => system.Update(m));

                // 異常発生した回数の出力  
                system.Result();
            }
            catch (Exception ex){ Console.WriteLine($"エラーが発生しました: {ex.Message}"); }

        }
    }
}
