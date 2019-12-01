using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _155D4802010089SOPHUC
{
    public partial class Form1 : Form
    {
        public Form1()
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double realvalue1, imaginary1, realvalue2, imaginary2;
            if (!myConvert(txtST1, "Dữ liệu nhập vao phải là số!", out realvalue1)) return;
            if (!myConvert(txtST2, "Dữ liệu nhập vao phải là số!", out realvalue2)) return;
            if (!myConvert(txtSA1, "Dữ liệu nhập vao phải là số!", out imaginary1)) return;
            if (!myConvert(txtSA2, "Dữ liệu nhập vao phải là số!", out imaginary2)) return;
            SoPhuc complex = new SoPhuc(realvalue1, imaginary1);
            SoPhuc complexx = new SoPhuc(realvalue2, imaginary2);
            txtKQ.Text = complex + complexx;
        }
    }
}
