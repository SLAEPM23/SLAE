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
using System.IO;

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
                case 3: fileManager.ReadFromFileCoordinate(out A, out b, out x0);
                    break;
                default: throw new Exception("Формат не выбран");
            }
            string res_residual = "Невязка: ";
            
            
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
                case 3:
                    solver = new LOS(Convert.ToInt16(IterationMax.Text),
                                        Convert.ToDouble(ResidualMin.Text));
                    res_residual = "Квадрат нормы невязки: ";
                    break;
                default:
                    throw new Exception("Метод не выбран"); 
            }
             
            Vector solution = (Vector)solver.Solve(A, b, x0);

            string result = string.Empty;
            for (int i = 0; i < solution.Size; i++)
                result += Convert.ToString(solution[i]) + "\r\n";
            
            File.WriteAllText("result.txt", "");

            string FinalResult = "Вектор решения: \r\n" + result + "\r\n" + "Количество итераций: " + Convert.ToString(solver.iteration) + "\r\n" + res_residual + Convert.ToString(solver.residual);
            
            if (solution.Size <= 20)
                MessageBox.Show(FinalResult, "РЕЗУЛЬТАТЫ РЕШЕНИЯ");
            else
            {
                MessageBox.Show("Результаты решения в файле /SLAE/slae/slae/bin/Debug/result.txt");
                File.WriteAllText("result.txt", FinalResult);
            }

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
                case 3:
                    label6.Text = " - минимальный квадрат нормы невязки";
                    Relaxation.Visible = false;
                    label4.Visible = false;
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
                    label7.Text = "n A rp x0";
                    break;
                case 1:
                    label7.Text = "n ia ja al au di rp x0";
                    break;
                case 2:
                    label7.Text = "n ial iau al au di rp x0";
                    break;
                case 3:
                    label7.Text = "n m elem iaddr jaddr rp x0";
                    break;
            }
        }

        private void fileName_TextChanged(object sender, EventArgs e)
        {
            if (fileName.TextLength == 0)
            {
                viewMatrix.Enabled = false;
                viewMatrix.BackColor = Color.Red;
                buttonSolver.Enabled = false;
                buttonSolver.BackColor = Color.Red;
                dataGridView1.Visible = false;
                Size = new Size(640, 330);
            }
            else
                if (IterationMax.TextLength > 0
                && ResidualMin.TextLength > 0
                && Relaxation.TextLength > 0
                && fileName.TextLength > 0)
                {
                    viewMatrix.Enabled = true;
                    viewMatrix.BackColor = Color.Green;
                    buttonSolver.Enabled = true;
                    buttonSolver.BackColor = Color.Green;
                    dataGridView1.Visible = false;
                    Size = new Size(640, 330);
                }
        }

        private void Relaxation_TextChanged(object sender, EventArgs e)
        {
            if (Relaxation.TextLength == 0)
            {
                buttonSolver.Enabled = false;
                buttonSolver.BackColor = Color.Red;
                Relaxation.BackColor = Color.Red;
            }
            else
                if (IterationMax.TextLength > 0
                && ResidualMin.TextLength > 0
                && Relaxation.TextLength > 0
                && fileName.TextLength > 0)
                {
                    buttonSolver.Enabled = true;
                    buttonSolver.BackColor = Color.Green;
                    Relaxation.BackColor = Color.White;
                }
        }

        private void ResidualMin_TextChanged(object sender, EventArgs e)
        {
            if (ResidualMin.TextLength == 0)
            {
                buttonSolver.Enabled = false;
                buttonSolver.BackColor = Color.Red;
                ResidualMin.BackColor = Color.Red;
            }
            else
                if (IterationMax.TextLength > 0
                && ResidualMin.TextLength > 0
                && Relaxation.TextLength > 0
                && fileName.TextLength > 0)
                {
                    buttonSolver.Enabled = true;
                    buttonSolver.BackColor = Color.Green;
                    ResidualMin.BackColor = Color.White;
                }
        }

        private void IterationMax_TextChanged(object sender, EventArgs e)
        {
            if (IterationMax.TextLength == 0)
            {
                buttonSolver.Enabled = false;
                buttonSolver.BackColor = Color.Red;
                IterationMax.BackColor = Color.Red;
            }
            else
                if(IterationMax.TextLength > 0
                &&  ResidualMin.TextLength > 0
                &&  Relaxation.TextLength  > 0
                && fileName.TextLength > 0)
                {
                    buttonSolver.Enabled = true;
                    buttonSolver.BackColor = Color.Green;
                    IterationMax.BackColor = Color.White;
                }
        }

        private void viewMatrix_Click(object sender, EventArgs e)
        {
            if (viewMatrix.BackColor == Color.Green)
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
                    case 3: fileManager.ReadFromFileCoordinate(out A, out b, out x0);
                        break;
                    default: throw new Exception("Формат не выбран");
                }

                DataTable table = new DataTable();
                for (int i = 0; i < A.Size; i++)
                {
                    DataColumn col = new DataColumn((i + 1).ToString());
                    table.Columns.Add(col);
                }
                for (int i = 0; i < A.Size; i++)
                {
                    DataRow row = table.NewRow();
                    
                    for (int j = 0; j < A.Size; j++)
                    {
                        row[j] = A[i, j];
                    }
                    table.Rows.Add(row);
                }
                dataGridView1.DataSource = table;
                for (int i = 0; i < A.Size; i++)
                    dataGridView1.Rows[i].HeaderCell.Value = (i+1).ToString();
                dataGridView1.Visible = true;
                this.Size = new Size(640, 540);
                dataGridView1.Width = 620;
                dataGridView1.Height = 210;
                viewMatrix.BackColor = Color.White;
            }
            else
            {
                dataGridView1.Visible = false;
                this.Size = new Size(640, 330);
                viewMatrix.BackColor = Color.Green;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        //        dataGridView1.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();  
        }
    }
}
