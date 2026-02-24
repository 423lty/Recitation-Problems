using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Project.State
{
    internal class StatusManager
    {
        public StatusManager() 
          =>  SetStatus(Status.Normal);

        /// <summary>
        /// イベントを発火させる為のイベントハンドラー
        /// </summary>
        public event EventHandler<Status>? OnStatusChanged;
        public event EventHandler<IState>? OnStateChanged;

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
            OnStatusChanged?.Invoke(this, status);
            OnStateChanged?.Invoke(this, State!);
        }

        public Status Status { get; private set; }
    
        public IState? State { get; private set; } 



    }
}
