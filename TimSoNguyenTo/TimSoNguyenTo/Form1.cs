using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimSoNguyenTo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
       
        public static bool SNT (int n)
        {
            for (int i = 2; i <= n; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        public bool myConvert(TextBox myTextBox, string error)
        {
            bool ktra = Int32.TryParse(txtNhap.Text, out n);
            if (ktra == false)
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }
        private bool isPositive(TextBox myTextBox, double num, string error)
        {
            if (num < 0)
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSlove_Click(object sender, EventArgs e)
        {
           
            if (!myConvert(txtNhap, "Dữ liệu nhập canh 1 phải là số!")) return;
            if (!isPositive(txtNhap,n, "Dữ liệu nhập canh 1 phải là số dương!")) return;
            string ketqua = "";
            for (int i = 1; i < n; i++)
                if (SNT(i))
                    ketqua = ketqua + i.ToString() + " ";
            txtKQ.Text = ketqua;
         }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtNhap, "Dữ liệu nhập canh 1 phải là số!")) return;
            if (!isPositive(txtNhap, n, "Dữ liệu nhập canh 1 phải là số dương!")) return;

            if (SNT(n))
                txtKt.Text = n.ToString() + " là số nguyên tố";
            else
                txtKt.Text = n.ToString() + " không phải là số nguyên tố";

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
                txtNhap.Text = "";
                txtKt.Text = "";
                txtNhap.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }
    }
    
}
