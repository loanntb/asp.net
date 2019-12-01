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
    public partial class frmGiangVien : Form
    {
        private string conStr = "Initial Catalog=QLDetai;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;
        private SqlCommandBuilder mySqlCommandBuilder;
        private DataTable tblGiangVien;
        private bool modeNew;
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void Dislay()
        {
            String sSQL = "SELECT *FROM [dbo].[Giangvien]";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblGiangVien = new DataTable();
            mySqlDataAdapter.Fill(tblGiangVien);
            dataGridView1.DataSource = tblGiangVien;
        }
        private void setControls(bool edit)
        {
            txtGC.Enabled = edit;
            txtHT.Enabled = edit;
            txtPhone.Enabled = edit;
            btnNew.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnSave.Enabled = edit;
            btnExit.Enabled = edit;
          
        }
        private void frmGiangVien_Load(object sender, EventArgs e)
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
            txtGC.Clear();
            txtHT.Clear();
            txtPhone.Clear();
            txtHT.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            modeNew = false;
            setControls(true);
            txtHT.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Chac chan xoa dong duoc chon khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.No) return;
            int row = dataGridView1.CurrentRow.Index;
            tblGiangVien.Rows[row].Delete();
            mySqlDataAdapter.Update(tblGiangVien);
            Dislay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (modeNew)
                {
                    DataRow newRow = tblGiangVien.NewRow();
                    newRow["Hoten"] = txtHT.Text;
                    newRow["Dienthoai"] = txtPhone.Text;
                    newRow["Ghichu"] = txtGC.Text;
                    tblGiangVien.Rows.Add(newRow);
                }
                else
                {
                    int row = dataGridView1.CurrentRow.Index;
                    DataRow editRow = tblGiangVien.Rows[row];
                    editRow["Hoten"] = txtHT.Text;
                    editRow["Dienthoai"] = txtPhone.Text;
                    editRow["Ghichu"] = txtGC.Text;
                }
                mySqlDataAdapter.Update(tblGiangVien);
                Dislay();
            }
            catch(Exception ex)
            {
                tblGiangVien.RejectChanges();
                MessageBox.Show(ex.Message, "Error");
            }
            setControls(false);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            setControls(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtHT.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGC.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
