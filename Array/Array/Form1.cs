using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array
{
    public partial class Form1 : Form
    {
        int n = 0,  i;
        // double[] a = new double[100];
        int [] a = new int[100];
        int temp;
        string s, s1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Nhap(object sender, EventArgs e)
        {
            s = txtNhap.Text;
            i = s.LastIndexOf(" ");
            while (i != -1)
            {
                s1 = s.Substring(i);
                s = s.Substring(0, i);
                a[n] = Convert.ToInt32(s1);
                n++;
                i = s.LastIndexOf(" ");
            }
            a[n] = Convert.ToInt32(s);
            s = " ";
            for (i = n; i >= 0; i--)
                s = s + " " + a[i].ToString();
            txtKQ.Text = s.Trim();
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
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            
            if(radioSXT.Checked == true)
            {
                for (i = 0; i < n; i ++)
                    for(int j = i+1; j<=n; j++)
                        if(a[i] > a[j])
                        {
                            temp = a[i];
                            a[i] = a[j];
                            a[j] = temp;
                        }
                s = " ";
                for (i = 0; i <= n; i++)
                    s = s + " " + a[i].ToString();
                txtKQ.Text = s.Trim();
                if(radioSXG.Checked == true)
                {
                    for(i = 0; i<n;i++)
                        for(int j = i+1; j<=n;j++)
                            if(a[i] < a[j])
                            {
                                temp = a[i];
                                a[i] = a[j];
                                a[j] = temp;
                            }
                    s = " ";
                    for (i = 0; i <= n; i++)
                        s = s + " " + a[i].ToString();
                    txtKQ.Text = s.Trim();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            n = 0;
            s = " ";
            txtNhap.ResetText();
            txtKQ.ResetText();
            KhungSapXep.ResetText();
            radioSXG.Checked = false;
            radioSXT.Checked = false;

        }
    }
}
