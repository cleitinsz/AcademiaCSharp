using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ProjetoAcademia.DAL
{
    internal class Conexao
    {
        SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=BDAcademia;Integrated Security=True");

        public SqlConnection Conectar()
        {
            if(conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }

        public void Desconectar()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
