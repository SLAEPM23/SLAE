using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slae.Interface
{
    public delegate void ProcessElement(int i, int j, double d);
    public interface IMatrix
    {
        void Run(ProcessElement processor);
        void RunRow(ProcessElement processor, int row);
        IVector Diagonal { get; }
        int Size { get; }
        double this[int i, int j]
        { get; }
    }

}

