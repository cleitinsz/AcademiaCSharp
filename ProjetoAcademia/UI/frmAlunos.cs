using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAcademia.UI
{
    public partial class frmAlunos : Form
    {
        BLL.Aluno aluno = new BLL.Aluno();
        DAL.AlunoDAL alunoDAL = new DAL.AlunoDAL();

        public frmAlunos()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            aluno.Nome = txtNome.Text;
            aluno.Email = txtEmail.Text;
            aluno.Cpf = txtCPF.Text;
            aluno.Telefone = txtTelefone.Text;

            if (btnGravar.Text != "Atualizar")
            {
                alunoDAL.Cadastrar(aluno);
            }
            else
            {
                alunoDAL.Atualizar(aluno);
            }
            Cancelar();
            MessageBox.Show("Dados Gravado com Sucesso");
        }

        public void Cancelar()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
            btnGravar.Text = "Gravar";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmAlunos_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = alunoDAL.ConsultarTodos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            aluno.Nome = txtPesquisar.Text;
            dgvConsulta.DataSource = alunoDAL.Pesquisar(aluno);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                aluno.CodAluno = Convert.ToInt16(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                alunoDAL.Excluir(aluno);
                dgvConsulta.DataSource = alunoDAL.ConsultarTodos();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.SelectedRows.Count > 0)
            {
                aluno.CodAluno = Convert.ToInt16(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                aluno = alunoDAL.Retornar(aluno);
                txtEmail.Text = aluno.Email;
                txtNome.Text = aluno.Nome;
                txtCPF.Text = aluno.Cpf;
                txtTelefone.Text = aluno.Telefone;
                btnGravar.Text = "Atualizar";
                tabControl1.SelectedTab = tabPage1;
               
            }
        }

    }
}
