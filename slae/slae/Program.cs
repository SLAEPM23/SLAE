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
            Form1 Forma = new Form1();
            Application.Run(Forma);

            string MethodKeeping = Forma.meth_keep;//метод хранения
            string MethodSolving = Forma.meth_solv;//метод решения
            string Path = Forma.path;//файл с исходными данными

            RowColumnSparseMatrix Matrix;
            Vector Rp;

            Input.input Inp = new Input.input(Path);
            Inp.ReadFromFile(out Matrix, out Rp);
        }
    }
}
