using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (System.IO.StreamReader file = new System.IO.StreamReader("input.txt"))
            {
                var st = file.ReadToEnd().Split(new char[] { '\n', ' ', '\t', ',' },
                StringSplitOptions.RemoveEmptyEntries);
                int n, m;
                if (!int.TryParse(st[0], out n))
                    throw new Exception("Bad file format");
                n = int.Parse(st[0]);
                m = int.Parse(st[1]);

                int[] ia = new int[n + 1];
                int[] ja = new int[m];
                double[] al = new double[m];
                double[] au = new double[m];
                double[] d = new double[n];


                for (int i = 2; i < n + 3; i++)
                    ia[i - 2] = int.Parse(st[i]);

                for (int i = n + 3; i < n + 3 + m; i++)
                    ja[i - n - 3] = int.Parse(st[i]);

                for (int i = n + 3 + m; i < n + 3 + 2*m; i++)
                    al[i - n - 3 - m] = int.Parse(st[i]);

                for (int i = n + 3 + 2*m; i < n + 3 + 3*m; i++)
                    au[i - n - 3 - 2*m] = int.Parse(st[i]);

                for (int i = n + 3 + 3 * m; i < 2*n + 3 + 3 * m; i++)
                    d[i - n - 3 - 3 * m] = int.Parse(st[i]);

            }
        }
    }
}
