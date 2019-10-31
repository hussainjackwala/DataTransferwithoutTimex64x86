using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
namespace DataTransfer.Common
{
    public class ClassDestinationDb
    {
        public bool CheckDs(DataSet ds)
        {
            bool OK = false;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        OK = true;
                    }
                }
            }
            return OK;
        }
        public DataSet GeneralSearchSql(string varCmd)
        {
            DataSet dsdata = new DataSet();
            SqlConnection conn = new SqlConnection();
            try
            { 
            string varCon = "Data Source=" + ClassDBInfo.Server + ";Initial Catalog=" + ClassDBInfo.DbName + ";User ID=" + ClassDBInfo.UID + ";Password=" + ClassDBInfo.Pwd + ";";
            conn.ConnectionString = varCon;

            if (conn.State == ConnectionState.Closed)
            {
                    try
                    {
                       
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "GeneralSearchSql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                }
           

            SqlDataAdapter adpt = new SqlDataAdapter();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = conn;
            Cmd.CommandText = varCmd;
            adpt.SelectCommand = Cmd;
            adpt.Fill(dsdata, "0");

            
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
                conn = null;
                Cmd.Dispose();
                Cmd = null;
                adpt.Dispose();
                adpt = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GeneralSearchSql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }
        public DataSet GeneralSearchMySql(string varCmd)
        {
            DataSet dsdata = new DataSet();
            try
            {
                MySqlConnection conn = new MySqlConnection();
                string varCon = "SERVER=" + ClassDBInfo.Server + ";" + "DATABASE=" + ClassDBInfo.DbName + ";" + "UID=" + ClassDBInfo.UID + ";" + "PASSWORD=" + ClassDBInfo.Pwd + ";";
                conn.ConnectionString = varCon;

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "GeneralSearchMySql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
               

                MySqlDataAdapter adpt = new MySqlDataAdapter();
                MySqlCommand Cmd = new MySqlCommand();
                Cmd.Connection = conn;
                Cmd.CommandText = varCmd;
                adpt.SelectCommand = Cmd;
                adpt.Fill(dsdata, "0");

               
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                conn = null;
                Cmd.Dispose();
                Cmd = null;
                adpt.Dispose();
                adpt = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GeneralSearchMySql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }
        public DataSet GeneralSearchOracle(string varCmd)
        {
            DataSet dsdata = new DataSet();
            try
            {

                OleDbConnection conn = new OleDbConnection();
                string varCon = "Provider=OraOLEDB.Oracle; Data Source=" + ClassDBInfo.Server + ";" + "User ID=" + ClassDBInfo.UID + ";" + "Password=" + ClassDBInfo.Pwd + ";";
                conn.ConnectionString = varCon;

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "GeneralSearchOracle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
             

                OleDbDataAdapter adpt = new OleDbDataAdapter();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = conn;
                Cmd.CommandText = varCmd;
                adpt.SelectCommand = Cmd;
                adpt.Fill(dsdata, "0");

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                conn = null;
                Cmd.Dispose();
                Cmd = null;
                adpt.Dispose();
                adpt = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GeneralSearchOracle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }

        public bool GeneralInsertMethodSql(SqlCommand Cmd,string spath)
        {
            bool OK = false;
            SqlConnection conn = new SqlConnection();
            try
            {
                string varCon = "Data Source=" + ClassDBInfo.Server + ";Initial Catalog=" + ClassDBInfo.DbName + ";User ID=" + ClassDBInfo.UID + ";Password=" + ClassDBInfo.Pwd + ";";
                conn.ConnectionString = varCon;

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                        // MessageBox.Show(ex.Message.ToString(), "GeneralInsertMethodSql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return OK;
                    }
                }

                Cmd.Connection = conn;
               
                int I = 0;
                I = Cmd.ExecuteNonQuery();
                if (I > 0)
                {
                    OK = true;
                }
             

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                conn = null;
                Cmd.Dispose();
                Cmd = null;
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                //MessageBox.Show(ex.Message.ToString(), "GeneralInsertMethodSql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;   
        }
        public bool GeneralInsertMethodOracle(OleDbCommand Cmd,string spath)
        {
            bool OK = false;
            OleDbConnection conn = new OleDbConnection();
            try
            {
                string varCon = "Provider=OraOLEDB.Oracle; Data Source=" + ClassDBInfo.Server + ";" + "User ID=" + ClassDBInfo.UID + ";" + "Password=" + ClassDBInfo.Pwd + ";";
                conn.ConnectionString = varCon;

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                        // MessageBox.Show(ex.Message.ToString(), "GeneralInsertMethodOracle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return OK;
                    }
                }

                Cmd.Connection = conn;
              
                int I = 0;
                I = Cmd.ExecuteNonQuery();
                if (I > 0)
                {
                    OK = true;
                }
                Cmd.Dispose();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                conn = null;
                Cmd.Dispose();
                Cmd = null;
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());

                //MessageBox.Show(ex.Message.ToString(), "GeneralInsertMethodOracle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return OK;
        }
        public bool GeneralInsertMethodMySql(MySqlCommand Cmd,string spath)
        {
            bool OK = false;
            try
            {
                MySqlConnection conn = new MySqlConnection();
                string varCon = "SERVER=" + ClassDBInfo.Server + ";" + "DATABASE=" + ClassDBInfo.DbName + ";" + "UID=" + ClassDBInfo.UID + ";" + "PASSWORD=" + ClassDBInfo.Pwd + ";";
                conn.ConnectionString = varCon;

                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                        // MessageBox.Show(ex.Message.ToString(), "GeneralInsertMethodMySql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return OK;
                    }
                }

                Cmd.Connection = conn;
               
                int I = 0;
                I = Cmd.ExecuteNonQuery();
                if (I > 0)
                {
                    OK = true;
                }
              

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                conn = null;
                Cmd.Dispose();
                Cmd = null;
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                // MessageBox.Show(ex.Message.ToString(), "GeneralInsertMethodMySql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;

        }
        private void WriteErrorLog(string spath, String LogsMessage)
        {
            System.IO.StreamWriter myStreamWriter = null;
            try
            {

                if (!(File.Exists(spath) == true))
                {
                    myStreamWriter = File.CreateText(spath);
                    myStreamWriter.WriteLine(System.DateTime.Now + "   " + LogsMessage);

                }
                else
                {
                    myStreamWriter = File.AppendText(spath);
                    myStreamWriter.WriteLine("------------------------------------------------");
                    myStreamWriter.WriteLine(System.DateTime.Now + "   " + LogsMessage);

                }

            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
            }
            finally
            {
                if (!(myStreamWriter == null))
                {
                    myStreamWriter.Flush();
                    myStreamWriter.Close();
                }

            }

        }

    }
}
