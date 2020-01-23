using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Cursovaya
{
    class SaveManager
    {
        FileInfo file;
        StreamWriter sw;
        public SaveManager(string filename)
        {
            file = new FileInfo(filename+".txt");
            file.CreateText().Close();
            
        }
        public void WriteLine(string line)
        {
            sw  = file.AppendText();
            sw.WriteLine(line);
            sw.Close();
        }
        public void WriteObject(IWritableObject obj) {
            obj.Write(this);
        }

    }
}
