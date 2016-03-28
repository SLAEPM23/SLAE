using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class LOS : Solver
    {
        public LOS(int _maxIteration = 10000, double _minResidual = 1E-16)
        {
            maxIteration = _maxIteration;
            minResidual = _minResidual;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {
            IVector result = new Vector(b.Size);
            IVector r = new Vector(b.Size);
            IVector p = new Vector(b.Size);
            IVector z = new Vector(b.Size);
            double alpha, betta;
            double p_scal;

            r.Equalize(b);
            result.Equalize(x0);
            r.Add(MatrixAssistant.multMatrixVector(A, result), -1);
            z.Equalize(r);
            p.Equalize(MatrixAssistant.multMatrixVector(A, z));
            p_scal = VectorAssistant.multVector(p, p);
            residual = VectorAssistant.multVector(r, r);

            for (iteration = 1; iteration <= maxIteration && residual > minResidual; iteration++)
            {
                alpha = VectorAssistant.multVector(p, r) / p_scal;
                result.Add(z, alpha);
                r.Add(p, -alpha);
                betta = -VectorAssistant.multVector(p, MatrixAssistant.multMatrixVector(A, r)) / p_scal;
                z = VectorAssistant.multScalar(betta, z);
                z.Add(r, 1);
                p = VectorAssistant.multScalar(betta, p);
                p.Add(MatrixAssistant.multMatrixVector(A, r), 1);
                
                    residual -= alpha * alpha * p_scal;
                if (residual < 0)           //она всё равно отрицательная
                    {
                        residual += alpha * alpha * p_scal;
                        return result;
                    }
                    if (alpha * alpha * p_scal < residual * 10E-5)
                        return result;
                    p_scal = VectorAssistant.multVector(p, p);
                    

                Debugger.DebugSolver(iteration, residual, result);
            }
            return result;
        }
    }
}
