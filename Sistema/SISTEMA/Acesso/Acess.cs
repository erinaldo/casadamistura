using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
using System.Windows.Forms;
using System.Data;

namespace SISTEMA
{
    class Acess
    {
        public string usuario { get; set; }
        public string codusuario { get; set; }
        public string perfil { get; set; }
        public string senha { get; set; }
        public string ultimoacesso { get; set; }
        OleDbConnection DbConnection;
        Conn.Class1 conex = new Class1();
        public void acesso(string pusuario, string psenha)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("SELECT * FROM p_usuarios WHERE LOGIN='" + pusuario + "' AND SENHA = '" + psenha + "' AND DATA_CANCELAMENTO IS NULL");
            DbConnection = conex.Cnncontrol();
            if (DbConnection.State == ConnectionState.Closed)
            {
                if (MessageBox.Show("ERRO NA CONEXAO COM BANCO DE DADOS", "ATENÇÂO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    acesso(pusuario, psenha);
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {

                OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
                OleDbDataReader da = cmd.ExecuteReader();

                usuario = "";
                codusuario = "";
                perfil = "";
                senha = "";
                while (da.Read())
                {
                    usuario = da["LOGIN"].ToString();
                    codusuario = da["HANDLE"].ToString();
                    perfil = da["FUNCAO"].ToString();
                    senha = da["SENHA"].ToString();
                }
                da.Close();
            }
        }

    }
}
