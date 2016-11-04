using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public  class ErrorLgging
    {
        private const string FileName = @"DataFiles\log.txt";

        public  void LogErrors(string errorMessage)
        {
            
            using (StreamWriter sw = new StreamWriter(FileName, true))
            {
                sw.WriteLine($"{DateTime.Now} - {errorMessage}");
                sw.Close();
            }
            
        }
    }
}
