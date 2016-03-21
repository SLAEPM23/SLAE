using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class FileManager
    {
        string path;
        public void ReadFromFile(out IMatrix A, out Vector b, out Vector x_init)
        {
//          Не хватает проверки path
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                var st = file.ReadToEnd().Split(new char[] { '\n', ' ', '\t', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
                int n, m;
                if (!int.TryParse(st[0], out n))
                    throw new Exception("Bad file format");
                n = int.Parse(st[0]);

                int[] ia = new int[n + 1];
                
                double[] d = new double[n];
                double[] rightPart = new double[n];
                double[] x0 = new double[n];
                long offset = 1;

                for (int i = 0; i < n + 1; i++, offset++)
                    ia[i] = int.Parse(st[offset]);
                m = ia[n] - 1;
                int[] ja = new int[m];
                double[] al = new double[m];
                double[] au = new double[m];
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

        public void ReadFromFileDense(out IMatrix A, out Vector b, out Vector x_init)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                var st = file.ReadToEnd().Split(new char[] { '\n', ' ', '\t', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
                int n;
                if (!int.TryParse(st[0], out n))
                    throw new Exception("Bad file format");
                n = int.Parse(st[0]);
                double[,] a = new double[n,n];
                double[] rightPart = new double[n];
                double[] x0 = new double[n];
                long offset = 1;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++, offset++)
                        a[i,j] = double.Parse(st[offset]);
                
                for (int i = 0; i < n; i++, offset++)
                    rightPart[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++, offset++)
                    x0[i] = double.Parse(st[offset]);
                
                A = new DenseMatrix(n, a);
                b = new Vector(rightPart);
                x_init = new Vector(x0);
            }
        }

        public void ReadFromFileProfile(out IMatrix A, out Vector b, out Vector x_init)
        {
            //          Не хватает проверки path
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                var st = file.ReadToEnd().Split(new char[] { '\n', ' ', '\t', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
                int n;
                if (!int.TryParse(st[0], out n))
                    throw new Exception("Bad file format");
                n = int.Parse(st[0]);

                int[] ial = new int[n + 1];
                int[] iau = new int[n + 1];
                double[] d = new double[n];
                double[] rightPart = new double[n];
                double[] x0 = new double[n];
                long offset = 1;

                for (int i = 0; i < n + 1; i++, offset++)
                    ial[i] = int.Parse(st[offset]);
                for (int i = 0; i < n + 1; i++, offset++)
                    iau[i] = int.Parse(st[offset]);
                double[] al = new double[ial[n] - 1];
                double[] au = new double[iau[n] - 1];
                if (ial[0] != 0)
                {
                    for (int i = 0; i < n + 1; i++)
                        ial[i]--;

                    for (int i = 0; i < n + 1; i++)
                        iau[i]--;
                }
                
                for (int i = 0; i < ial[n]; i++, offset++)
                    al[i] = double.Parse(st[offset]);

                for (int i = 0; i < iau[n]; i++, offset++)
                    au[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++, offset++)
                    d[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++, offset++)
                    rightPart[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++, offset++)
                    x0[i] = double.Parse(st[offset]);

                A = new ProfileMatrix(n, ial, iau, al, au, d);
                b = new Vector(rightPart);
                x_init = new Vector(x0);
            }
        }

        public void ReadFromFileCoordinate(out IMatrix A, out Vector b, out Vector x_init)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                var st = file.ReadToEnd().Split(new char[] { '\n', ' ', '\t', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
                int n, m;
                if (!int.TryParse(st[0], out n))
                    throw new Exception("Bad file format");
                m = int.Parse(st[0]);
                double[] elem = new double[m];
                int[] iaddr = new int[m];
                int[] jaddr = new int[m];
                double[] rightPart = new double[n];
                double[] x0 = new double[n];
                long offset = 1;
                for (int i = 0; i < m; i++, offset++)
                {
                    iaddr[i] = int.Parse(st[offset]);
                    jaddr[i] = int.Parse(st[offset]);
                    elem[i] = double.Parse(st[offset]);
                }
                if (iaddr[0] != 0)
                {
                    for (int i = 0; i < m; i++)
                        iaddr[i]--;
                        
                    for (int i = 0; i < m; i++)
                        jaddr[i]--;
                }

                n = int.Parse(st[offset]);
                offset++;
                for (int i = 0; i < n; i++, offset++)
                    rightPart[i] = double.Parse(st[offset]);

                for (int i = 0; i < n; i++ /*offset++*/)
                    x0[i] = 0;/*double.Parse(st[offset]);*/

                A = new CoordinateMatrix(n, iaddr, jaddr, elem);
                b = new Vector(rightPart);
                x_init = new Vector(x0);
            }
        }
        public FileManager(string file)
        {
            path = file;
        }
    }
}
