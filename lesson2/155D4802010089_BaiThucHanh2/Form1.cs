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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("C Program");
            checkedListBox1.Items.Add("C++ Program");
            checkedListBox1.Items.Add("Java Program");
            checkedListBox1.Items.Add("Matlab Program");
            checkedListBox1.Items.Add("Python Program");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i) == true)
                {
                    checkedListBox2.Items.Add(checkedListBox1.Items[i]);
                }
            }

            for(int i = checkedListBox1.Items.Count - 1; i>=0;i--)
            {
                if(checkedListBox1.GetItemChecked(i) == true)
                {
                    checkedListBox1.Items.RemoveAt(i);
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                checkBox1.Text = "Bỏ chọn tất cả";
            }else
            {
                checkBox1.Text = "Chọn tất cả";
            }
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if(checkedListBox2.GetItemChecked(i) == true)
                {
                    checkedListBox1.Items.Add(checkedListBox2.Items[i]);
                }
            }
            for(int i = checkedListBox2.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox2.GetItemChecked(i) == true)
                {
                    checkedListBox2.Items.RemoveAt(i);
                }
            }
        }
    }
}
