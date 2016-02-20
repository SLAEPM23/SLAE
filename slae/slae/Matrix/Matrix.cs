using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    class RowColumnSparseMatrix : Interface.IMatrix
    {
        int[] ia;
        int[] ja;
        Vector al;
        Vector di;
        int size;
        RowColumnSparseMatrix(int sz, int[] _ia, int[] _ja,
            double[] _al, double[] _di)
        {
            size = sz;
            ia = _ia; ja = _ja; al = new Vector(_al); di = new Vector(_di);
        }

        public void Run(Interface.ProcessElement processor)
        {
            for (int i = 0; i < size; i++)
            {
                processor(i, i, di[i]);
                for (int jaddr = ia[i]; jaddr < ia[i + 1]; jaddr++)
                {
                    processor(i, ja[jaddr], al[jaddr]);
                    processor(ja[jaddr], i, al[jaddr]);
                }
            }
        }

        public Interface.IVector Diagonal
        {
            get { return di; }
        }

        public int Size
        {
            get { return size; }
        }
    }
}
