﻿namespace slae
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.methodSolver = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSolver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.matrixFormat = new System.Windows.Forms.ComboBox();
            this.viewFile = new System.Windows.Forms.Button();
            this.Relaxation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IterationMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ResidualMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите путь к файлу с входными данными";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(34, 197);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(344, 20);
            this.fileName.TabIndex = 1;
            // 
            // methodSolver
            // 
            this.methodSolver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodSolver.FormattingEnabled = true;
            this.methodSolver.Items.AddRange(new object[] {
            "Якоби",
            "МСГ"});
            this.methodSolver.Location = new System.Drawing.Point(293, 48);
            this.methodSolver.Name = "methodSolver";
            this.methodSolver.Size = new System.Drawing.Size(121, 21);
            this.methodSolver.TabIndex = 2;
            this.methodSolver.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите метод решения СЛАУ";
            // 
            // buttonSolver
            // 
            this.buttonSolver.Location = new System.Drawing.Point(362, 284);
            this.buttonSolver.Name = "buttonSolver";
            this.buttonSolver.Size = new System.Drawing.Size(127, 34);
            this.buttonSolver.TabIndex = 4;
            this.buttonSolver.Text = "Решить";
            this.buttonSolver.UseVisualStyleBackColor = true;
            this.buttonSolver.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите метод хранения матрицы";
            // 
            // matrixFormat
            // 
            this.matrixFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matrixFormat.FormattingEnabled = true;
            this.matrixFormat.Items.AddRange(new object[] {
            "Плотный",
            "Разр. строчно-столбцовый"});
            this.matrixFormat.Location = new System.Drawing.Point(37, 48);
            this.matrixFormat.Name = "matrixFormat";
            this.matrixFormat.Size = new System.Drawing.Size(171, 21);
            this.matrixFormat.TabIndex = 6;
            // 
            // viewFile
            // 
            this.viewFile.Location = new System.Drawing.Point(384, 192);
            this.viewFile.Name = "viewFile";
            this.viewFile.Size = new System.Drawing.Size(53, 28);
            this.viewFile.TabIndex = 7;
            this.viewFile.Text = "обзор";
            this.viewFile.UseVisualStyleBackColor = true;
            this.viewFile.Click += new System.EventHandler(this.button2_Click);
            // 
            // Relaxation
            // 
            this.Relaxation.Location = new System.Drawing.Point(293, 127);
            this.Relaxation.Name = "Relaxation";
            this.Relaxation.Size = new System.Drawing.Size(62, 20);
            this.Relaxation.TabIndex = 8;
            this.Relaxation.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = " - параметр релаксации";
            this.label4.Visible = false;
            // 
            // IterationMax
            // 
            this.IterationMax.Location = new System.Drawing.Point(293, 75);
            this.IterationMax.Name = "IterationMax";
            this.IterationMax.Size = new System.Drawing.Size(62, 20);
            this.IterationMax.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = " - максимальная итерация";
            // 
            // ResidualMin
            // 
            this.ResidualMin.Location = new System.Drawing.Point(293, 101);
            this.ResidualMin.Name = "ResidualMin";
            this.ResidualMin.Size = new System.Drawing.Size(62, 20);
            this.ResidualMin.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = " - минимальная невязка";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 330);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ResidualMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IterationMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Relaxation);
            this.Controls.Add(this.viewFile);
            this.Controls.Add(this.matrixFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.methodSolver);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SLAE_solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewFile;
        public System.Windows.Forms.ComboBox methodSolver;
        public System.Windows.Forms.ComboBox matrixFormat;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox Relaxation;
        public System.Windows.Forms.TextBox IterationMax;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox ResidualMin;
        private System.Windows.Forms.Label label6;
    }
}

