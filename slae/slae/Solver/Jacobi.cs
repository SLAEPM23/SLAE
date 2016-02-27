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
        Jacobi()
        {
            relaxation = 1;
            maxIteration = 1000;
            minResidual = 10e-4;
        }
        Jacobi(double _relaxation, int _maxIteration, double _minResidual)
        {
            relaxation = _relaxation;
            maxIteration = _maxIteration;
            minResidual = _minResidual;
        }

        public override IVector Solve(IMatrix A, IVector b, IVector x0)
        {
            IVector result = new Vector(b.Size);
            IVector difference = new Vector(b.Size);//f-Ax
            iteration = 0;
            double residual1, residual2;
            residual1 = b.Norm;
            result.Nullify();
            difference.Equalize(b);
            difference.Add(MatrixAssistant.multMatrixVector(A, result), -1);
            do
            {
                iteration++;
                for (int i = 0; i < b.Size; i++)
                {
                    difference[i] = difference[i] / A.Diagonal[i];
                }
                result.Add(difference, relaxation);
                difference.Equalize(b);
                difference.Add(MatrixAssistant.multMatrixVector(A, result), -1);
                residual2 = difference.Norm;
                residual = residual2 / residual1;

            } while (iteration <= maxIteration && residual > minResidual);

            return result;
        }
    }
}
