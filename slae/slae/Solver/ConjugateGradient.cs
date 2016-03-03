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
        public ConjugateGradient()
        {
            maxIteration = 1000;
            minResidual = 1E-4;
            residual = 2 * minResidual;
            EPS_NULL = 1E-8;
        }
        public ConjugateGradient(int _maxIteration, double _minResidual)
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
//          Check errors
            double z_scalar_mult, r_scalar_mult;
            double norm;

            norm = b.Norm;
            if (norm < EPS_NULL)
            {
                x.Nullify();
                return x;
            }

            x.Equalize(x0);
            r.Equalize(b);
            r.Add(MatrixAssistant.multMatrixVector(A,x),-1);
            z.Equalize(r);

            for (iteration = 0; iteration < maxIteration && residual > minResidual; iteration++ )
            {
                z_scalar_mult = VectorAssistant.multVector(z, z);
                if (Math.Abs(z_scalar_mult) < EPS_NULL)   throw new Exception("Divide by NULL in CG_solve:  (z,z)");
                r_scalar_mult = VectorAssistant.multVector(r, r);
                if (Math.Abs(r_scalar_mult) < EPS_NULL)   throw new Exception("Divide by NULL in CG_solver: (r,r)");
                alpha = r_scalar_mult / z_scalar_mult;
                x.Add(z,alpha);
                r.Add(MatrixAssistant.multMatrixVector(A,z), -alpha);
                betta = VectorAssistant.multVector(r, r) / r_scalar_mult;
                z.Add(z, betta);
                residual = r.Norm / norm;
            }
            return x;
        }
    }
}
