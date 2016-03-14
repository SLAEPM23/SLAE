using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class GaussZeidel : Solver
    {
        private double relaxation { get; set; }

        public GaussZeidel(double _relaxation = 1, int _maxIteration = 10000, double _minResidual = 1E-16)
        {
            relaxation = _relaxation;
            maxIteration = _maxIteration;
            minResidual = _minResidual;
            residual = 2*minResidual;
            EPS_NULL = 1E-8;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {
            IVector x_prev= new Vector(b.Size);
            IVector result = new Vector(b.Size);
            IVector difference = new Vector(b.Size);//f-Ax

            double residual1, residual2;
            residual1 = b.Norm;
            x_prev.Equalize(x0);
            
            
            for (int i = 0; i < b.Size; i++)
                if (Math.Abs(A.Diagonal[i]) < EPS_NULL)
                    throw new Exception("Divide by NULL in GaussZeidel_solver: diagonal");

            for (iteration = 0; iteration < maxIteration && residual > minResidual; iteration++)
            {
                difference.Equalize(b);
                //result.Nullify();
                for (int i = 0; i < b.Size; i++)
                {
                    for (int j = 0; j < i; j++)
                        difference[i] -= A[i,j]*result[j];
                    for (int j = i; j < b.Size; j++)
                    {
                        difference[i] -= A[i,j]*x_prev[j];
                    }
                    difference[i] *= (relaxation/A.Diagonal[i]);
                    result[i] = x_prev[i] + difference[i];
                }
                difference.Equalize(b);
                difference.Add(MatrixAssistant.multMatrixVector(A, result), -1);
                residual2 = difference.Norm;
                residual = residual2 / residual1;
                //Debugger.DebugSolver(iteration, residual, result);
                x_prev.Equalize(result);
            }

            return result;
        }
    }
}
