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
            set;
            get;
        }
        public double minResidual
        {
            set;
            get;
        }
        public int iteration
        {
            get;
            protected set;
        }
        public double residual
        {
            get;
            protected set;
        }
        public abstract IVector Solve(IMatrix A, IVector b, IVector x0);
    }
}