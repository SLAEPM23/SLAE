using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slae
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Form1 Forma = new Form1();
                Application.Run(Forma);

                string MethodKeeping = Forma.meth_keep;//метод хранения
                string MethodSolving = Forma.meth_solv;//метод решения
                string path = Forma.path;//файл с исходными данными

                RowColumnSparseMatrix A;
                Vector b;
                Vector x0;

                Input.input Inp = new Input.input(path);
                Inp.ReadFromFile(out A, out b, out x0);

                Solver solver = new Jacobi();
                Vector solution = (Vector)solver.Solve(A, b, x0);

                string result = string.Empty;
                for (int i = 0; i < solution.Size; i++)
                    result += Convert.ToString(solution[i]) + "\n";
                MessageBox.Show(result, "вектор решения");
                MessageBox.Show(Convert.ToString(solver.iteration), "итерация");
                MessageBox.Show(Convert.ToString(solver.residual), "невязка");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
