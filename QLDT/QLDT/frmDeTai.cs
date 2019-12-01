using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLDT
{
    public partial class frmDeTai : Form
    {
        private String conStr = "Initial Catalog=QLDetai;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;
        private SqlCommandBuilder mySqlCommandBuilder;
        private DataTable tblDeTai;
        private bool modeNew;
        public frmDeTai()
        {
            InitializeComponent();
        }
        private void Dislay()
        {
            String sSQL = "SELECT *FROM Detai";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblDeTai = new DataTable();
            mySqlDataAdapter.Fill(tblDeTai);
            dataGridView1.DataSource = tblDeTai;
        }
        private void setControls(bool edit)
        {
            txtTDT.Enabled = edit;
            btnNew.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnSave.Enabled = edit;
            btnExit.Enabled = edit;
        }
        private void frmDeTai_Load(object sender, EventArgs e)
        {
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            Dislay();
            setControls(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            modeNew = true;
            setControls(true);
            txtTDT.Clear();
            txtTDT.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            modeNew = false;
            setControls(true);
            txtTDT.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Chac chan xoa dong da chon?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.No) return;
            int row = dataGridView1.CurrentRow.Index;
            tblDeTai.Rows[row].Delete();
            mySqlDataAdapter.Update(tblDeTai);
           
            Dislay();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (modeNew == true)
                {
                    DataRow newRow = tblDeTai.NewRow();
                    newRow["Tendt"] = txtTDT.Text;
                    tblDeTai.Rows.Add(newRow);
                }
                else
                {
                    int row = dataGridView1.CurrentRow.Index;
                    DataRow editRow = tblDeTai.Rows[row];
                    editRow["Tendt"] = txtTDT.Text;

                }
                mySqlDataAdapter.Update(tblDeTai);
                Dislay();
            }
            catch(Exception ex)
            {
                tblDeTai.RejectChanges();
                MessageBox.Show(ex.Message, "Error");
            }
            setControls(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            setControls(false);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtTDT.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSQL = "Select* from Detai where Tendt like  N'%" + txtSearch.Text + "%'";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblDeTai = new DataTable();
            mySqlDataAdapter.Fill(tblDeTai);
            dataGridView1.DataSource = tblDeTai;
          
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
    }
}
