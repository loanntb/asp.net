using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoTroSinhVien
{
    public partial class ManagementStudent : Form
    {
        public ManagementStudent()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Initial Catalog=SV;Persist Security Info=True;User ID=sa;Password=123456");
            SqlDataAdapter sda = new SqlDataAdapter("SelectStudent", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds, "a");
            DGVStudent.DataSource = ds.Tables["a"];
        }
        private void DGVStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
            txtMSV.Text = DGVStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = DGVStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNgaySinh.Text = DGVStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDienThoai.Text = DGVStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = DGVStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNganhHoc.Text = DGVStudent.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        public void Dislay()
        {
            SqlConnection con = new SqlConnection("Initial Catalog=SV;Persist Security Info=True;User ID=sa;Password=123456");
            DataTable tb = new DataTable();
            if (txtSearchMaSV.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select *from hotrosinhvien where maSV like '" + txtSearchMaSV.Text + "%'", con);
                sda.Fill(tb);
            }
            else if (txtSearchName.Text.Length > 0)
            {

                SqlDataAdapter sda = new SqlDataAdapter("select *from hotrosinhvien where hoTen like '" + txtSearchName.Text + "%'", con);
                sda.Fill(tb);
            }
            DGVStudent.DataSource = tb;
        }
        private void txtSearchMSV(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            if (txtSearchMaSV.Text.Length > 0)
            {
                Dislay();
            }
            else
            {
                LoadData();
            }
        }
        private void txtSearchHoTen(object sender, EventArgs e)
        {
            txtSearchMaSV.Text = "";
            if (txtSearchName.Text.Length > 0)
            {
                Dislay();
            }
            else
            {
                LoadData();
            }
        }
        private bool existStudent(SqlConnection con, string StudentMaSv)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM [SV].[dbo].[hotrosinhvien] Where [maSV] = '" + StudentMaSv+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return true;
            }else
            {
                return false;
            }

        }
        private bool myConvert(TextBox myTextBox, string error, out int num)
        {
            bool ktra = Int32.TryParse(myTextBox.Text, out num);
            if (ktra == false)
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }
        private bool checkFormatEmail(TextBox myTextBox, string error)
        {
            string Email = txtEmail.Text;
            Regex r = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

            if (!r.IsMatch(Email))
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }
        private bool checkFormatPhone(TextBox myTextBox, string error)
        {
            string Email = txtDienThoai.Text;
            Regex r = new Regex("^\\(?(\\d{3})\\)?[- ]?(\\d{3})[- ]?(\\d{4})$");

            if (!r.IsMatch(Email))
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }
        public void clear()
        {
            txtMSV.Clear();
            txtHoTen.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtNganhHoc.Clear();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maSV;
            if (!myConvert(txtMSV, "Dữ liệu nhập mã sinh viên phải là số!", out maSV)) return;
            if (!checkFormatEmail(txtEmail, "Email sai định dạng. Xin mời nhập lại!")) return;
            if (!checkFormatPhone(txtDienThoai, "Điện thoại sai định dạng. Xin mời nhập lại!")) return;
            try
            {
                SqlConnection con = new SqlConnection("Initial Catalog=SV;Persist Security Info=True;User ID=sa;Password=123456");
                con.Open();
                var sqlQuery = "";
                if (existStudent(con, txtMSV.Text))
                {
                    sqlQuery = @"Update [HoTroSinhVien] set maSV = '" + txtMSV + "',hoTen= '" + txtHoTen + "',ngaySinh= '" + txtNgaySinh + "',dienThoai= '" + txtDienThoai + "',email= '" + txtEmail + "',nganhHoc= '" + txtNganhHoc + "'WHERE [maSV] = '" + txtMSV + "'";

                }
                else
                {

                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Chắc chắn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            if (dr == DialogResult.No)
            {
                txtMSV.Text = "";
                txtHoTen.Text = "";
                txtNgaySinh.Text = "";
                txtDienThoai.Text = "";
                txtEmail.Text = "";
                txtNganhHoc.Text = "";

            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

       
    }
}
