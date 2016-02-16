using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    interface IVector : ICloneable
    {
        //static IVector operator (IVector vec, double v);
        static IVector operator *(double vec, IVector v);
        static double operator *(IVector v1, IVector v2);
        static IVector operator +(IVector v1, IVector v2);
        IVector Add(IVector v2, double c);// v=v+cv2;
        double this[int i] { get; set; }
        double Norm { get; }
        int Size { get; }
        void Nullify();
    }
}

