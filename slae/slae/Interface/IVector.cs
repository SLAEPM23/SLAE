using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    public interface IVector : ICloneable
    {
        void Add(IVector v2, double c);// v=v+cv2;
        double this[int i] { get; set; }
        double Norm { get; }
        int Size { get; }
        void Nullify();
        void Equalize(Interface.IVector v2);
    }
}

