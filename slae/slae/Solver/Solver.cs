using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    abstract class Solver : ISolver
    {
        public int maxIteration
        {
            set { maxIteration = value; }
            get { return maxIteration; }
        }
        public double minResidual
        {
            set { minResidual = value; }
            get { return minResidual; }
        }
        public int iteration
        {
            get { return iteration; }
            protected set { iteration = value; }
        }
        public double residual
        {
            get { return residual; }
            protected set { residual = value; }
        }
        public abstract IVector Solve(IMatrix A, IVector b, IVector x0);
    }
}