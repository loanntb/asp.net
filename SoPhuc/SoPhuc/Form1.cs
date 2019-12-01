using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoPhuc
{
    public partial class Form1 : Form
    {
        double realvalue1, imaginary1, imaginary2, realvalue2;
        private object realvalue;

        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        class SoPhuc
        {
            public double real;
            public double imaginary;



            public SoPhuc(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public static SoPhuc operator +(SoPhuc v1, SoPhuc v2)
            {
                return new SoPhuc(v1.real + v2.real, v1.imaginary + v2.imaginary);
            }
            public static SoPhuc operator -(SoPhuc v1, SoPhuc v2)
            {
                return new SoPhuc(v1.real - v2.real, v1.imaginary - v2.imaginary);
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtST1, "Dữ liệu nhập vao phải là số!", out realvalue1)) return;
            if (!myConvert(txtST2, "Dữ liệu nhập vao phải là số!", out realvalue2)) return;
            if (!myConvert(txtSA1, "Dữ liệu nhập vao phải là số!", out imaginary1)) return;
            if (!myConvert(txtSA2, "Dữ liệu nhập vao phải là số!", out imaginary2)) return;
            SoPhuc complex = new SoPhuc(realvalue1, imaginary1);
            SoPhuc complexx = new SoPhuc(realvalue2, imaginary2);
            SoPhuc result = complexx - complex;
            txtKQ.Text = result.real + "," + result.imaginary;
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
                txtKQ.Text = "";
                txtSA1.Text = "";
                txtSA2.Text = "";
                txtST1.Text = "";
                txtST2.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtST1, "Dữ liệu nhập canh 1 phải là số!", out realvalue1)) return;
            if (!myConvert(txtST2, "Dữ liệu nhập canh 1 phải là số!", out realvalue2)) return;
            if (!myConvert(txtSA1, "Dữ liệu nhập canh 1 phải là số!", out imaginary1)) return;
            if (!myConvert(txtSA2, "Dữ liệu nhập canh 1 phải là số!", out imaginary2)) return;
            SoPhuc complex = new SoPhuc (realvalue1, imaginary1);
            SoPhuc complexx = new SoPhuc(realvalue2, imaginary2);
            SoPhuc result = complexx + complex;
            txtKQ.Text = result.real + "," + result.imaginary;
        }
    }
    
}
