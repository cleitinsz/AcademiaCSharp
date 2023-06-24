using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ProjetoAcademia.DAL
{
    internal class UsuarioDAL
    {
        Conexao conn = new Conexao();

        public void Cadastrar(BLL.Usuario User)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
            cmd.Parameters.AddWithValue("@Nome", User.Nome);
            cmd.Parameters.AddWithValue("@Email", User.Email);
            cmd.Parameters.AddWithValue("@Senha", User.Senha);

            cmd.Connection = conn.Conectar();
            cmd.ExecuteNonQuery();
            conn.Desconectar();
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM USUARIO ORDER BY Nome", conn.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Desconectar();
            return dt;

        }

        public DataTable Pesquisar(BLL.Usuario User)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM USUARIO WHERE Nome LIKE @Nome ORDER BY Nome", conn.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@Nome", User.Nome + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Desconectar();
            return dt;
        }

        public void Excluir(BLL.Usuario User)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM USUARIO WHERE CodUsuario = @CodUsuario";
            cmd.Parameters.AddWithValue("@CodUsuario", User.CodUsuario);
            cmd.Connection = conn.Conectar();
            cmd.ExecuteNonQuery();
            conn.Desconectar();
        }

        public BLL.Usuario Retornar(BLL.Usuario User)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM USUARIO WHERE CodUsuario = @CodUsuario";
            cmd.Parameters.AddWithValue("@CodUsuario", User.CodUsuario);
            cmd.Connection=conn.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                User.CodUsuario = Convert.ToInt16(dr["CodUsuario"]);
                User.Nome = dr["Nome"].ToString();
                User.Email = dr["Email"].ToString();
                User.Senha = dr["Senha"].ToString();
            }
            dr.Close();
            conn.Desconectar();
            return User;
        }

        public void Atualizar(BLL.Usuario User)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE USUARIO SET Nome = @Nome, Email = @Email, Senha = @Senha WHERE CodUsuario = @CodUsuario";
            cmd.Parameters.AddWithValue("@Nome", User.Nome);
            cmd.Parameters.AddWithValue("@Email", User.Email);
            cmd.Parameters.AddWithValue("@Senha", User.Senha);
            cmd.Parameters.AddWithValue("@CodUsuario", User.CodUsuario);
            cmd.Connection = conn.Conectar();
            cmd.ExecuteNonQuery();
            conn.Desconectar();
        }

    }
}
