using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    class Vector : Interface.IVector
    {
        double[] v;

        public Vector(double[] vec)
        {
            v = vec;
        }
        public Vector(int size)
        {
            v = new double[size];
            for (int i = 0; i < size; i++)
            {
                v[i] = 0;
            }
        }

        public void Add(Interface.IVector v2, double c)// v=v+cv2;
        {
            for (int i = 0; i < v2.Size; i++)
            {
                v[i] += v2[i]*c;
            }
        }

        public double this[int i]
        {
            get
            {
                return v[i];
            }
            set
            {
                v[i] = value;
            }
        }

        public double Norm
        {
            get
            {
                double N = 0;
                for (int i = 0; i < v.Length; i++)
                {
                    N += v[i] * v[i];
                }
                return Math.Sqrt(N);
            }
        }

        public int Size
        {
            get { return v.Length; }
        }

        public void Nullify()
        {
            for (int i = 0; i < v.Length; i++) v[i] = 0;
        }
        public object Clone()
        {
            return new Vector(v.Clone() as double[]);
        }
        public void Equalize(Interface.IVector v2)
        {
            for (int i=0; i<v2.Size; i++)
                v[i] = v2[i];
        }
    }
}


