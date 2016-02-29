using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slae.Interface;

namespace slae
{
    class Jacobi : Solver
    {
        private double relaxation
        {
            get { return relaxation; }
            set { relaxation = value; } 
        }
        public Jacobi()
        {
            relaxation = 1;
            maxIteration = 1000;
            minResidual = 10e-4;
            residual = 2*minResidual;
        }
        public Jacobi(double _relaxation, int _maxIteration, double _minResidual)
        {
            relaxation = _relaxation;
            maxIteration = _maxIteration;
            minResidual = _minResidual;
            residual = 2*minResidual;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {
            IVector result = new Vector(b.Size);
            IVector difference = new Vector(b.Size);//f-Ax
            double residual1, residual2;
            residual1 = b.Norm;
            result.Equalize(x0);
            difference.Equalize(b);
            difference.Add(MatrixAssistant.multMatrixVector(A, result), -1);

            for (iteration = 0; iteration < maxIteration && residual > minResidual; iteration++)
            {
                for (int i = 0; i < b.Size; i++)
                {
                    difference[i] = difference[i] / A.Diagonal[i];
                }
                result.Add(difference, relaxation);
                difference.Equalize(b);
                difference.Add(MatrixAssistant.multMatrixVector(A, result), -1);
                residual2 = difference.Norm;
                residual = residual2 / residual1;

            }

            return result;
        }
    }
}
