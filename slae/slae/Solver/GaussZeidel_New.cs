using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class GaussZeidel_New : Solver
    {
        private double relaxation { get; set; }

        public GaussZeidel_New(double _relaxation = 1, int _maxIteration = 10000, double _minResidual = 1E-16)
        {
            relaxation = _relaxation;
            maxIteration = _maxIteration;
            minResidual = _minResidual;
            EPS_NULL = 1E-8;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {
            IVector x_prev= new Vector(b.Size);
            IVector result = new Vector(b.Size);
            IVector difference = new Vector(b.Size);//f-Ax

            double residual1, residual2;
            double residual_prev;//для проверки изменения невязки
            residual =1;
            residual1 = b.Norm;
            x_prev.Equalize(x0);
            
            
            for (int i = 0; i < b.Size; i++)
                if (Math.Abs(A.Diagonal[i]) < EPS_NULL)
                    throw new Exception("Divide by NULL in GaussZeidel_solver: diagonal");
            residual_prev = 2 * residual;

            for (iteration = 0; iteration < maxIteration && residual > minResidual && residual_prev > residual; iteration++)
            {
                difference.Equalize(b);
                difference.Add(MatrixAssistant.multMatrixUpperVector(A,x_prev),-1);
                for (int i = 0; i < b.Size; i++)
                {
                    double sum = 0;
                    IVector Lx = MatrixAssistant.multMatrixLowerVector(A, result, i);
                    for (int ii = 0; ii < Lx.Size; ii++)
                        sum += Lx[ii];
                    difference[i] -= sum;
                    result[i] = difference[i]/A.Diagonal[i];
                }
                difference.Equalize(b);
                difference.Add(MatrixAssistant.multMatrixVector(A, result), -1);
                residual2 = difference.Norm;
                residual_prev = residual;
                residual = residual2 / residual1;
                //Debugger.DebugSolver(iteration, residual, result);
                x_prev.Equalize(result);
            }

            return result;
        }
    }
}
