using ProjetoAcademia.BLL;
using ProjetoAcademia.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAcademia.UI
{
    public partial class frmUsuarios : Form
    {
        BLL.Usuario User = new BLL.Usuario();
        DAL.UsuarioDAL UserDAL = new DAL.UsuarioDAL();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            User.Nome = txtNome.Text;
            User.Email = txtEmail.Text;
            User.Senha = txtSenha.Text;

            if(btnGravar.Text != "Atualizar")
            {
                UserDAL.Cadastrar(User);
            }
            else
            {
                UserDAL.Atualizar(User);
            }
            Cancelar();
            MessageBox.Show("Dados Gravado com Sucesso");
        }

        public void Cancelar()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtNome.Focus();
            btnGravar.Text = "Gravar";
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = UserDAL.ConsultarTodos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            User.Nome = txtPesquisar.Text;
            dgvConsulta.DataSource = UserDAL.Pesquisar(User);
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if(dgvConsulta.SelectedRows.Count > 0)
            {
                User.CodUsuario = Convert.ToInt16(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                User = UserDAL.Retornar(User);
                txtEmail.Text = User.Email;
                txtNome.Text = User.Nome;
                txtSenha.Text = User.Senha;
                btnGravar.Text = "Atualizar";
                tabControl1.SelectedTab = tabPage1;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                User.CodUsuario = Convert.ToInt16(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                UserDAL.Excluir(User);
                dgvConsulta.DataSource = UserDAL.ConsultarTodos();
            }
        }
    }
}
