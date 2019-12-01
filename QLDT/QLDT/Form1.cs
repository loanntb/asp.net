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
    public partial class Form1 : Form
    {
        private string conStr = "Initial Catalog=QLDetai;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapte;
        private SqlCommandBuilder mySqlCommandBuilder;
        private bool modeNew;
        private DataTable tblSinhvien, tblDetai, tblGiangVien;
        public Form1()
        {
            InitializeComponent();
        }
        private void Dislay()
        {
            string sSQL = "SELECT *FROM [QLDetai].[dbo].[Sinhvien]";
            mySqlDataAdapte = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapte);
            tblSinhvien = new DataTable();
            mySqlDataAdapte.Fill(tblSinhvien);
            dataGridView1.DataSource = tblSinhvien;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMSV.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHT.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDate.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbDT.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbGV.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPoint.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtGC.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = true;
            txtMSV.Clear();
            txtDate.Clear();
            txtHT.Clear();
            txtPoint.Clear();
            txtGC.Clear();
            txtMSV.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = false;
            txtMSV.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            tblSinhvien.Rows[row].Delete();
            mySqlDataAdapte.Update(tblSinhvien);
            Dislay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (modeNew)
                {
                    DataRow newRow = tblSinhvien.NewRow();
                    newRow["Ngaysinh"] = txtDate.Text;
                    newRow["Ghichu"] = txtGC.Text;
                    newRow["Hoten"] = txtHT.Text;
                    newRow["Masv"] = txtMSV.Text;
                    newRow["Diem"] = txtPoint.Text;
                    tblSinhvien.Rows.Add(newRow);
                  
                }
                else
                {
                    int row = dataGridView1.CurrentRow.Index;
                    DataRow editRow = tblSinhvien.Rows[row];
                    editRow["Ngaysinh"] = txtDate.Text;
                    editRow["Ghichu"] = txtGC.Text;
                    editRow["Hoten"] = txtHT.Text;
                    editRow["Masv"] = txtMSV.Text;
                    editRow["Diem"] = txtPoint.Text;
                   
                }
                
                mySqlDataAdapte.Update(tblSinhvien);
                Dislay();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            setControls(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sSQL = "  SELECT *FROM Sinhvien WHERE Hoten LIKE N'%"+txtSearch.Text+"%'";
            mySqlDataAdapte = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapte);
            tblSinhvien = new DataTable();
            mySqlDataAdapte.Fill(tblSinhvien);
            dataGridView1.DataSource = tblSinhvien;

        }

        private void setControls(bool edit)
        {
            txtDate.Enabled = edit;
            txtGC.Enabled = edit;
            txtHT.Enabled = edit;
            txtMSV.Enabled = edit;  
            txtPoint.Enabled = edit;
            btnExit.Enabled = edit;
            btnSave.Enabled = edit;
            btnDelete.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnNew.Enabled = !edit;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            string sSQL = "SELECT *FROM Detai";
            mySqlDataAdapte = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapte);
           
            tblDetai = new DataTable();
            mySqlDataAdapte.Fill(tblDetai);
            cmbDT.DataSource = tblDetai;
            cmbDT.DisplayMember = "Tendt";
            cmbDT.ValueMember = "Madt";
            //
            sSQL = "SELECT *FROM [dbo].[Giangvien]";
            mySqlDataAdapte = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapte);
            tblGiangVien = new DataTable();
            mySqlDataAdapte.Fill(tblGiangVien);
            cmbGV.DataSource = tblGiangVien;
            cmbGV.DataSource = tblGiangVien;
            cmbGV.DisplayMember = "Hoten";
            cmbGV.ValueMember = "Magv";

            Dislay();
            setControls(false);
        }
    }
}
