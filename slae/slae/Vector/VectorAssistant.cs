using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    public static class VectorAssistant
    {
        public static Interface.IVector multScalar(Interface.IVector vec, double v) //res = vec*v
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] *= v;
            }
            return vec;
        }
        public static Interface.IVector multScalar(double v, Interface.IVector vec) //res = vec*v
        {
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] *= v;
            }
            return vec;
        }
        public static double multVector(Interface.IVector v1, Interface.IVector v2) //res = v1*v2 scalar multiplication
        {
            double result = 0;
            for (int i = 0; i < v1.Size; i++)
            {
                result += v1[i] * v2[i];
            }
            return result;
        }
        public static Interface.IVector sumVector(Interface.IVector v1, Interface.IVector v2) // vres = v1+v2
        {
            Interface.IVector result = v1.Clone() as Interface.IVector;
            result.Nullify();
            for (int i = 0; i < v1.Size; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }
        public static Interface.IVector Add(Interface.IVector v1, Interface.IVector v2, double c) // vres =v1+cv2;
        {
            Vector result = new Vector(v1.Size);
            for (int i = 0; i < v2.Size; i++)
            {
                v1[i] += v2[i] * c;
            }
            return result;
        }
    }
}
