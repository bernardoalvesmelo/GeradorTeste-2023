namespace GeradorTeste.WinApp.ModuloTeste
{
    partial class TelaTestePdfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelMateria = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            labelDisciplina = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            labelTitulo = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            label2 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            btnGerar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelMateria.Location = new System.Drawing.Point(95, 78);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new System.Drawing.Size(58, 15);
            labelMateria.TabIndex = 11;
            labelMateria.Text = "[Matéria]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(34, 78);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 15);
            label6.TabIndex = 10;
            label6.Text = "Matéria:";
            // 
            // labelDisciplina
            // 
            labelDisciplina.AutoSize = true;
            labelDisciplina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDisciplina.Location = new System.Drawing.Point(95, 49);
            labelDisciplina.Name = "labelDisciplina";
            labelDisciplina.Size = new System.Drawing.Size(67, 15);
            labelDisciplina.TabIndex = 9;
            labelDisciplina.Text = "[Disciplina]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(23, 49);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Disciplina:";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitulo.Location = new System.Drawing.Point(95, 23);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(47, 15);
            labelTitulo.TabIndex = 7;
            labelTitulo.Text = "[Titulo]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(44, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 6;
            label1.Text = "Título:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(28, 119);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 12;
            label2.Text = "Diretório:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(96, 155);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(140, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Gerar Pdf do Gabarito";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(96, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(342, 23);
            textBox1.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(444, 116);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(90, 23);
            button1.TabIndex = 15;
            button1.Text = "Localizar";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancelar.Location = new System.Drawing.Point(459, 248);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(75, 45);
            btnCancelar.TabIndex = 43;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGerar
            // 
            btnGerar.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnGerar.Location = new System.Drawing.Point(378, 248);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new System.Drawing.Size(75, 45);
            btnGerar.TabIndex = 42;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            // 
            // TelaTestePdfForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(546, 317);
            Controls.Add(btnCancelar);
            Controls.Add(btnGerar);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(labelMateria);
            Controls.Add(label6);
            Controls.Add(labelDisciplina);
            Controls.Add(label4);
            Controls.Add(labelTitulo);
            Controls.Add(label1);
            Name = "TelaTestePdfForm";
            Text = "Gerar Pdf do Teste";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelMateria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGerar;
    }
}