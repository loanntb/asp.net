using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPhuongTrinhBacNhatClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSlove_Click(object sender, EventArgs e)
        {
            double a, b;
            bool IsNumber;
            IsNumber = double.TryParse(txtA.Text, out a);
            if (!IsNumber)
            {
                MessageBox.Show("Hệ số a không hợp lệ!", "Thông báo");
                txtA.Clear();
                txtA.Focus();
                return;
            }
            IsNumber = double.TryParse(txtB.Text, out b);
            if (!IsNumber)
            {
                MessageBox.Show("Hệ số b không hợp lệ!", "Thông báo");
                txtB.Clear();
                txtB.Focus();
                return;
            }
            txtKQ.Text = PTBN.GiaiPT(a, b);
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
                txtA.Text = "";
                txtB.Text = "";
                txtKQ.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
