using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using ProjetoAcademia.BLL;

namespace ProjetoAcademia.DAL
{
    internal class AlunoDAL
    {
        Conexao conn = new Conexao();

        public void Cadastrar(BLL.Aluno aluno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Aluno (Nome, Email, CPF, Telefone) VALUES (@Nome, @Email, @Cpf, @Telefone)";
            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@Email", aluno.Email);
            cmd.Parameters.AddWithValue("@CPF", aluno.Cpf);
            cmd.Parameters.AddWithValue("@Telefone", aluno.Telefone);

            cmd.Connection = conn.Conectar();
            cmd.ExecuteNonQuery();
            conn.Desconectar();
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM ALUNO ORDER BY Nome", conn.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Desconectar();
            return dt;
        }

        public DataTable Pesquisar(BLL.Aluno aluno)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM ALUNO WHERE Nome LIKE @Nome ORDER BY Nome", conn.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@Nome", aluno.Nome + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Desconectar();
            return dt;
        }

        public void Excluir(BLL.Aluno aluno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM ALUNO WHERE CodAluno = @CodAluno";
            cmd.Parameters.AddWithValue("@CodAluno", aluno.CodAluno);
            cmd.Connection = conn.Conectar();
            cmd.ExecuteNonQuery();
            conn.Desconectar();
        }

        public BLL.Aluno Retornar(BLL.Aluno aluno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM ALUNO WHERE CodAluno = @CodAluno";
            cmd.Parameters.AddWithValue("@CodAluno", aluno.CodAluno);
            cmd.Connection = conn.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                aluno.CodAluno = Convert.ToInt16(dr["CodAluno"]);
                aluno.Nome = dr["Nome"].ToString();
                aluno.Email = dr["Email"].ToString();
                aluno.Cpf = dr["Cpf"].ToString();
                aluno.Telefone = dr["Telefone"].ToString();
            }
            dr.Close();
            conn.Desconectar();
            return aluno;
        }

        public void Atualizar(BLL.Aluno aluno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE ALUNO SET Nome = @Nome, Email = @Email, Cpf = @Cpf, Telefone = @Telefone WHERE CodAluno = @CodAluno";
            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@Email", aluno.Email);
            cmd.Parameters.AddWithValue("@Cpf", aluno.Cpf);
            cmd.Parameters.AddWithValue("@Telefone", aluno.Telefone);
            cmd.Parameters.AddWithValue("@CodAluno", aluno.CodAluno);
            cmd.Connection = conn.Conectar();
            cmd.ExecuteNonQuery();
            conn.Desconectar();
        }
    }
}
