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
                this.textBox1.Text = path.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            meth_keep = comboBox2.Text;
            meth_solv = comboBox1.Text;
            path = textBox1.Text;
            this.Close();
        }
    }
}
