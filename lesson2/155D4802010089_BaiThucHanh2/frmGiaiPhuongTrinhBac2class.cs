using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _155D4802010089_BaiThucHanh2
{
    public partial class frmGiaiPhuongTrinhBac2class : Form
    {
        public frmGiaiPhuongTrinhBac2class()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (!myConvert(txtA, "Dữ liệu nhập vào phải là số!", out a)) return;
            if (!myConvert(txtB, "Dữ liệu nhập vao phải là số!", out b)) return;
            if (!myConvert(txtC, "Dữ liệu nhập vao phải là số!", out c)) return;
            richTxtKQ.Text = PTB2.GPTB2(a, b,c);
        }

        private void button2_Click(object sender, EventArgs e)
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
                txtC.Text = "";
               
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
