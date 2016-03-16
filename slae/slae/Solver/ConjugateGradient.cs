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
        
        public ConjugateGradient(int _maxIteration = 1000, double _minResidual = 1E-16)
        {
            maxIteration = _maxIteration;
            minResidual = _minResidual;
            residual = 2 * minResidual;
            EPS_NULL = 10E-7;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {

            IVector x = new Vector(b.Size);
            IVector r = new Vector(b.Size);
            IVector z = new Vector(b.Size);

//          Check errors
            double Azz, rr;
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
            alpha = 1000;
            for (iteration = 0; iteration < maxIteration && residual > minResidual; iteration++ )
            {
                rr = VectorAssistant.multVector(r, r);
                var Az = MatrixAssistant.multMatrixVector(A, z);
                Azz = VectorAssistant.multVector(Az, z);
                if (Math.Abs(Azz) < EPS_NULL)   return x;
                alpha = rr / Azz;
                x.Add(z,alpha);
                r.Add(Az, -alpha);
                betta = VectorAssistant.multVector(r, r) / rr;
                z=VectorAssistant.multScalar(z,betta);
                z.Add(r, 1);
                residual = r.Norm / norm;                
            }
            return x;
        }
    }
}
