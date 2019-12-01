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
namespace QLHV
{
    public partial class frmHocVien : Form
    {
        private string conStr = "Data Source=DESKTOP-L932V61\\SQLEXPRESS;Initial Catalog=QLHV;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;
        private SqlCommandBuilder mySqlCommandBuilder;
        private bool modeNew;
        private DataTable tblNganhdaotao, tblKhoa, tblHocvien;
        public frmHocVien()
        {
            InitializeComponent();
        }
        private void Dislay()
        {
            string sSQL = "SELECT * FROM [QLHV].[dbo].[Hocvien]";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblHocvien = new DataTable();
            mySqlDataAdapter.Fill(tblHocvien);
            dataGridView1.DataSource = tblHocvien;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMahv.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtHoten.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNgaysinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGioitinh.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtKhoahoc.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtGhi.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM [QLHV].[dbo].[Hocvien] WHERE Hoten like '%"+txtSearch.Text+"%'";
            mySqlDataAdapter = new SqlDataAdapter(sql, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblHocvien = new DataTable();
            mySqlDataAdapter.Fill(tblHocvien);
            dataGridView1.DataSource = tblHocvien;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControls(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (modeNew)
            {
                DataRow newRow = tblHocvien.NewRow();
                newRow["Diachi"] = txtDiachi.Text;
                newRow["Ghichu"] = txtGhi.Text;
                newRow["Gioitinh"] = txtGioitinh.Text;
                newRow["Hoten"] = txtHoten.Text;
                newRow["Khoahoc"] = txtKhoahoc.Text;
                newRow["Mahv"] = txtMahv.Text;
                newRow["Ngaysinh"] = txtNgaysinh.Text;
                tblHocvien.Rows.Add(newRow);
            }
            else
            {
                int row = dataGridView1.CurrentRow.Index;
                DataRow editRow = tblHocvien.Rows[row];
                editRow["Diachi"] = txtDiachi.Text;
                editRow["Ghichu"] = txtGhi.Text;
                editRow["Gioitinh"] = txtGioitinh.Text;
                editRow["Hoten"] = txtHoten.Text;
                editRow["Khoahoc"] = txtKhoahoc.Text;
                editRow["Mahv"] = txtMahv.Text;
                editRow["Ngaysinh"] = txtNgaysinh.Text;
            }
            mySqlDataAdapter.Update(tblHocvien);
            Dislay();
            setControls(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = true;
            txtGhi.Clear();
            txtDiachi.Clear();
            txtGioitinh.Clear(); 
            txtHoten.Clear();
            txtKhoahoc.Clear();
            txtMahv.Clear();
            txtNgaysinh.Clear();
            txtMahv.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = false;
            txtMahv.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            tblHocvien.Rows[row].Delete();
            mySqlDataAdapter.Update(tblHocvien);
            Dislay();
            setControls(false);
        }

        private void setControls(bool edit)
        {
            txtDiachi.Enabled = edit;
            txtGhi.Enabled = edit;
            txtGioitinh.Enabled = edit;
            txtHoten.Enabled = edit;
            txtKhoahoc.Enabled = edit;
            txtMahv.Enabled = edit;
            txtNgaysinh.Enabled = edit;
            btnSave.Enabled = edit;
            btnHuy.Enabled = edit;
            btnXoa.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnNew.Enabled = !edit;

        }
        private void frmHocVien_Load(object sender, EventArgs e)
        {
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            string sSQL = "SELECT *FROM [QLHV].[dbo].[Nganhdaotao]";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblNganhdaotao = new DataTable();
            mySqlDataAdapter.Fill(tblNganhdaotao);
            comboBox1.DataSource = tblNganhdaotao;
            comboBox1.DisplayMember = "Tennganh";
            comboBox1.ValueMember = "Makhoa";


            Dislay();
            setControls(false);
        }
    }
}
