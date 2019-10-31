using System;
using System.Data;
using System.Data.OleDb;

using System.Windows.Forms;


using DataTransfer.Common;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;



namespace DataTransfer
{
    public partial class frmDataTransfer : Form
    {

        
        bool ServerRunning = false;
        String spath = Application.StartupPath + "\\DataTransferLog.txt";
        public frmDataTransfer()
        {
            InitializeComponent();

        }

        private void frmDataTransfer_Load(object sender, EventArgs e)
        {
            
        }
        DataTable varTable = null;
        private bool FillMappingFields()
        {
            bool OK = false;
            string path = Application.StartupPath + @"\FieldsMapping.xml";
            if (File.Exists(path))
            {
                varTable = null;
                if (varTable == null)
                {
                    varTable = new DataTable();
                    varTable.TableName = "FieldsMapping";
                    varTable.Columns.Add("SourceColumn");
                    varTable.Columns.Add("DestinationColumn");
                    varTable.Columns.Add("ColumnDataType");
                    varTable.Columns.Add("ConType");
                    varTable.Columns.Add("TableNameSource");
                    varTable.Columns.Add("TableNameDestination");
                    varTable.AcceptChanges();
                }
                varTable.ReadXml(path);
                if(varTable!=null)
                {
                    if(varTable.Rows.Count>0)
                    {
                        varSourceTableName = varTable.Rows[0]["TableNameSource"].ToString();
                        varDesinationTableName = varTable.Rows[0]["TableNameDestination"].ToString();
                        OK = true;
                    }
                }
            }
            return OK;
        }
        private bool FillDestinationDbInfo()
        {
            bool OK = false;
            string varpath = Application.StartupPath + @"\DbConInfo.xml";
            if (File.Exists(varpath) == true)
            {
                DataTable table = new DataTable();
                table.TableName = "TblConnection";
                table.Columns.Add("ServerName");
                table.Columns.Add("DbName");
                table.Columns.Add("Uid");
                table.Columns.Add("Pwd");
                table.Columns.Add("Type");

                table.ReadXml(varpath);
                if (table.Rows.Count > 0)
                {
                    ClassDBInfo.DBType = table.Rows[0]["Type"].ToString();
                    ClassDBInfo.Server = table.Rows[0]["ServerName"].ToString();
                    ClassDBInfo.DbName = table.Rows[0]["DbName"].ToString();
                    ClassDBInfo.UID = table.Rows[0]["Uid"].ToString();
                    ClassDBInfo.Pwd = table.Rows[0]["Pwd"].ToString();
                    ClassDBInfo.OK = true;
                    OK = true;
                }
            }
            return OK;
        }

        string varSourceTableName = "";
        string varDesinationTableName = "";

        private void ReconcileData(DataSet ds)
        {
            ClassDestinationDb OBJ = new ClassDestinationDb();
          
          
            if (ClassSqlLit.SourceMasterColum != string.Empty && ClassSqlLit.DestinationMsterColum != string.Empty)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string dui_id = "0";

                    if (row[ClassSqlLit.SourceMasterColum] != DBNull.Value)
                    {
                      
                        dui_id = row[ClassSqlLit.SourceMasterColum].ToString();
                        lblStatus.Text = "Fetching... Please wait.";
                        Application.DoEvents();
                        string Cmd = "select * from " + varDesinationTableName + " where " + ClassSqlLit.DestinationMsterColum + " ='" + dui_id + "'";
                        DataSet dsRecon = new DataSet();
                        if (ClassDBInfo.DBType.ToUpper() == "SQL")
                        {
                            dsRecon = OBJ.GeneralSearchSql(Cmd);
                        }
                        else if (ClassDBInfo.DBType.ToUpper() == "ORACLE")
                        {
                            dsRecon = OBJ.GeneralSearchOracle(Cmd);
                        }
                        else if (ClassDBInfo.DBType.ToUpper() == "MYSQL")
                        {
                            dsRecon = OBJ.GeneralSearchMySql(Cmd);
                        }

                        if (OBJ.CheckDs(dsRecon) == false)
                        {
                            //row.Delete();
                            //ds.Tables[0].AcceptChanges();
                            dsRecords.Tables[0].Rows.Add(row.ItemArray);
                            dsRecords.Tables[0].AcceptChanges();
                        }

                        dsRecon.Clear();
                        dsRecon.Dispose();
                        dsRecon = null;
                       
                        
                    }

                   
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show("Master column mappings should be defined", "ReconcileData", MessageBoxButtons.OK);
            }
            OBJ = null;
        }
        DataSet dsRecords = null;
       

       
        private void ProcessInsertSql()
        {
            ClassDestinationDb OBJ = new ClassDestinationDb();
            if (OBJ.CheckDs(dsRecords) == true)
            {
                int index = 0;
                int reccnt = 1;
                foreach (DataRow RowRec in dsRecords.Tables[0].Rows)
                {
                    SqlCommand Cmd = new SqlCommand();
                    string varCols = "";
                    string varColVal = "";
                    foreach (DataRow row in varTable.Rows)
                    {
                        varCols = varCols + row["DestinationColumn"].ToString() + ",";
                        varColVal = varColVal + "@" + row["DestinationColumn"].ToString() + ",";
                        Cmd.Parameters.AddWithValue("@" + row["DestinationColumn"].ToString(), RowRec[row["SourceColumn"].ToString()]);
                    }
                    varCols = varCols.Remove(varCols.Length - 1, 1);
                    varColVal = varColVal.Remove(varColVal.Length - 1, 1);
                    string varCmd = "insert into " + varDesinationTableName + "(" + varCols + ")values(" + varColVal + ")";
                    Cmd.CommandText = varCmd;
                    try
                    {
                        OBJ.GeneralInsertMethodSql(Cmd,spath);
                        DG1.Rows[index].Selected = true;
                        index += 1;
                        lblStatus.Text = "Start Data Transfer " + reccnt + " out of " + dsRecords.Tables[0].Rows.Count.ToString();
                        reccnt = reccnt + 1;
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                       // MessageBox.Show(ex.Message.ToString(), "ProcessInsertSql", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                
                    Application.DoEvents();
                }
            }
        }
        private void ProcessInsertMySql()
        {
            ClassDestinationDb OBJ = new ClassDestinationDb();
            if (OBJ.CheckDs(dsRecords) == true)
            {
                int index = 0;
                int reccnt = 1;
                foreach (DataRow RowRec in dsRecords.Tables[0].Rows)
                {
                    MySqlCommand Cmd = new MySqlCommand();
                    string varCols = "";
                    string varColVal = "";
                    foreach (DataRow row in varTable.Rows)
                    {
                        varCols = varCols + row["DestinationColumn"].ToString() + ",";
                        varColVal = varColVal + "@" + row["DestinationColumn"].ToString() + ",";
                        Cmd.Parameters.AddWithValue("@" + row["DestinationColumn"].ToString(), RowRec[row["SourceColumn"].ToString()]);
                    }
                    varCols = varCols.Remove(varCols.Length - 1, 1);
                    varColVal = varColVal.Remove(varColVal.Length - 1, 1);
                    string varCmd = "insert into " + varDesinationTableName + "(" + varCols + ")values(" + varColVal + ")";
                    Cmd.CommandText = varCmd;
                    try
                    {
                        OBJ.GeneralInsertMethodMySql(Cmd,spath);
                        DG1.Rows[index].Selected = true;
                        index += 1;
                        lblStatus.Text = "Start Data Transfer " + reccnt + " out of " + dsRecords.Tables[0].Rows.Count.ToString();
                        reccnt = reccnt + 1;
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                       // MessageBox.Show(ex.Message.ToString(), "ProcessInsertMySql", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                
                    Application.DoEvents();
                }
            }
        }
        private bool CheckNullValue(string ColName, DataRow row)
        {
            bool OK = false;
            if (row[ColName] == DBNull.Value)
            {
                OK = true;
            }
            return OK;
        }
        private void ProcessInsertOracle()
        {
            ClassDestinationDb OBJ = new ClassDestinationDb();
            if (OBJ.CheckDs(dsRecords) == true)
            {
                int index = 0;
                int reccnt = 1;
                foreach (DataRow RowRec in dsRecords.Tables[0].Rows)
                {
                    OleDbCommand Cmd = new OleDbCommand();
                    string varCols = "";
                    string varColVal = "";
                    string varValues = "";
                    foreach (DataRow row in varTable.Rows)
                    {
                        varCols = varCols + row["DestinationColumn"].ToString() + ",";
                        varColVal = varColVal + "?,";
                        //string varTempVal = RowRec[row["SourceColumn"].ToString()].ToString();

                        if (CheckNullValue(row["SourceColumn"].ToString(), RowRec))
                        {
                            Cmd.Parameters.AddWithValue("@" + row["DestinationColumn"].ToString(), DBNull.Value);
                        }
                        else
                        {
                            if (row["ColumnDataType"].ToString().ToUpper() == "BIT")
                            {
                                string varBitVal = "0";
                                if (RowRec[row["SourceColumn"].ToString()].ToString().ToUpper() == "TRUE")
                                {
                                    varBitVal = "1";
                                }
                                Cmd.Parameters.AddWithValue("@" + row["DestinationColumn"].ToString(), varBitVal);
                            }
                            else
                            {
                                Cmd.Parameters.AddWithValue("@" + row["DestinationColumn"].ToString(), RowRec[row["SourceColumn"].ToString()]);
                            }
                        }
                        varValues += RowRec[row["SourceColumn"].ToString()] + " , ";
                    }
                    varCols = varCols.Remove(varCols.Length - 1, 1);
                    varColVal = varColVal.Remove(varColVal.Length - 1, 1);
                    string varCmd = "insert into " + varDesinationTableName + "(" + varCols + ")values(" + varColVal + ")";
                    Cmd.CommandText = varCmd;
                    try
                    {
                        OBJ.GeneralInsertMethodOracle(Cmd,spath);
                        DG1.Rows[index].Selected = true;
                        index += 1;
                        lblStatus.Text = "Start Data Transfer " + reccnt + " out of " + dsRecords.Tables[0].Rows.Count.ToString();
                        reccnt = reccnt + 1;
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                        //MessageBox.Show(ex.Message.ToString(), "ProcessInsertOracle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                    }
                  
                    Application.DoEvents();
                }
            }
        }
       


        private void StartDataTransfer()
        {
           

            lblStatus.Text = "Start Data Transfer";

            btn_FetchData.Enabled = false;
            btnDataTransfer.Enabled = false;
           
            if (ClassDBInfo.DBType.ToUpper() == "SQL")
            {
                Application.DoEvents();
                ProcessInsertSql();
            }
            else if (ClassDBInfo.DBType.ToUpper() == "ORACLE")
            {
                Application.DoEvents();
                ProcessInsertOracle();
            }
            else if (ClassDBInfo.DBType.ToUpper() == "MYSQL")
            {
                Application.DoEvents();
                ProcessInsertMySql();
            }

            DG1.DataSource = null;
            lblStatus.Text = "Data Transfer To [ " + ClassDBInfo.DBType.ToUpper() + " ] Database Completed Successfully!";


            if (ServerRunning == true)
            {
               

               
            }
            else
            {
                btn_FetchData.Enabled = true;
                btnDataTransfer.Enabled = true;
            }
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

        private void btnDataTransfer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to transfer data in [ " + ClassDBInfo.DBType.ToUpper() + " ] Database ?", "Data Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.ControlBox = false;
                ServerRunning = true;
                StartDataTransfer();
                this.ControlBox = true;
            }
        }

      

        

        private void btn_FetchData_Click(object sender, EventArgs e)
        {

            dsRecords = null;
            btnDataTransfer.Enabled = false;
            try {
                if (FillDestinationDbInfo() == true)
                {
                    if (FillMappingFields() == true)
                    {
                        DG1.DataSource = null;

                        dsRecords = new DataSet();

                        DataSet dsdata = new DataSet();
                        ClassSqlLit obj = new ClassSqlLit();
                        dsdata = obj.FillData(varSourceTableName);

                        dsRecords = dsdata.Clone();


                        ReconcileData(dsdata);
                        lblStatus.Text = "Fetched Successfully - " + dsRecords.Tables[0].Rows.Count.ToString() + " Records to tansfer.";
                        btnDataTransfer.Enabled = true;
                        DG1.DataSource = dsRecords.Tables[0];
                    }


                }

            
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "btn_FetchData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
        }

        private void frmDataTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dsRecords!=null)
            {
                dsRecords.Clear();
                dsRecords.Dispose();
                dsRecords = null;

            }
        }
    }
}
