using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTongS_n_
{
    public partial class Form1 : Form
    {
        double s;
        int i, n;
        public Form1()
        {
            InitializeComponent();
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
                txtKQ.Text = "";
                txtNhap.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void btnSlove_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtNhap, "Dữ liệu nhập canh 1 phải là số!")) return;
            if (!isPositive(txtNhap, n, "Dữ liệu nhập canh 1 phải là số dương!")) return;
            for (i = 1; i <= n; i++)
            {
                s += 1.0 / (2 * i + 1);
                txtKQ.Text = s.ToString();
            }
        }
    }
}
