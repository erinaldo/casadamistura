using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
namespace Perifericos
{
    public class Querys
    {
        Conn.Class1 conex = new Class1();
        bool deucerto;
        public bool Cadastra(string pcodbarras, string pusuarios, string pprodutos, string pquantidade, string pstatus,double pvalor)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_comanda  ";
            SQInsert += "(CODIGO_BARRAS, USUARIO, PRODUTO, QUANTIDADE, STATUS,VALOR) ";
            SQInsert += " VALUES (?,?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = pcodbarras;
            cmd.Parameters.Add("@p2", OleDbType.VarChar).Value = pusuarios;
            cmd.Parameters.Add("@p3", OleDbType.VarChar).Value = pprodutos;
            cmd.Parameters.Add("@p4", OleDbType.VarChar).Value = pquantidade;
            cmd.Parameters.Add("@p5", OleDbType.VarChar).Value = pstatus;
            cmd.Parameters.Add("@p6", OleDbType.Decimal).Value = pvalor;
            try
            {
                cmd.ExecuteNonQuery();
                deucerto = true;
            }
            catch (Exception err)
            {
                deucerto = false;
                conex.GeraErro("Gravap_comanda", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool delete(string pcodbarras, string pprodutos, int quantidade)
        {
            string SQInsert = null;
            SQInsert += "DELETE FROM p_comanda  WHERE HANDLE IN  ";
            SQInsert += "(SELECT TOP " + quantidade + "  HANDLE from p_comanda where CODIGO_BARRAS = " + pcodbarras + " and produto = " + pprodutos + ") ";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = pcodbarras;
            try
            {
                cmd.ExecuteNonQuery();
                deucerto = true;
            }
            catch (Exception err)
            {
                deucerto = false;
                conex.GeraErro("dELETA_comanda", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool deletecomanda(string pcodbarras)
        {
            string SQInsert = null;
            SQInsert += "DELETE FROM p_comanda  WHERE CODIGO_BARRAS = '"+pcodbarras+"'";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            try
            {
                cmd.ExecuteNonQuery();
                deucerto = true;
            }
            catch (Exception err)
            {
                deucerto = false;
                conex.GeraErro("dELETA_comanda", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }

    }
}
