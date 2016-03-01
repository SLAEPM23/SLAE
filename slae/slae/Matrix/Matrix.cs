using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class RowColumnSparseMatrix : Interface.IMatrix
    {
        int[] ia;
        int[] ja;
        Vector al;
        Vector au;
        Vector di;
        int size;
        public RowColumnSparseMatrix(int sz, int[] _ia, int[] _ja,
            double[] _al, double[] _au, double[] _di)
        {
            size = sz;
            ia = _ia; ja = _ja; al = new Vector(_al); di = new Vector(_di);
            au = new Vector(_au);
        }

        public void Run(Interface.ProcessElement processor)
        {
            for (int i = 0; i < size; i++)
            {
                processor(i, i, di[i]);
                for (int jaddr = ia[i]; jaddr < ia[i + 1]; jaddr++)
                {
                    // processor(i, ja[jaddr], al[jaddr]);
                    processor(i, ja[jaddr], al[jaddr]);
                    processor(ja[jaddr], i, au[jaddr]);
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



    class DenseMatrix : Interface.IMatrix
    {
        double[,] a;
        int size;
        Vector di;
        public DenseMatrix(int sz, double[,] _a)
        {
            size = sz;
            a = new double[size, size];
            a = _a;
            di = new Vector(size);
            for (int i=0; i< size; i++)
            {
                di[i] = a[i, i];
            }
        }
        public IVector Diagonal
        {
            get
            {
                return di;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Run(ProcessElement processor)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    processor(i, j, a[i, j]);
        }
    }
}
