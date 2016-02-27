using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    interface ISolver
    {
        IVector Solve(IMatrix A, IVector b, IVector x0);
        double residual { get; }
        double minResidual { get; set; }
        int iteration { get; }
        int maxIteration { get; set; }
    }
}
