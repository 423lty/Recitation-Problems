using _260217.Notification;
using _260217.Observer;
using _260217.Project.Observer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.State
{
    internal class StatusManager
    {
        public StatusManager(string sensorName)
        {
            _sensorName = sensorName;
            SetStatus(Status.Normal);

        }

        /// イベントを発火させる為のイベントハンドラー
        public event EventHandler<StatusChangedEventArgs>? OnStatusChanged;


        /// <summary>
        /// State パターンの状態を変化させる為のメソッド
        /// </summary>
        private void Change()
        {
            switch (Status)
            {
                case Status.Normal:
                    Status = Status.Normal;
                    State = new NormalState();
                    break;
                case Status.Warning:
                    Status = Status.Warning;
                    State = new WarningState();
                    break;
                case Status.Critical:
                    Status = Status.Critical;
                    State = new CriticalState();
                    break;
            }
        }

        /// <summary>
        /// 状態を変化させる為のメソッド
        /// </summary>
        /// <param name="status">次の状態</param>
        public void SetStatus(Status status)
        {
            //　状態が変化しない場合はスキップ
            if (Status == status) return;

            // 状態が変化した場合はイベントを発火させる
            Status = status;
            Change();
            OnStatusChanged?.Invoke(this, new StatusChangedEventArgs(_sensorName, Status, State!));
        }

        public Status Status { get; private set; }
    
        public IState? State { get; private set; } 

        private string _sensorName;

    }
}
