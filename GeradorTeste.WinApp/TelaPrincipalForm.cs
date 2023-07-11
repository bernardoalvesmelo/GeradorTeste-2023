using GeradorTeste.Infra.Pdf;
using GeradorTeste.WinApp.ModuloDisciplina;
using GeradorTeste.WinApp.ModuloMateria;
using GeradorTeste.WinApp.ModuloQuestao;
using GeradorTeste.WinApp.ModuloTeste;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using GeradorTestes.Infra.Sql.ModuloDisciplina;
using GeradorTestes.Infra.Sql.ModuloMateria;
using GeradorTestes.Infra.Sql.ModuloQuestao;
using GeradorTestes.Infra.Sql.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private Dictionary<string, ControladorBase> controladores;

        private ControladorBase controlador;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();
        }

        private void ConfigurarControladores()
        {
            IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaEmSql();
            controladores.Add("ControladorDisciplina", new ControladorDisciplina(repositorioDisciplina));

            IRepositorioMateria repositorioMateria = new RepositorioMateriaEmSql();
            controladores.Add("ControladorMateria", new ControladorMateria(repositorioMateria, repositorioDisciplina));

            IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoEmSql();
            controladores.Add("ControladorQuestao", new ControladorQuestao(repositorioQuestao, repositorioDisciplina));

            IRepositorioTeste repositorioTeste = new RepositorioTesteEmSql();
            IGeradorRelatorio geradorRelatorio = new GeradorRelatorioPdf();
            controladores.Add("ControladorTeste", new ControladorTeste(repositorioTeste, repositorioDisciplina, geradorRelatorio));
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void disciplinasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorDisciplina"]);
        }

        private void materiasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorMateria"]);
        }

        private void questoesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorQuestao"]);
        }

        private void testesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorTeste"]);
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            controlador.GerarPdf();
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            controlador.Duplicar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnDuplicar.Enabled = configuracao.DuplicarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnGerarPdf.Enabled = configuracao.GerarPdfHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnGerarPdf.ToolTipText = configuracao.TooltipGerarPdf;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }
    }
}