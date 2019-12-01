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
    public partial class frAddStudent : Form
    {
        public frAddStudent()
        {
            InitializeComponent();
        }

        private bool myConvert(TextBox myTextBox, string error, out int num)
        {
            bool ktra = int.TryParse(myTextBox.Text, out num);
            if (ktra == false)
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }
        //isvalidEmail
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

        ////isvalidPhone
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
        //fullInformation
        private bool checkDataEmpty( string error)
        {
           if( txtHoTen.Text == "" || txtNganhHoc.Text == "")
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void RetriveMSV()
        {
            SqlConnection con = new SqlConnection("Initial Catalog=SV;Persist Security Info=True;User ID=sa;Password=123456");
            try{
                String query = "select IDENT_CURRENT('maSV') ";
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    txtMSV.Text = value.ToString();
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
          //  int maSV;
            //if (!myConvert(txtMSV, "Dữ liệu nhập mã sinh viên phải là số!", out maSV)) return;
            if (!checkFormatEmail(txtEmail, "Email sai định dạng. Xin mời nhập lại!")) return;
            if (!checkFormatPhone(txtDienThoai, "Điện thoại sai định dạng. Xin mời nhập lại!")) return;
            if (checkDataEmpty("Bạn chưa nhập tên sinh viên hoặc ngành học của sinh viên.")) return;
             try
              {

                  SqlConnection con = new SqlConnection("Initial Catalog=SV;Persist Security Info=True;User ID=sa;Password=123456");
                  SqlCommand cmd = new SqlCommand("AddStudent", con);
                  cmd.CommandType = CommandType.StoredProcedure;
                  // cmd.Parameters.Add("@maSV", SqlDbType.NChar, 50).Value = txtMSV.Text;

                  RetriveMSV();

                  cmd.Parameters.Add("@hoTen", SqlDbType.NChar, 50).Value = txtHoTen.Text;
                  cmd.Parameters.Add("@ngaySinh", SqlDbType.NChar, 50).Value = txtNgaySinh.Text;
                  cmd.Parameters.Add("@dienThoai", SqlDbType.NChar, 50).Value = txtDienThoai.Text;
                  cmd.Parameters.Add("@email", SqlDbType.NChar, 50).Value = txtEmail.Text;
                  cmd.Parameters.Add("@nganhHoc", SqlDbType.NChar, 50).Value = txtNganhHoc.Text;
                  con.Open();
                  cmd.ExecuteNonQuery();
                  MessageBox.Show("Sinh viên đã được thêm!");
                  con.Close();
              }
              catch ( Exception ex )
              {
                  MessageBox.Show("Lưu sinh viên không thành công!Lỗi:" + ex.Message);
              }
         /*  try {
                SqlConnection con = new SqlConnection("Initial Catalog=SV;Persist Security Info=True;User ID=sa;Password=123456");
                con.Open();
                RetriveMSV();
                string query = ("Insert into[HoTroSinhVien](hoTen, ngaySinh, dienThoai, email, nganhHoc) values hoTen = '" + txtHoTen + "', ngaySinh = '" + txtNgaySinh + "', dienThoai = '" + txtDienThoai + "', email = '" + txtEmail + "', nganhHoc = '" + txtNganhHoc + "'WHERE[maSV] = '" + txtMSV + "'");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sinh viên đã được thêm!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            }*/
        }

        private bool checkFormatEmail(Func<string> toString)
        {
            throw new NotImplementedException();
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
