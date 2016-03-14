using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using slae.Interface;

namespace slae
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IterationMax.Text = Convert.ToString(10000);
            ResidualMin.Text = Convert.ToString(1E-16);
            Relaxation.Text = Convert.ToString(1);
            methodSolver.SelectedIndex = 0;
            matrixFormat.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            if (path.ShowDialog() == DialogResult.OK)
                fileName.Text = path.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IMatrix A;
            Vector b;
            Vector x0;

            FileManager fileManager = new FileManager(fileName.Text);

            switch (matrixFormat.SelectedIndex)
            {
                case 0: fileManager.ReadFromFileDense(out A, out b, out x0);
                    break;
                case 1: fileManager.ReadFromFile(out A, out b, out x0);
                    break;
                case 2: fileManager.ReadFromFileProfile(out A, out b, out x0);
                    break;
                default: throw new Exception("Формат не выбран");
            }
            
            
            Solver solver;

            switch(methodSolver.SelectedIndex)
            {
                case 0:
                    solver = new Jacobi(Convert.ToDouble(Relaxation.Text), 
                                        Convert.ToInt16(IterationMax.Text),
                                        Convert.ToDouble(ResidualMin.Text));
                    break;
                case 1:
                    solver = new ConjugateGradient(Convert.ToInt16(IterationMax.Text),
                                                   Convert.ToDouble(ResidualMin.Text));
                    break;
                case 2:
                    solver = new GaussZeidel(Convert.ToDouble(Relaxation.Text),
                                        Convert.ToInt16(IterationMax.Text),
                                        Convert.ToDouble(ResidualMin.Text));
                    break;
                default:
                    throw new Exception("Метод не выбран"); 
            }
             
            Vector solution = (Vector)solver.Solve(A, b, x0);

            string result = string.Empty;
            for (int i = 0; i < solution.Size; i++)
                result += Convert.ToString(solution[i]) + "\n";

            MessageBox.Show("Вектор решения: \n" + result + "\n" + "Количество итераций: " + Convert.ToString(solver.iteration) + "\n" + "Невязка: " + Convert.ToString(solver.residual), "РЕЗУЛЬТАТЫ РЕШЕНИЯ");
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (methodSolver.SelectedIndex)
            {
                case 0:
                    Relaxation.Visible = true;
                    label4.Text = " - параметр релаксации(0<w<=1)";
                    label4.Visible = true;
                    break;
                case 2:
                    Relaxation.Visible = true;
                    label4.Text = " - параметр релаксации(0<w<2)";
                    label4.Visible = true;
                    break;
                default:
                    Relaxation.Visible = false;
                    label4.Visible = false;
                    break;
            }
        }

        private void matrixFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (matrixFormat.SelectedIndex)
            {
                case 0:
                    label7.Text = "n A";
                    break;
                case 1:
                    label7.Text = "n m ia ja al au di rp x0";
                    break;
                case 2:
                    label7.Text = "n ial iau al au di rp x0";
                    break;
                    
            }
        }
    }
}
