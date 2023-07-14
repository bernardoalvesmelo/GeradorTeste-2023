namespace GeradorTeste.WinApp.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaQuestaoForm));
            cmbMaterias = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cmbDisciplinas = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            txtEnunciado = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            listAlternativas = new System.Windows.Forms.CheckedListBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnRemover = new System.Windows.Forms.ToolStripButton();
            btnAdicionar = new System.Windows.Forms.Button();
            txtResposta = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            btnCancelar = new System.Windows.Forms.Button();
            btnGravar = new System.Windows.Forms.Button();
            txtId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            chkJaUtilizada = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbMaterias
            // 
            cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMaterias.FormattingEnabled = true;
            cmbMaterias.Location = new System.Drawing.Point(85, 73);
            cmbMaterias.Name = "cmbMaterias";
            cmbMaterias.Size = new System.Drawing.Size(217, 23);
            cmbMaterias.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(30, 76);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(50, 15);
            label4.TabIndex = 0;
            label4.Text = "Matéria:";
            // 
            // cmbDisciplinas
            // 
            cmbDisciplinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDisciplinas.FormattingEnabled = true;
            cmbDisciplinas.Location = new System.Drawing.Point(85, 44);
            cmbDisciplinas.Name = "cmbDisciplinas";
            cmbDisciplinas.Size = new System.Drawing.Size(217, 23);
            cmbDisciplinas.TabIndex = 2;
            cmbDisciplinas.SelectedIndexChanged += cmbDisciplinas_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(19, 48);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 15);
            label3.TabIndex = 0;
            label3.Text = "Disciplina:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new System.Drawing.Point(85, 135);
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.Size = new System.Drawing.Size(389, 44);
            txtEnunciado.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 152);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 15);
            label2.TabIndex = 0;
            label2.Text = "Enunciado:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listAlternativas);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Location = new System.Drawing.Point(18, 247);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(456, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // listAlternativas
            // 
            listAlternativas.CheckOnClick = true;
            listAlternativas.FormattingEnabled = true;
            listAlternativas.Location = new System.Drawing.Point(8, 70);
            listAlternativas.Name = "listAlternativas";
            listAlternativas.Size = new System.Drawing.Size(442, 166);
            listAlternativas.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnRemover });
            toolStrip1.Location = new System.Drawing.Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(450, 40);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnRemover
            // 
            btnRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            btnRemover.Image = (System.Drawing.Image)resources.GetObject("btnRemover.Image");
            btnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new System.Drawing.Size(58, 37);
            btnRemover.Text = "Remover";
            btnRemover.Click += btnRemover_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new System.Drawing.Point(381, 184);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new System.Drawing.Size(93, 46);
            btnAdicionar.TabIndex = 6;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // txtResposta
            // 
            txtResposta.Location = new System.Drawing.Point(85, 185);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new System.Drawing.Size(290, 45);
            txtResposta.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 200);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 15);
            label5.TabIndex = 0;
            label5.Text = "Resposta:";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancelar.Location = new System.Drawing.Point(399, 515);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(75, 45);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnGravar.Location = new System.Drawing.Point(318, 515);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new System.Drawing.Size(75, 45);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new System.Drawing.Point(85, 15);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(60, 23);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(59, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkJaUtilizada
            // 
            chkJaUtilizada.AutoSize = true;
            chkJaUtilizada.Enabled = false;
            chkJaUtilizada.Location = new System.Drawing.Point(85, 108);
            chkJaUtilizada.Name = "chkJaUtilizada";
            chkJaUtilizada.Size = new System.Drawing.Size(15, 14);
            chkJaUtilizada.TabIndex = 10;
            chkJaUtilizada.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(107, 107);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(154, 15);
            label6.TabIndex = 11;
            label6.Text = "Já utilizada em algum teste?";
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(491, 572);
            Controls.Add(label6);
            Controls.Add(chkJaUtilizada);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(btnAdicionar);
            Controls.Add(cmbMaterias);
            Controls.Add(txtResposta);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(cmbDisciplinas);
            Controls.Add(label3);
            Controls.Add(txtEnunciado);
            Controls.Add(label2);
            Name = "TelaQuestaoForm";
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRemover;
        private System.Windows.Forms.ComboBox cmbAlternativaCorreta;
        private System.Windows.Forms.CheckedListBox listAlternativas;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkJaUtilizada;
        private System.Windows.Forms.Label label6;
    }
}