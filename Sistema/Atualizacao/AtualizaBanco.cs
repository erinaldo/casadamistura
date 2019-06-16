using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
using System.Windows.Forms;

namespace Atualizacao
{
    class AtualizaBanco
    {
        public string mensagemdelete { get; set; }

        public void Atualizar(string SQL)
        {
            //SQL += "alter table comanda add DATA_FECHAMENTO smalldatetime";
            Conn.Class1 conex = new Conn.Class1();
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQL, DbConnection);
            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("ATUALIZADO COM SUCESSO");
            }
            catch (Exception err)
            {
               conex.GeraErro("atualizabando",err.Message.ToString(),DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }

        }
    }
}
