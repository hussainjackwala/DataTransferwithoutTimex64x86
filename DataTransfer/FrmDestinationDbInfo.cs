using System;

using System.Data;

using System.Windows.Forms;
using DataTransfer.Common;
using System.IO;

namespace DataTransfer
{
    public partial class FrmDestinationDbInfo : Form
    {
        public FrmDestinationDbInfo()
        {
            InitializeComponent();
        }
        public string dbtype = "";
        private void FrmDestinationDbInfo_Load(object sender, EventArgs e)
        {
            if (dbtype == "ORACLE")
            {
                txtdbName.Enabled = false;
            }
            else
            {
                txtdbName.Enabled = true;
            }
            lbldbInfo.Text = lbldbInfo.Text + " - " + dbtype;
            string path = Application.StartupPath + @"\DbConInfo.xml";
            if (File.Exists(path) == true)
            {
                DataTable table = new DataTable();
                table.TableName = "TblConnection";
                table.Columns.Add("ServerName");
                table.Columns.Add("DbName");
                table.Columns.Add("Uid");
                table.Columns.Add("Pwd");
                table.Columns.Add("Type");

                table.ReadXml(path);
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0]["Type"].ToString().ToUpper() == dbtype.ToUpper())
                    {
                        txtServer.Text = table.Rows[0]["ServerName"].ToString();
                        txtdbName.Text = table.Rows[0]["DbName"].ToString();
                        txtuid.Text = table.Rows[0]["Uid"].ToString();
                        txtPwd.Text = table.Rows[0]["Pwd"].ToString();
                    }
                }
                table.Dispose();

            }
        }

        private void btnmap_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "")
            {
                MessageBox.Show("Please enter server name.", "required");
                txtServer.Focus();
                return;
            }
            if (dbtype != "ORACLE" && txtdbName.Text == "")
            {
                MessageBox.Show("Please enter db name.", "required");
                txtdbName.Focus();
                return;
            }
            if(txtuid.Text == "")
            {
                MessageBox.Show("Please enter user id.", "required");
                txtuid.Focus();
                return;
            }
            if (txtPwd.Text == "")
            {
                MessageBox.Show("Please enter password.", "required");
                txtPwd.Focus();
                return;
            }

            ClassDBInfo.DBType = dbtype;
            ClassDBInfo.Server = txtServer.Text.Trim();
            ClassDBInfo.DbName = txtdbName.Text.Trim();
            ClassDBInfo.UID = txtuid.Text.Trim();
            ClassDBInfo.Pwd = txtPwd.Text.Trim();
            ClassDBInfo.OK = true;

            DataTable table = new DataTable();
            table.TableName = "TblConnection";
            table.Columns.Add("ServerName");
            table.Columns.Add("DbName");
            table.Columns.Add("Uid");
            table.Columns.Add("Pwd");
            table.Columns.Add("Type");

            DataRow NewRow = table.NewRow();
            NewRow["ServerName"] = txtServer.Text.Trim();
            NewRow["DbName"] = txtdbName.Text.Trim();
            NewRow["Uid"] = txtuid.Text.Trim();
            NewRow["Pwd"] = txtPwd.Text.Trim();
            NewRow["Type"] = dbtype;

            table.Rows.Add(NewRow);

            string path = Application.StartupPath + @"\DbConInfo.xml";
            table.WriteXml(path, true);
            
            
            table.Dispose();
            MessageBox.Show("Database configuration has done successfully");

            this.Close();
        }
    }
}
