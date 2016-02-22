using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace slae.inputtt
{
    class input
    {

        static void Main(string[] args)
        {

            using (StreamReader f = new StreamReader("input.txt"))
            {
                int n, m;
                string s;
                string[] sa;
                s = f.ReadLine();
                sa = s.Split(' ');
                n = Convert.ToInt32(sa[0]);
                m = Convert.ToInt32(sa[1]);

                int[] ia = new int[n + 1];
                int[] ja = new int[m];
                double[] al = new double[m];
                double[] au = new double[m];
                double[] d = new double[n];

                s = f.ReadLine();
                sa = s.Split(' ');
                for (int i = 0; i < n + 1; i++)
                    ia[i] = Convert.ToInt32(sa[i]);

                s = f.ReadLine();
                sa = s.Split(' ');
                for (int i = 0; i < m; i++)
                    ja[i] = Convert.ToInt32(sa[i]);

                s = f.ReadLine();
                sa = s.Split(' ');
                for (int i = 0; i < m; i++)
                    al[i] = Convert.ToInt32(sa[i]);

                s = f.ReadLine();
                sa = s.Split(' ');
                for (int i = 0; i < m; i++)
                    au[i] = Convert.ToInt32(sa[i]);

                s = f.ReadLine();
                sa = s.Split(' ');
                for (int i = 0; i < n; i++)
                    d[i] = Convert.ToInt32(sa[i]);


            }
        }
    }
}
