using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPhuongTrinhBacNhat
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
                textA.Text = "";
                textB.Text = "";
                textKQ.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void btnSlove_Click(object sender, EventArgs e)
        {
            double a, b;
            bool IsNumber;
            IsNumber = double.TryParse(textA.Text, out a);
            if (!IsNumber)
            {
                MessageBox.Show("Hệ số a không hợp lệ!", "Thông báo");
                textA.Clear();
                textA.Focus();
                return;
            }
            IsNumber = double.TryParse(textB.Text, out b);
            if (!IsNumber)
            {
                MessageBox.Show("Hệ số b không hợp lệ!", "Thông báo");
                textB.Clear();
                textB.Focus();
                return;
            }
            if (a == 0)
            {
                if (b == 0)
                {
                    textKQ.Text = "Phương trình có vô số nghiệm!";
                }
                else
                {
                    textKQ.Text = "Phương trình vô nghiệm!";
                }
            }

            else
            {
                textKQ.Text = Convert.ToString(-b / a);

            }
        }
    } 
}
