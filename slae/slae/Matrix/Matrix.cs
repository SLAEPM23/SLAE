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
                for (int jaddr = ia[i] ; jaddr < ia[i + 1] ; jaddr++)
                {
                    // processor(i, ja[jaddr], al[jaddr]);
                    processor(i, ja[jaddr] , al[jaddr]);
                    processor(ja[jaddr] , i, au[jaddr]);
                }
            }
        }

        //public double this[int i, int j]
        //{
        //    get
        //    {
        //        double res = 0;
        //        Run
        //       (
        //       (int irun, int jrun, double el) => { if (i == irun && j == jrun) res = el; }
        //       );
        //        return res;
        //    }
        //}


        public double this[int i,int j]
        {
            get
            {
                if (i == j) return di[i];
                if (i > j)
                {
                    for (int jaddr = ia[i]; jaddr < ia[i + 1]; jaddr++)
                    {

                        if (ja[jaddr] == j) return al[jaddr];
                        
                    }
                }
                if (i < j)
                { 
                    for (int jaddr = ia[j]; jaddr < ia[j + 1]; jaddr++)
                    {
                        if (ja[jaddr] == i) return au[jaddr];
                    }
                }
                return 0;

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

        public double this[int i, int j]
        {
            get
            {
                return a[i, j];
            }
        }

        public void Run(ProcessElement processor)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    processor(i, j, a[i, j]);
        }
    }

    class ProfileMatrix : Interface.IMatrix
    {
        int size;
        int[] ial;
        int[] iau;
        Vector al;
        Vector au;
        Vector di;
        public ProfileMatrix(int sz, int[] _ial, int[] _iau,
                        double[] _al, double[] _au, double[] _di)
        {
            size = sz;
            ial = _ial; iau = _iau; al = new Vector(_al);
            au = new Vector(_au); di = new Vector(_di);
            
        }

        public double this[int i, int j]
        {
            get
            {
                if (i == j) return di[i];
                if (i > j)
                {
                    int diff = 0;
                    for (int jaddr = ial[i]; jaddr < ial[i+1] ; jaddr++)
                    {
                        if (i - (ial[i + 1] - ial[i]) + diff == j) return al[jaddr];
                        diff++;
                    }
                }
                if (i < j)
                {
                    int diff = 0;
                    for (int jaddr = iau[j]; jaddr < iau[j + 1]; jaddr++)
                    {
                        if (j - (iau[j + 1] - iau[j]) + diff == i) return au[jaddr];
                        diff++;
                    }
                }
                return 0;

            }
        }

        public void Run(ProcessElement processor)
        {
            for (int i = 0; i < size; i++)
            {
                processor(i, i, di[i]);
                int diff = 0;
                for (int jaddr = ial[i]; jaddr < ial[i + 1]; jaddr++)
                {
                    processor(i, i - (ial[i + 1] - ial[i]) + diff, al[jaddr]);
                    diff++;
                }
                diff = 0;
                for (int jaddr = iau[i]; jaddr < iau[i + 1]; jaddr++)
                {
                    processor( i - (iau[i + 1] - iau[i]) + diff, i, au[jaddr]);
                    diff++;
                }
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


    }
}
