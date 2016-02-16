using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    interface IMatrix
    {
        delegate void ProcessElement(int i, int j, double d);
        void Run(ProcessElement processor);
        IVector Diagonal { get; }
        int Size { get; }
    }
}
