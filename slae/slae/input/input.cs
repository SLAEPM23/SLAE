using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    class Input
    {
        string path;
        public void ReadFromFile(out RowColumnSparseMatrix A, out Vector b, out Vector x_init)
        {
//          Не хватает проверки path
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
                double[] au = new double[m];
                double[] d = new double[n];
                double[] rightPart = new double[n];
                double[] x0 = new double[n];
                long offset = 2;

                for (int i = 0; i < n + 1; i++, offset++)
                    ia[i] = int.Parse(st[offset]);
                for (int i = 0; i < m; i++, offset++)
                    ja[i] = int.Parse(st[offset]);
                if (ia[0] != 0)
                {
                    for (int i = 0; i < n + 1; i++)
                        ia[i]--;
                        
                    for (int i = 0; i < m; i++)
                        ja[i]--;
                }

                for (int i = 0; i < m; i++,offset++)
                    al[i] = double.Parse(st[offset]);

                for (int i = 0; i < m; i++, offset++)
                    au[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++,offset++)
                    d[i] = double.Parse(st[offset]);

                for (int i = 0; i <  n; i++,offset++)
                    rightPart[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++, offset++)
                    x0[i] = double.Parse(st[offset]);
                
                A = new RowColumnSparseMatrix(n, ia, ja, al, au, d);
                b = new Vector(rightPart);
                x_init = new Vector(x0);
            }
        }
        public Input(string file)
        {
            path = file;
        }
    }
}
