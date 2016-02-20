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
            for (int i = 0; i < size; i++)
            {
                v[i] = 0;
            }
        }

        public Interface.IVector multScalar(Interface.IVector vec, double v)
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] *= v;
            }
            return vec;
        }
        public Interface.IVector multScalar(double v, Interface.IVector vec)
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] *= v;
            }
            return vec;
        }
        public double multVector(Interface.IVector v1, Interface.IVector v2)
        {
            double result = 0;
            for (int i = 0; i < v1.Size; i++) 
            {
                result += v1[i] * v2[i];
            }
            return result;
        }
        public Interface.IVector sumVector(Interface.IVector v1, Interface.IVector v2)
        {
            Interface.IVector result = v1.Clone() as Interface.IVector;
            result.Nullify();
            for (int i = 0; i < v1.Size; i++)
            {
                result[i] = v1[i] * v2[i];
            }
            return result;
        }
        public Interface.IVector Add(Interface.IVector v2, double c)// v=v+cv2;
        {
            for (int i = 0; i < v2.Size; i++)
            {
                v2[i] = v2[i] + c;
            }
            return v2;
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
    }
}


