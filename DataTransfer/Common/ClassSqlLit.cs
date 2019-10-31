using System;

using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace DataTransfer.Common
{
    public class ClassSqlLit
    {
        SQLiteConnection slCon;
      
       
        //string varCon = "Data Source=" + System.Configuration.ConfigurationSettings.AppSettings["SqlLitDBPath"].ToString() + ";Version=3;datetimeformat=CurrentCulture;";
        public static string  varCon = "Data Source=" + System.Configuration.ConfigurationManager.AppSettings["SqlLitDBPath"].ToString() + ";Version=3;datetimeformat=CurrentCulture;";
        public static string SourceMasterColum = System.Configuration.ConfigurationManager.AppSettings["MasterSourceField"].ToString();
        public static string DestinationMsterColum = System.Configuration.ConfigurationManager.AppSettings["MasterDestinationField"].ToString();

        public DataSet FillTransferLoggTables(string TableName)
        {
            slCon = new SQLiteConnection();
            DataSet dsdata = new DataSet();
            try
            {
                slCon.ConnectionString = varCon;
                if (slCon.State == ConnectionState.Closed)
                {
                    try
                    {

                        slCon.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "FillTransferLoggTables", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
                SQLiteCommand Cmd = new SQLiteCommand();
                Cmd.Connection = slCon;
                Cmd.CommandText = "select TableName from " + TableName;
                Cmd.CommandType = CommandType.Text;

                SQLiteDataAdapter adpt = new SQLiteDataAdapter();
                adpt.SelectCommand = Cmd;
                adpt.Fill(dsdata, TableName);

                if (slCon.State == ConnectionState.Open)
                {
                    slCon.Close();
                }
                Cmd.Dispose();
                adpt.Dispose();
                slCon = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FillTransferLoggTables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }

        public DataSet FillSqlLitFields(string TableName)
        {
            slCon = new SQLiteConnection();
            DataSet dsdata = new DataSet();
            try
            {
                slCon.ConnectionString = varCon;
                if (slCon.State == ConnectionState.Closed)
                {
                    try
                    {

                        slCon.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "FillSqlLitFields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

               
                SQLiteCommand Cmd = new SQLiteCommand();
                Cmd.Connection = slCon;
                Cmd.CommandText = "PRAGMA table_info(" + TableName + ");";
                Cmd.CommandType = CommandType.Text;

                SQLiteDataAdapter adpt = new SQLiteDataAdapter();
                adpt.SelectCommand = Cmd;
                adpt.Fill(dsdata, TableName);

                if (slCon.State == ConnectionState.Open)
                {
                    slCon.Close();
                }
                Cmd.Dispose();
                adpt.Dispose();
                slCon = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FillSqlLitFields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }
        public DataSet FillAllTables()
        {
            slCon = new SQLiteConnection();
            DataSet dsdata = new DataSet();
            try
            {
                slCon.ConnectionString = varCon;
                if (slCon.State == ConnectionState.Closed)
                {
                    try
                    {

                        slCon.Open();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "FillAllTables", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

               
                SQLiteCommand Cmd = new SQLiteCommand();
                Cmd.Connection = slCon;
                //Cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
                Cmd.CommandText = "SELECT Tablename FROM transfer_tables;";
                Cmd.CommandType = CommandType.Text;

                SQLiteDataAdapter adpt = new SQLiteDataAdapter();
                adpt.SelectCommand = Cmd;
                adpt.Fill(dsdata, "UserTables");

                if (slCon.State == ConnectionState.Open)
                {
                    slCon.Close();
                }
                Cmd.Dispose();
                adpt.Dispose();
                slCon = null    ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FillAllTables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }
        public DataSet FillData(string TableName)
        {
            slCon = new SQLiteConnection();
            DataSet dsdata = new DataSet();
            try
            {
                slCon.ConnectionString = varCon;
                if (slCon.State == ConnectionState.Closed)
                {
                    try
                    {

                        slCon.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "FillData", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

               
                SQLiteCommand Cmd = new SQLiteCommand();
                Cmd.Connection = slCon;
                Cmd.CommandText = "select * from " + TableName + ";";
                Cmd.CommandType = CommandType.Text;

                SQLiteDataAdapter adpt = new SQLiteDataAdapter();
                adpt.SelectCommand = Cmd;
                adpt.Fill(dsdata, TableName);

                if (slCon.State == ConnectionState.Open)
                {
                    slCon.Close();
                }
                Cmd.Dispose();
                adpt.Dispose();
                slCon = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FllData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsdata;
        }
    }
}
