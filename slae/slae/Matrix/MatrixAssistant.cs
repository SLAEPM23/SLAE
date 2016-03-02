using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae
{
    public static class MatrixAssistant
    {
        public static Interface.IVector multMatrixVector(Interface.IMatrix matr, Interface.IVector vec)
        {
            Interface.IVector res = vec.Clone() as Interface.IVector;
            res.Nullify();
            matr.Run
                (
                (int i, int j, double el) => { res[i] += el * vec[j]; }
                );
            return res;
        }
    }
}
