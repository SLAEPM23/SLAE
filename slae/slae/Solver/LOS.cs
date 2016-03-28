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
            IVector r= new Vector(b.Size);
            IVector p = new Vector(b.Size);
            IVector z = new Vector(b.Size);
            double alpha, betta;
            double p_scal;
            double residual_prev;//для проверки изменения невязки

            r.Equalize(b);
            result.Equalize(x0);
            r.Add(MatrixAssistant.multMatrixVector(A,result),-1);
            z.Equalize(r);
            p.Equalize(MatrixAssistant.multMatrixVector(A,z));
            residual = VectorAssistant.multVector(r, r);
            residual_prev = 2*residual;
            for (iteration = 1; iteration <= maxIteration && residual > minResidual && residual_prev - residual > minResidual; iteration++)
            {
                p_scal = VectorAssistant.multVector(p, p);
                alpha = VectorAssistant.multVector(p,r)/p_scal;
                result.Add(z,alpha);
                r.Add(p,-alpha);
                betta = -VectorAssistant.multVector(p, MatrixAssistant.multMatrixVector(A, r))/p_scal;
                z = VectorAssistant.multScalar(betta, z);
                z.Add(r,1);
                p = VectorAssistant.multScalar(betta, p);
                p.Add(MatrixAssistant.multMatrixVector(A,r),1);
                residual_prev = residual;
                residual -= alpha*alpha*p_scal;  

               if (residual < 0) residual = residual_prev; //ну не знаю что сделать (пока что), пусть будет так

                //Debugger.DebugSolver(iteration, residual, result);
            }
            return result;
        }
    }
}
