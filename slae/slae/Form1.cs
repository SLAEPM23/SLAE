using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slae
{
    public partial class Form1 : Form
    {

        public string meth_keep;
        public string meth_solv;
        public string path;
        public Form1()
        {
            InitializeComponent();
            meth_keep = String.Empty;
            meth_solv = String.Empty;
            path = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            if (path.ShowDialog() == DialogResult.OK)
                this.fileName.Text = path.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            meth_keep = matrixFormat.Text;
            meth_solv = methodSolver.Text;
            path = fileName.Text;

            RowColumnSparseMatrix A;
            Vector b;
            Vector x0;

            Input.input Inp = new Input.input(path);
            Inp.ReadFromFile(out A, out b, out x0);
            Solver solver;
            switch(this.methodSolver.SelectedItem.ToString())
            {
                case "Якоби":
                    solver = new Jacobi();
                    break;
                case "МСГ":
                    solver = new ConjugateGradient();
                    break;
                default:
                    throw new Exception("Метод не выбран");
            }
             
            Vector solution = (Vector)solver.Solve(A, b, x0);

            string result = string.Empty;
            for (int i = 0; i < solution.Size; i++)
                result += Convert.ToString(solution[i]) + "\n";

            MessageBox.Show(result, "вектор решения");
            MessageBox.Show(Convert.ToString(solver.iteration), "итерация");
            MessageBox.Show(Convert.ToString(solver.residual), "невязка");

            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
