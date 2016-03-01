using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class ConjugateGradient : Solver
    {
        double alpha;
        double betta;
        ConjugateGradient()
        {
            maxIteration = 1000;
            minResidual = 1E-4;
            residual = 2 * minResidual;
            EPS_NULL = 1E-8;
        }
        ConjugateGradient(int _maxIteration, double _minResidual)
        {
            maxIteration = _maxIteration;
            minResidual = _minResidual;
            residual = 2 * minResidual;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {

            IVector x = new Vector(b.Size);
            IVector r = new Vector(b.Size);
            IVector z = new Vector(b.Size);
            IVector tmp = new Vector(b.Size);
            x.Equalize(x0);
            r.Equalize(b);
            r.Add(MatrixAssistant.multMatrixVector(A,x),-1);
            z.Equalize(r);
            for (iteration = 0; iteration < maxIteration && residual > minResidual; iteration++ )
            {
                if (Math.Abs(VectorAssistant.multVector(z, z)) < EPS_NULL)
                    throw new Exception("Devide by NULL in CG_solver:alpha");
                alpha = VectorAssistant.multVector(r, r) / VectorAssistant.multVector(z, z);
                x.Add(z,alpha);
                tmp.Equalize(r);
                tmp.Add(z, -alpha);
                if (Math.Abs(VectorAssistant.multVector(r, r)) < EPS_NULL)
                    throw new Exception("Devide by NULL in CG_solver:betta");
                betta = VectorAssistant.multVector(tmp, tmp) / VectorAssistant.multVector(r, r);
                r.Equalize(tmp);
                tmp.Equalize(r);
                tmp.Add(z,betta);
                z.Equalize(tmp);
                if (Math.Abs(b.Norm) < EPS_NULL)
                    throw new Exception("Devide by NULL in CG_solver:Norm");
                residual = r.Norm / b.Norm;
            }
            return x;
        }
    }
}
