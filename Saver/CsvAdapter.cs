using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Saver
{
    internal class CsvAdapter:ILogSaver
    {
        private readonly LegacySaver _legacyLogger;
        private readonly string _filePath = "loTSensor.csv";

        public CsvAdapter(LegacySaver legacyLogger)
        {
            _legacyLogger = legacyLogger;

            // 初回のみヘッダー作成
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath,"ID,Name,Value,Status,Timestamp" + Environment.NewLine);
        }

        public void Save(SensorSaver log)
        {
            string line =
                $"{log.Id}," +
                $"{log.Name}," +
                $"{log.Value}," +
                $"{log.Status}," +
                $"{log.Timestamp:yyyy-MM-dd HH:mm:ss}";

            _legacyLogger.Write(_filePath,line);
        }
    }
}
