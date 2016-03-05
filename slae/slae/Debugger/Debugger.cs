using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;
using System.IO;

namespace slae
{
    static class Debugger
    {
        public static string logFile { set; get; }

        public static void ClearFile()
        {
            File.WriteAllText(logFile,"");
        }
        public static void DebugSolver(int iteration, double residual, IVector x) 
        {
            string message = "i: " + Convert.ToString(iteration) + "\t" +
                             "r:" + Convert.ToString(residual) + "\t";
            message += "x:";
            for (int i = 0; i < x.Size; i++ )
                message += " " + Convert.ToString(x[i]);
            message += "\n";
            File.AppendAllText(logFile,message);
        }
    }
}
