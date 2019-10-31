using System;

using System.Data;
using System.Drawing;


using System.Windows.Forms;
using DataTransfer.Common;
using System.IO;

using System.Configuration;

namespace DataTransfer
{
    public partial class FrmMapFields : Form
    {

        DataSet dsForLoggTable ;
        String spath = Application.StartupPath + "\\MapFieldLog.txt";
        public FrmMapFields()
        {
            InitializeComponent();
        }


        private void FillTRansferLoggTable()
        {
            
            ClassSqlLit obj = new ClassSqlLit();
            dsForLoggTable = new DataSet();

            dsForLoggTable = obj.FillTransferLoggTables("transfer_tables");
            
        }

        private void FillLvSource()
        {
            LvSource.Items.Clear();
            ClassSqlLit obj = new ClassSqlLit();
            DataSet dsdata = new DataSet();
            Application.DoEvents();
            dsdata = obj.FillSqlLitFields(CboSourceTables.Text);
            if (IsValidate(dsdata)==true)
                {
                foreach (DataRow row in dsdata.Tables[0].Rows)
                {
                    LvSource.Items.Add(row["name"].ToString());
                    LvSource.Items[LvSource.Items.Count - 1].SubItems.Add(row["type"].ToString());
                }
            }
        }
        private void FillSourceTables()
        {
            ClassSqlLit obj = new ClassSqlLit();
            DataSet dsdata = new DataSet();
            CboSourceTables.Items.Clear();
            Application.DoEvents();
            dsdata = obj.FillAllTables();
            if (IsValidate(dsdata) == true)
            { 
                foreach (DataRow row in dsdata.Tables[0].Rows)
                {
                    CboSourceTables.Items.Add(row["Tablename"].ToString());
                }
            CboSourceTables.SelectedIndex = 0;
        }
        }

        private  bool IsValidate(DataSet ds)
        {
            bool IsRowcnt = false;
            if (ds!=null)
            {
                if (ds.Tables.Count>0)
                {
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        IsRowcnt = true;
                    }
                }
            }
            return IsRowcnt;
        }
        private void FrmMapFields_Load(object sender, EventArgs e)
        {
            try
            {
                CboDbType.Items.Add("SQL");
                CboDbType.Items.Add("Oracle");
                CboDbType.Items.Add("MySql");
                CboDbType.Items.Insert(0, "Select Destination DB");
                CboDbType.SelectedIndex = 0;

              
            }
            catch(Exception ex)
            {
                //WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "FrmMapFields_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           // FillSourceTables();

           // FillLvSource();

            

            
        }
        private void FillDestinationFields()
        {
            LvDestination.Items.Clear();
            ClassDestinationDb obj = new ClassDestinationDb();
            DataSet dsdata = new DataSet();
            string TableName = CboDestinationTables.Text;
            Application.DoEvents();

            if (CboDbType.SelectedIndex == 1)
            {
                dsdata = obj.GeneralSearchSql("select Column_Name,Data_Type from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + TableName + "'  order by Ordinal_Position");
            }
            if (CboDbType.SelectedIndex == 2)
            {
                dsdata = obj.GeneralSearchOracle("select column_name,data_type from user_tab_columns where TABLE_NAME = upper('" + TableName + "') order by column_id");
            }
            if (CboDbType.SelectedIndex == 3)
            {
                dsdata = obj.GeneralSearchMySql("select Column_Name,Data_Type from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + TableName + "'");
            }
            if (dsdata != null)
            {
                if (dsdata.Tables.Count > 0)
                {
                    if (dsdata.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsdata.Tables[0].Rows)
                        {
                            LvDestination.Items.Add(row[0].ToString());
                            LvDestination.Items[LvDestination.Items.Count - 1].SubItems.Add(row[1].ToString());
                        }
                    }
                }
            }
        }
        private void FillDestinationTables()
        {
            CboDestinationTables.Items.Clear();
            ClassDestinationDb obj = new ClassDestinationDb();
            DataSet dsdata = new DataSet();
            string TableName = CboSourceTables.Text;

            Application.DoEvents();
            if (CboDbType.SelectedIndex == 1)
            {
                dsdata = obj.GeneralSearchSql("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'");
            }
            if (CboDbType.SelectedIndex == 2)
            {
                dsdata = obj.GeneralSearchOracle("SELECT table_name FROM user_tables order by table_name");
            }
            if (CboDbType.SelectedIndex == 3)
            {
                dsdata = obj.GeneralSearchMySql("SELECT table_name FROM information_schema.tables where table_schema='" + ClassDBInfo.DbName + "' order by table_name");
            }
            if (dsdata != null)
            {
                if (dsdata.Tables.Count > 0)
                {
                    if (dsdata.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsdata.Tables[0].Rows)
                        {
                            //DataRow[] varRow = dsForLoggTable.Tables[0].Select("TableName = '" + row[0].ToString() + "'") ;
                            //if (varRow.Length > 0)
                            //{
                                CboDestinationTables.Items.Add(row[0].ToString());
                           // }
                        }
                        CboDestinationTables.SelectedIndex = 0;
                    }
                }
            }
        }
        private void CboDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChangeDbInfo.Visible = false;
            LvDestination.Items.Clear();
            LvMap.Items.Clear();
            try
            {

                if (CboDbType.SelectedIndex != 0)
                {
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
                            if (table.Rows[0]["Type"].ToString().ToUpper() == CboDbType.Text.ToUpper())
                            {
                                btnChangeDbInfo.Visible = true;
                                ClassDBInfo.DBType = CboDbType.Text.ToUpper();
                                ClassDBInfo.Server = table.Rows[0]["ServerName"].ToString();
                                ClassDBInfo.DbName = table.Rows[0]["DbName"].ToString();
                                ClassDBInfo.UID = table.Rows[0]["Uid"].ToString();
                                ClassDBInfo.Pwd = table.Rows[0]["Pwd"].ToString();
                                ClassDBInfo.OK = true;
                            }
                            else
                            {
                                ClassDBInfo.OK = false;
                                FrmDestinationDbInfo frmdb = new FrmDestinationDbInfo();
                                frmdb.dbtype = CboDbType.Text.ToUpper();
                                frmdb.ShowDialog();
                            }
                        }

                    }
                    else
                    {
                        ClassDBInfo.OK = false;
                        FrmDestinationDbInfo frmdb = new FrmDestinationDbInfo();
                        frmdb.dbtype = CboDbType.Text.ToUpper();
                        frmdb.ShowDialog();
                    }
                    if (ClassDBInfo.OK == true)
                    {
                        Application.DoEvents();
                        FillDestinationTables();

                        if (LvDestination.Items.Count > 0)
                        {
                            btnmap.Enabled = true;
                        }
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


                            if (varTable.Rows.Count > 0 && varTable.Rows[0]["ConType"].ToString().ToUpper() == CboDbType.Text.ToUpper())
                            {
                                FillLvMap();
                            }
                            else
                            {
                                varTable.Rows.Clear();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                //WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "CboDbType_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (lblMasterField.Text == "")
            {
                MessageBox.Show("Please select Master Field!", "Error");
                return ;
            }

            try
            {
                if (varTable != null)
                {


                    string path = Application.StartupPath + @"\FieldsMapping.xml";
                    varTable.WriteXml(path, true);
                    MessageBox.Show("Fields mapping has been saved successfully.", "saved");

                }
            }
            catch(Exception ex)
            {
                //WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "btnsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        DataTable varTable = null;
        private bool CheckDataType(string SourceDT, string DestinationDT)
        {
            bool OK = false;
            
            if (SourceDT.ToUpper() == "DECIMAL" || SourceDT.ToUpper() == "BIGINT" || SourceDT.ToUpper() == "DOUBLE" || SourceDT.ToUpper() == "INTEGER" || SourceDT.ToUpper() == "INT" || SourceDT.ToUpper() == "NUMERIC")
            {
                if(CboDbType.Text=="SQL")
                {
                    if (DestinationDT.ToLower() == "bigint" || DestinationDT.ToLower() == "decimal" || DestinationDT.ToLower() == "float" || DestinationDT.ToLower() == "int" || DestinationDT.ToLower() == "numeric" || DestinationDT.ToLower() == "tinyint" || DestinationDT.ToLower() == "smallint")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text == "Oracle")
                {
                    if (DestinationDT.ToUpper() == "NUMBER" || DestinationDT.ToUpper() == "DECIMAL" || DestinationDT.ToUpper() == "FLOAT" || DestinationDT.ToUpper() == "INT" || DestinationDT.ToUpper() == "INTEGER" || DestinationDT.ToUpper() == "LONG" || DestinationDT.ToUpper() == "SMALLINT")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text.ToUpper() == "MYSQL")
                {
                    if (DestinationDT.ToUpper() == "TINYINT" || DestinationDT.ToUpper() == "SMALLINT" || DestinationDT.ToUpper() == "INT" || DestinationDT.ToUpper() == "BIGINT" || DestinationDT.ToUpper() == "FLOAT" || DestinationDT.ToUpper() == "DOUBLE" || DestinationDT.ToUpper() == "DECIMAL")
                    {
                        OK = true;
                    }
                }
            }
            else if (SourceDT.ToUpper() == "STRING" || SourceDT.ToUpper() == "TEXT" || SourceDT.ToUpper() == "VARCHAR" || SourceDT.ToUpper() == "NVARCHAR")
            {
                if (CboDbType.Text == "SQL")
                {
                    if (DestinationDT.ToUpper() == "VARCHAR" || DestinationDT.ToUpper() == "NVARCHAR" || DestinationDT.ToUpper() == "TEXT")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text == "Oracle")
                {
                    if (DestinationDT.ToUpper() == "VARCHAR" || DestinationDT.ToUpper() == "NVARCHAR" || DestinationDT.ToUpper() == "VARCHAR2" || DestinationDT.ToUpper() == "NVARCHAR2")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text.ToUpper() == "MYSQL")
                {
                    if (DestinationDT.ToUpper() == "VARCHAR" || DestinationDT.ToUpper() == "NVARCHAR" || DestinationDT.ToUpper() == "TEXT")
                    {
                        OK = true;
                    }
                }
            }
            else if (SourceDT.ToUpper() == "DATE" || SourceDT.ToUpper() == "DATETIME")
            {
                if (CboDbType.Text == "SQL")
                {
                    if (DestinationDT.ToUpper() == "DATE" || DestinationDT.ToUpper() == "DATETIME" || DestinationDT.ToUpper() == "DATETIME2")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text == "Oracle")
                {
                    if (DestinationDT.ToUpper() == "DATE")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text.ToUpper() == "MYSQL")
                {
                    if (DestinationDT.ToUpper() == "DATE" || DestinationDT.ToUpper() == "DATETIME")
                    {
                        OK = true;
                    }
                }
            }
            else if (SourceDT.ToUpper() == "BIT" || SourceDT.ToUpper() == "BOOLEAN")
            {
                if (CboDbType.Text == "SQL")
                {
                    if (DestinationDT.ToUpper() == "BIT" || DestinationDT.ToLower() == "bigint" || DestinationDT.ToLower() == "decimal" || DestinationDT.ToLower() == "int" || DestinationDT.ToLower() == "numeric" || DestinationDT.ToLower() == "tinyint" || DestinationDT.ToLower() == "smallint")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text == "Oracle")
                {
                    if (DestinationDT.ToUpper() == "NUMBER" || DestinationDT.ToUpper() == "DECIMAL" || DestinationDT.ToUpper() == "INT" || DestinationDT.ToUpper() == "INTEGER" || DestinationDT.ToUpper() == "LONG" || DestinationDT.ToUpper() == "SMALLINT")
                    {
                        OK = true;
                    }
                }
                else if (CboDbType.Text.ToUpper() == "MYSQL")
                {
                    if (DestinationDT.ToUpper() == "BIT" || DestinationDT.ToUpper() == "TINYINT" || DestinationDT.ToUpper() == "SMALLINT" || DestinationDT.ToUpper() == "INT" || DestinationDT.ToUpper() == "BIGINT" || DestinationDT.ToUpper() == "DECIMAL")
                    {
                        OK = true;
                    }
                }
            }
            else if (SourceDT.ToUpper() == DestinationDT.ToUpper())
            {
                OK = true;
            }
            return OK;
        }
        private void btnmap_Click(object sender, EventArgs e)
        {
            try
            {
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

                if (LvSource.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Please select source column.", "required");
                    LvSource.Focus();
                    return;
                }
                if (LvDestination.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Please select destination column.", "required");
                    LvDestination.Focus();
                    return;
                }

                //if (LvSource.Items[LvSource.FocusedItem.Index].SubItems[1].Text.ToUpper() != LvDestination.Items[LvDestination.FocusedItem.Index].SubItems[1].Text.ToUpper())
                //{
                //    MessageBox.Show("Source and destination column data type should be same.", "required");
                //    LvDestination.Focus();
                //    return;
                //}
                //if (CheckDataType(LvSource.Items[LvSource.FocusedItem.Index].SubItems[1].Text.ToUpper(), LvDestination.Items[LvDestination.FocusedItem.Index].SubItems[1].Text.ToUpper()) == false)
                //{
                //    MessageBox.Show("Source and destination column data type should be same.", "required");
                //    LvDestination.Focus();
                //    return;
                //}

                bool OK = false;
                foreach (DataRow row in varTable.Rows)
                {
                    if (row["SourceColumn"].ToString().ToUpper() == LvSource.Items[LvSource.FocusedItem.Index].Text.ToUpper())
                    {
                        MessageBox.Show("Source column is already mapped.", "required");
                        LvSource.Focus();
                        OK = true;
                        break;
                    }
                }
                if (OK == true)
                {
                    return;
                }

                OK = false;
                foreach (DataRow row in varTable.Rows)
                {
                    if (row["DestinationColumn"].ToString().ToUpper() == LvDestination.Items[LvDestination.FocusedItem.Index].Text.ToUpper())
                    {
                        MessageBox.Show("Destination column is already mapped with " + row["SourceColumn"].ToString().ToUpper() + " source column.", "required");
                        LvDestination.Focus();
                        OK = true;
                        break;
                    }
                }
                if (OK == true)
                {
                    return;
                }


                //varTable.Columns.Add("SourceColumn");
                //varTable.Columns.Add("DestinationColumn");
                //varTable.Columns.Add("ColumnDataType");

                DataRow NewRow = varTable.NewRow();
                NewRow["SourceColumn"] = LvSource.Items[LvSource.FocusedItem.Index].Text;
                NewRow["DestinationColumn"] = LvDestination.Items[LvDestination.FocusedItem.Index].Text;
                NewRow["ColumnDataType"] = LvSource.Items[LvSource.FocusedItem.Index].SubItems[1].Text;
                NewRow["ConType"] = CboDbType.Text.ToUpper();
                NewRow["TableNameSource"] = CboSourceTables.Text;
                NewRow["TableNameDestination"] = CboDestinationTables.Text;

                varTable.Rows.Add(NewRow);

                LvMap.Items.Clear();

                FillLvMap();
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "btnsave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LvSource_Click(object sender, EventArgs e)
        {
            int ICount = 0;
            try
            {
                for (ICount = 0; ICount <= LvSource.Items.Count - 1; ICount++)
                {
                    LvSource.Items[ICount].BackColor = Color.White;
                }
                LvSource.Items[LvSource.FocusedItem.Index].BackColor = Color.Wheat;
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "LvSource_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillLvMap()
        {
            LvMap.Items.Clear();
            if (varTable.Rows.Count > 0)
            {
                if (varTable.Rows[0]["ConType"].ToString().ToUpper() == CboDbType.Text.ToUpper())
                {
                    lblMasterField.Text = System.Configuration.ConfigurationManager.AppSettings["MasterDestinationField"].ToString();
                    lblSourceField.Text = System.Configuration.ConfigurationManager.AppSettings["MasterSourceField"].ToString();


                    foreach (DataRow row in varTable.Rows)
                    {
                        LvMap.Items.Add(row["SourceColumn"].ToString());
                        LvMap.Items[LvMap.Items.Count - 1].SubItems.Add(row["DestinationColumn"].ToString());
                        LvMap.Items[LvMap.Items.Count - 1].SubItems.Add(row["ColumnDataType"].ToString());
                    }
                }
            }
        }
        private void LvDestination_Click(object sender, EventArgs e)
        {
            int ICount = 0;
            try
            {
                for (ICount = 0; ICount <= LvDestination.Items.Count - 1; ICount++)
                {
                    LvDestination.Items[ICount].BackColor = Color.White;
                }
                LvDestination.Items[LvDestination.FocusedItem.Index].BackColor = Color.Wheat;
            }
            catch (Exception ex)
            {
               WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "LvDestination_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LvMap_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    foreach (DataRow row in varTable.Rows)
                    {
                        if (row["SourceColumn"].ToString().ToUpper() == LvMap.Items[LvMap.FocusedItem.Index].Text.ToUpper())
                        {
                            row.Delete();
                            varTable.AcceptChanges();
                            break;
                        }
                    }

                    FillLvMap();
                }
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "LvMap_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnChangeDbInfo_Click(object sender, EventArgs e)
        {
            LvDestination.Items.Clear();
            ClassDBInfo.OK = false;
            FrmDestinationDbInfo frmdb = new FrmDestinationDbInfo();
            frmdb.dbtype = CboDbType.Text.ToUpper();
            frmdb.ShowDialog();
            try
            {
                if (ClassDBInfo.OK == true)
                {
                    Application.DoEvents();
                    FillDestinationFields();
                    if (LvDestination.Items.Count > 0)
                    {
                        btnmap.Enabled = true;
                    }
                }


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
                    FillLvMap();
                }
            }
            catch (Exception ex)
            {

                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "btnChangeDbInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboSourceTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillLvSource();
            }

            catch(Exception ex)
            {

                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "CboSourceTables_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboDestinationTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDestinationFields();
            }
            catch(Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "CboDestinationTables_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bfnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //LvMap.Items.Clear();

                 

                 varTable.Clear(); 

                FillLvMap();
            }


            
            catch (Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "bfnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Split('.')[1] == "db")
                    {

                        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                        config.AppSettings.Settings.Remove("SqlLitDBPath");
                        config.AppSettings.Settings.Add("SqlLitDBPath", openFileDialog1.FileName);
                        config.Save(ConfigurationSaveMode.Minimal);
                        ClassSqlLit.varCon = "Data Source=" + config.AppSettings.Settings["SqlLitDBPath"].Value.ToString() + ";Version=3;datetimeformat=CurrentCulture;";
                        //MessageBox.Show(varTest);

                        FillSourceTables();
                        FillLvSource();
                        // FillTRansferLoggTable();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Valid SQL Lite DB");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(spath, ex.Message + "   " + ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "btnBrowse_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmdSetMaster_Click(object sender, EventArgs e)
        {
         //   if (LvDestination.SelectedItems.Count <= 0)
         //   {
         //       MessageBox.Show("Please select destination column.", "required");
         //       LvDestination.Focus();
         //       return;
         //   }
         //// LvDestination.FocusedItem.Index
         //   lblMasterField.Text = LvDestination.Items[LvDestination.SelectedIndices[0]].Text; 

         //   Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
         //   config.AppSettings.Settings.Remove("MasterField");
         //   config.AppSettings.Settings.Add("MasterField", lblMasterField.Text );
         //   config.Save(ConfigurationSaveMode.Minimal);


            if(LvMap.SelectedItems.Count<=0)
            {
                MessageBox.Show("Please select destination column.", "required");
                LvMap.Focus();
                return;
            }

            lblMasterField.Text = LvMap.Items[LvMap.SelectedIndices[0]].SubItems[1].Text;
            lblSourceField.Text= LvMap.Items[LvMap.SelectedIndices[0]].Text;


            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("MasterDestinationField");
            config.AppSettings.Settings.Add("MasterDestinationField", lblMasterField.Text);
            config.Save(ConfigurationSaveMode.Minimal);
            ClassSqlLit.DestinationMsterColum = config.AppSettings.Settings["MasterDestinationField"].Value.ToString();




            config.AppSettings.Settings.Remove("MasterSourceField");
            config.AppSettings.Settings.Add("MasterSourceField", lblSourceField.Text);
            config.Save(ConfigurationSaveMode.Minimal);
            ClassSqlLit.SourceMasterColum = config.AppSettings.Settings["MasterSourceField"].Value.ToString();
            


        }
    }
}

