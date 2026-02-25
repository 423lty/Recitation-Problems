using _260217.Project.Decorator;
using _260217.Project.Detection;
using _260217.Project.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.Sensor
{
    internal class Sensor
    {
        public Sensor(string name, Tuple<int, int> range)
        {
            // プロパティの初期化
            Name = name;
            Value = new Random().Next(range.Item1, range.Item2);
            ID = Guid.NewGuid().ToString();
            GroupName = name;

            // オブジェクトの初期化
            StatusManager = new(name);
            DetectionStrategy = new DetectionManager(null!);
            provide = new ConcreteProvider(this);
        }

        /// <summary>
        /// 新規のDecoratorを追加する為のメソッド
        /// </summary>
        /// <typeparam name="T">IProviderの継承クラス</typeparam>
        /// <param name="args">すべての引数を受け取る</param>
        public void AddDecorator<T>(params object[] args) where T : IProvider
        {
            // 既存のProviderを引数に追加して、新しいProviderを生成する
            var objects = new object[] { provide }.Concat(args).ToArray();

            //　decoratorを追加して、新しいProviderを生成する
            provide = (IProvider)Activator.CreateInstance(typeof(T), objects)!;
        }

        /// <summary>
        /// 現在の状態を検知する為のメソッド
        /// </summary>
        /// <param name="determin"></param>
        public Status StatusCheck(int determin = 0)
        {
            Status result = DetectionStrategy.GetDetectionStrategy().Detection(provide.GetValue(), determin);

            StatusManager.SetStatus(result);

            return result;
        }
        public string? ID { get; }

        public string? Name { get; }

        public int Value { get; }

        public string GroupName { get;  }

        public StatusManager StatusManager { get; }

        public DetectionManager DetectionStrategy { get; }

        public override string ToString()
            => $"ID: {ID}, Name: {Name}, Value: {Value}, Status: {StatusManager.Status}";
    
        private IProvider provide;

    }
}
