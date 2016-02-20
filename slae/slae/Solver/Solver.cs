using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    namespace Interface
    {
    class Solver : ISolver
    {
        int    Iter;
        double Residual;
        Method MethodSolver;
        delegate IVector Method(IMatrix matrix, IVector rp, double MinResidual, int MaxIter);

        Solver(string algorithm)
        {
            switch (algorithm)
            {
                case     "LU": MethodSolver = LU;  break;
                case    "LOS": MethodSolver = LOS; break;
                case "Jakobi": MethodSolver = Jacobi; break;
                default: break;
            }
        }
        int ISolver.Iter
        {
            get { return Iter; }
        }
        double ISolver.Residual
        {
            get { return Residual; }
        }
        IVector ISolver.Solve(IMatrix matrix, IVector rp, double MinResidual, int MaxIter)
        {
            return MethodSolver(matrix, rp, MinResidual, MaxIter);
        }

        IVector LOS(IMatrix matrix, IVector rp, double MinResidual, int MaxIter)
        {
            return rp;
        }
        IVector LU(IMatrix matrix, IVector rp, double MinResidual, int MaxIter)
        {
            return rp;
        }
        IVector Jacobi(IMatrix matrix, IVector rp, double MinResidual, int MaxIter)
        {
            IVector result = new Vector(); 
            return rp;
        }
    }
    }
}