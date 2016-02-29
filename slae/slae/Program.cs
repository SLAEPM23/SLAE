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
                string Path = Forma.path;//файл с исходными данными

                RowColumnSparseMatrix Matrix;
                Vector Rp;
                Vector x0;

                Input.input Inp = new Input.input(Path);
                Inp.ReadFromFile(out Matrix, out Rp, out x0);


                Jacobi Solving = new Jacobi();
                Vector solution = (Vector)Solving.Solve(Matrix, Rp, x0);

                string resultic = string.Empty;
                for (int i = 0; i < solution.Size; i++)
                    resultic += Convert.ToString(solution[i]) + "\n";
                MessageBox.Show(resultic);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
