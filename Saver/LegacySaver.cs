using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260217.Saver
{
    internal class LegacySaver
    {
        public void Write(string file,string text)
        {
            File.AppendAllText(file, text + Environment.NewLine);
        }
    }
}
