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
        public int maxIteration   { get; set; }
        public double minResidual { get; set; }
        public int iteration      { get; protected set; }
        public double residual    { get; protected set; }
        protected double EPS_NULL   { get; set; }
        public abstract IVector Solve(IMatrix A, IVector b, IVector x0);
    }
}