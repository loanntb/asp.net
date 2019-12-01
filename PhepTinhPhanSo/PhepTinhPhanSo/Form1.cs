using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhepTinhPhanSo
{
    public partial class Form1 : Form
    {
        double tuSo1, mauSo1, tuSo2, mauSo2, tu, mau, uc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void label9_Click(object sender, EventArgs e)
        {

        }

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        public bool myConvert(TextBox myTextBox, string error, out double num)
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
                txtTS1.Text = "";
                txtTS2.Text = "";
                txtMS1.Text = "";
                txtMS2.Text = "";
                txtKQ.Text = "";
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        public static double UCLNLN(double a, double b)
        {
            if (b == 0)
                return a;
            else
                return UCLNLN(b, a % b);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        { 
            if (!myConvert(txtTS1, "Dữ liệu nhập canh 1 phải là số!", out tuSo1)) return;
            if (!myConvert(txtMS1, "Dữ liệu nhập canh 1 phải là số!", out mauSo1)) return;
            if (!myConvert(txtTS2, "Dữ liệu nhập canh 1 phải là số!", out tuSo2)) return;
            if (!myConvert(txtMS2, "Dữ liệu nhập canh 1 phải là số!", out mauSo2)) return;
            tu= (tuSo1 * mauSo2) + (tuSo2 * mauSo1);
            mau = mauSo1 * mauSo2;
            uc = UCLNLN(tu, mau);
            txtKQ.Text = Convert.ToString((tu/mau)/uc);
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtTS1, "Dữ liệu nhập canh 1 phải là số!", out tuSo1)) return;
            if (!myConvert(txtMS1, "Dữ liệu nhập canh 1 phải là số!", out mauSo1)) return;
            if (!myConvert(txtTS2, "Dữ liệu nhập canh 1 phải là số!", out tuSo2)) return;
            if (!myConvert(txtMS2, "Dữ liệu nhập canh 1 phải là số!", out mauSo2)) return;
            tu = (tuSo1 * mauSo2) - (tuSo2 * mauSo1);
            mau = mauSo1 * mauSo2;
            uc = UCLNLN(tu, mau);
            txtKQ.Text = Convert.ToString((tu/mau)/uc);
        }
        private void btnMul_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtTS1, "Dữ liệu nhập canh 1 phải là số!", out tuSo1)) return;
            if (!myConvert(txtMS1, "Dữ liệu nhập canh 1 phải là số!", out mauSo1)) return;
            if (!myConvert(txtTS2, "Dữ liệu nhập canh 1 phải là số!", out tuSo2)) return;
            if (!myConvert(txtMS2, "Dữ liệu nhập canh 1 phải là số!", out mauSo2)) return;
            tu = tuSo1 * tuSo2;
            mau = mauSo1 * mauSo2;
            uc = UCLNLN(tu, mau);
            txtKQ.Text = Convert.ToString((tu / mau) / uc);
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (!myConvert(txtTS1, "Dữ liệu nhập canh 1 phải là số!", out tuSo1)) return;
            if (!myConvert(txtMS1, "Dữ liệu nhập canh 1 phải là số!", out mauSo1)) return;
            if (!myConvert(txtTS2, "Dữ liệu nhập canh 1 phải là số!", out tuSo2)) return;
            if (!myConvert(txtMS2, "Dữ liệu nhập canh 1 phải là số!", out mauSo2)) return;
            tu = tuSo1 * mauSo2;
            mau = mauSo1 * tuSo2;
            uc = UCLNLN(tu, mau);
            txtKQ.Text = Convert.ToString((tu / mau) / uc);
        }
        private void btnSlove_Click(object sender, EventArgs e)
        {
           
        }
    }
    
}
