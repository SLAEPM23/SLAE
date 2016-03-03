namespace slae
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите путь к файлу с входными данными";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(34, 132);
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
            this.methodSolver.Location = new System.Drawing.Point(316, 48);
            this.methodSolver.Name = "methodSolver";
            this.methodSolver.Size = new System.Drawing.Size(121, 21);
            this.methodSolver.TabIndex = 2;
            this.methodSolver.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите метод решения СЛАУ";
            // 
            // buttonSolver
            // 
            this.buttonSolver.Location = new System.Drawing.Point(353, 194);
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
            this.matrixFormat.Size = new System.Drawing.Size(121, 21);
            this.matrixFormat.TabIndex = 6;
            // 
            // viewFile
            // 
            this.viewFile.Location = new System.Drawing.Point(384, 127);
            this.viewFile.Name = "viewFile";
            this.viewFile.Size = new System.Drawing.Size(53, 28);
            this.viewFile.TabIndex = 7;
            this.viewFile.Text = "обзор";
            this.viewFile.UseVisualStyleBackColor = true;
            this.viewFile.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 240);
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
    }
}

