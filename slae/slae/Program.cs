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
            //Solver s;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 Forma = new Form1();
            Application.Run(new Form1());

            RowColumnSparseMatrix Matrix;
            Vector Rp;

            Input.input Inp = new Input.input(Forma.textBox1.Text);
            Inp.ReadFromFile(out Matrix, out Rp);
        }
    }
}
