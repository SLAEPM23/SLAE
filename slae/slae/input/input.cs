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
        public void ReadFromFile(out RowColumnSparseMatrix A, out Vector b)
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
                //double[] au = new double[m];
                double[] d = new double[n];
                double[] rightPart = new double[n];
                long offset = 2;

                for (int i = 0; i < n + 1; i++, offset++)
                    ia[i] = int.Parse(st[offset]);

                for (int i = 0; i < m; i++, offset++)
                    ja[i] = int.Parse(st[offset]);

                for (int i = 0; i < m; i++,offset++)
                    al[i] = int.Parse(st[offset]);

                for (int i = 0; i < n; i++,offset++)
                    d[i] = int.Parse(st[offset]);

                for (int i = 0; i <  n; i++,offset++)
                    rightPart[i] = int.Parse(st[offset]);
                
                A = new RowColumnSparseMatrix(n, ia, ja, al, d);
                b = new Vector(rightPart);
            }
        }
        public input(string file)
        {
            path = file;
        }
    }
}
