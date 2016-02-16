using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    interface ISolver
    {
        IVector Solve(IMatrix matrix, IVector rp, double MinResidual = 1e-20, int MaxIter = 10000);
        double Residual { get; }
        int Iter { get; }
    }
}
