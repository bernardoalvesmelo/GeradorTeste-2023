using System;

namespace GeradorTestes.WinApp
{
    partial class TelaPrincipalForm
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
            menu = new System.Windows.Forms.MenuStrip();
            cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disciplinaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            materiasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            questoesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolbox = new System.Windows.Forms.ToolStrip();
            btnInserir = new System.Windows.Forms.ToolStripButton();
            btnEditar = new System.Windows.Forms.ToolStripButton();
            btnDuplicar = new System.Windows.Forms.ToolStripButton();
            btnExcluir = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            btnVisualizar = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            btnGerarPdf = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnFiltrar = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            panelRegistros = new System.Windows.Forms.Panel();
            menu.SuspendLayout();
            toolbox.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { cadastrosToolStripMenuItem });
            menu.Location = new System.Drawing.Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            menu.Size = new System.Drawing.Size(784, 30);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { disciplinaMenuItem, materiasMenuItem, questoesMenuItem, testesMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // disciplinaMenuItem
            // 
            disciplinaMenuItem.Name = "disciplinaMenuItem";
            disciplinaMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            disciplinaMenuItem.Size = new System.Drawing.Size(187, 26);
            disciplinaMenuItem.Text = "Disciplinas";
            disciplinaMenuItem.Click += disciplinasMenuItem_Click;
            // 
            // materiasMenuItem
            // 
            materiasMenuItem.Name = "materiasMenuItem";
            materiasMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            materiasMenuItem.Size = new System.Drawing.Size(187, 26);
            materiasMenuItem.Text = "Matérias";
            materiasMenuItem.Click += materiasMenuItem_Click;
            // 
            // questoesMenuItem
            // 
            questoesMenuItem.Name = "questoesMenuItem";
            questoesMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            questoesMenuItem.Size = new System.Drawing.Size(187, 26);
            questoesMenuItem.Text = "Questões";
            questoesMenuItem.Click += questoesMenuItem_Click;
            // 
            // testesMenuItem
            // 
            testesMenuItem.Name = "testesMenuItem";
            testesMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            testesMenuItem.Size = new System.Drawing.Size(187, 26);
            testesMenuItem.Text = "Testes";
            testesMenuItem.Click += testesMenuItem_Click;
            // 
            // toolbox
            // 
            toolbox.Enabled = false;
            toolbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnInserir, btnEditar, btnDuplicar, btnExcluir, toolStripSeparator2, btnVisualizar, toolStripSeparator3, btnGerarPdf, toolStripSeparator1, btnFiltrar, toolStripSeparator4, labelTipoCadastro });
            toolbox.Location = new System.Drawing.Point(0, 30);
            toolbox.Name = "toolbox";
            toolbox.Size = new System.Drawing.Size(784, 37);
            toolbox.TabIndex = 1;
            toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new System.Windows.Forms.Padding(5);
            btnInserir.Size = new System.Drawing.Size(87, 34);
            btnInserir.Text = "Adicionar";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new System.Windows.Forms.Padding(5);
            btnEditar.Size = new System.Drawing.Size(62, 34);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnDuplicar
            // 
            btnDuplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            btnDuplicar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDuplicar.Name = "btnDuplicar";
            btnDuplicar.Padding = new System.Windows.Forms.Padding(5);
            btnDuplicar.Size = new System.Drawing.Size(66, 34);
            btnDuplicar.Text = "Excluir";
            btnDuplicar.Click += btnDuplicar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            btnExcluir.Size = new System.Drawing.Size(29, 34);
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // btnVisualizar
            // 
            btnVisualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnVisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Padding = new System.Windows.Forms.Padding(5);
            btnVisualizar.Size = new System.Drawing.Size(29, 34);
            btnVisualizar.Click += btnVisualizar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // btnGerarPdf
            // 
            btnGerarPdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnGerarPdf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnGerarPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnGerarPdf.Name = "btnGerarPdf";
            btnGerarPdf.Padding = new System.Windows.Forms.Padding(5);
            btnGerarPdf.Size = new System.Drawing.Size(29, 34);
            btnGerarPdf.Click += btnGerarPdf_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new System.Windows.Forms.Padding(5);
            btnFiltrar.Size = new System.Drawing.Size(29, 34);
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new System.Drawing.Size(121, 34);
            labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { labelRodape });
            statusStrip1.Location = new System.Drawing.Point(0, 535);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(784, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new System.Drawing.Size(67, 20);
            labelRodape.Text = "[rodapé]";
            // 
            // panelRegistros
            // 
            panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRegistros.Location = new System.Drawing.Point(0, 67);
            panelRegistros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new System.Drawing.Size(784, 468);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(panelRegistros);
            Controls.Add(statusStrip1);
            Controls.Add(toolbox);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(800, 598);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gerador de Testes 1.0";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            toolbox.ResumeLayout(false);
            toolbox.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinaMenuItem;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem materiasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questoesMenuItem;
        private System.Windows.Forms.ToolStripButton btnGerarPdf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem testesMenuItem;
        private System.Windows.Forms.ToolStripButton btnDuplicar;
        private System.Windows.Forms.ToolStripButton btnVisualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
