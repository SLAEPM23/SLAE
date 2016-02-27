using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Input
{
    class input
    {
        string path;
        public void ReadFromFile(out RowColumnSparseMatrix Matrix, out Vector Vec)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
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
                //double[] au = new double[m];
                double[] d = new double[n];
                double[] rp = new double[n];


                for (int i = 2; i < n + 3; i++)
                    ia[i - 2] = int.Parse(st[i]);

                for (int i = n + 3; i < n + 3 + m; i++)
                    ja[i - n - 3] = int.Parse(st[i]);

                for (int i = n + 3 + m; i < n + 3 + 2 * m; i++)
                    al[i - n - 3 - m] = int.Parse(st[i]);

                
                //тут нужно правильно вбить параметры в цикле для считки d и rp!!!
                for (int i = n + 3 + 2 * m; i < n + 3 + 3 * m; i++)
                    d[i - n - 3 - 2 * m] = int.Parse(st[i]);

                for (int i = n + 3 + 3 * m; i < 2 * n + 3 + 3 * m; i++)
                    rp[i - n - 3 - 3 * m] = int.Parse(st[i]);
                
                Matrix = new RowColumnSparseMatrix(n, ia, ja, al, d);
                Vec = new Vector(rp);
            }
        }
        public input(string file)
        {
            path = file;
        }
    }
}
