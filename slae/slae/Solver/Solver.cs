using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    class Solver : Interface.ISolver
    {
        int    Iter;
        double Residual;
        Method MethodSolver;
        delegate Interface.IVector Method(Interface.IMatrix matrix, Interface.IVector rp, double MinResidual, int MaxIter);

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
        int Interface.ISolver.Iter
        {
            get { return Iter; }
        }
        double Interface.ISolver.Residual
        {
            get { return Residual; }
        }
        Interface.IVector Interface.ISolver.Solve(Interface.IMatrix matrix, Interface.IVector rp, double MinResidual, int MaxIter)
        {
            return rp;
        }

        Interface.IVector LOS(Interface.IMatrix matrix, Interface.IVector rp, double MinResidual, int MaxIter)
        {
            return rp;
        }
        Interface.IVector LU(Interface.IMatrix matrix, Interface.IVector rp, double MinResidual, int MaxIter)
        {
            return rp;
        }
        Interface.IVector Jacobi(Interface.IMatrix matrix, Interface.IVector rp, double MinResidual, int MaxIter)
        {
            return rp;
        }
    }
}