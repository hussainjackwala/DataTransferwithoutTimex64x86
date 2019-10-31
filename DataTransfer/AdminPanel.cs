using System;

using System.Windows.Forms;
using System.Diagnostics;
namespace DataTransfer
{
    public partial class AdminPanel : Form
    {
       
        public AdminPanel()
        {
            InitializeComponent();
            Tm.Enabled = true;
            Tm.Interval = 60000;

        }

       
        

        private void btn_FieldMapping_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMapFields frmmp = new FrmMapFields();
                frmmp.ShowDialog();
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DataTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                frmDataTransfer frmdt = new frmDataTransfer();
                frmdt.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            Process[] p = System.Diagnostics.Process.GetProcessesByName("htas");

            if (p.Length == 0)
            {

                Tm.Enabled = false;
                Application.Exit();



            }
        }
    }
}
