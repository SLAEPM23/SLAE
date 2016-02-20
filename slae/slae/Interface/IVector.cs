using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    public interface IVector : ICloneable
    {
        IVector multScalar(IVector vec, double v);
        IVector multScalar(double v, IVector vec);
        double multVector(IVector v1, IVector v2);
        IVector sumVector(IVector v1, IVector v2);
        IVector Add(IVector v2, double c);// v=v+cv2;
        double this[int i] { get; set; }
        double Norm { get; }
        int Size { get; }
        void Nullify();
    }
}

