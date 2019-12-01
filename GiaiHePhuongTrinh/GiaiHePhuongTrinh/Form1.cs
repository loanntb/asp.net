using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiHePhuongTrinh
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool myConvert(TextBox myTextBox, string error, out double num)
        {
            bool ktra = double.TryParse(myTextBox.Text, out num);
            if (ktra == false)
            {
                MessageBox.Show(error, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTextBox.Focus();
                myTextBox.Clear();
                return false;
            }
            return true;
        }

        private void btnSlove_Click(object sender, EventArgs e)
        {
            double a1, b1, c1, a2, b2, c2, Dy, Dx, D;
            if (!myConvert(txtA1, "Dữ liệu nhập canh 1 phải là số!", out a1)) return;
            if (!myConvert(txtB1, "Dữ liệu nhập canh 1 phải là số!", out b1)) return;
            if (!myConvert(txtC1, "Dữ liệu nhập canh 1 phải là số!", out c1)) return;
            if (!myConvert(txtA2, "Dữ liệu nhập canh 1 phải là số!", out a2)) return;
            if (!myConvert(txtB2, "Dữ liệu nhập canh 1 phải là số!", out b2)) return;
            if (!myConvert(txtC2, "Dữ liệu nhập canh 1 phải là số!", out c2)) return;
            D = a2 * b2 - b1 * a2;
            Dx = c1 * b2 - b1 * c2;
            Dy = a1 * c2 - c1 * a2;
            if (D == 0 && Dy == 0)
                txtKQx.Text = "Phương trình có vô số nghiệm!";
            if (D == 0 && Dy != 0)
                txtKQx.Text = "Phương trình vô nghiệm!";
            if (D != 0)
            { 
                txtKQx.Text = Convert.ToString( Dx / D);
                txtKQy.Text = Convert.ToString(Dy / D);

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
                txtA1.Text = "";
                txtB1.Text = "";
                txtC1.Text = "";
                txtA2.Text = "";
                txtB2.Text = "";
                txtC2.Text = "";
                txtKQx.Text = "";
                txtKQy.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void txtC2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
