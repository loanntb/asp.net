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
    public partial class frmComboxBox : Form
    {
        public frmComboxBox()
        {
            InitializeComponent();
        }

        private void frmComboxBox_Load(object sender, EventArgs e)
        {
            FontFamily[] ff = FontFamily.Families;
            for (int i = 0; i < ff.Length; i++)
            {
                if (ff[i].Name.Trim() != "")
                    cboFont.Items.Add(ff[i].Name);
            }
            cboStyle.Items.Add("Regular");
            cboStyle.Items.Add("Italic");
            cboStyle.Items.Add("Bold");
            cboStyle.Items.Add("Bold Italic");

            for (int i = 8; i <= 72; i++)
            {
                cboSize.Items.Add(i);
            }
        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFont.SelectedIndex == -1) return;
            Sample.Font = new Font(cboFont.Text, cboFont.Font.Size,Sample.Font.Style);
        }

        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStyle.SelectedIndex == 0)
                Sample.Font = new Font(cboFont.Text, Sample.Font.Size, FontStyle.Regular);

            if (cboStyle.SelectedIndex == 1)
                Sample.Font = new Font(cboFont.Text, Sample.Font.Size, FontStyle.Italic);

            if (cboStyle.SelectedIndex == 2)
                Sample.Font = new Font(cboFont.Text, Sample.Font.Size, FontStyle.Bold);

            if (cboStyle.SelectedIndex == 3)
                Sample.Font = new Font(cboFont.Text, Sample.Font.Size, FontStyle.Bold & FontStyle.Italic);
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedIndex == -1) return;
            Sample.Font = new Font(Sample.Font.Name, (float)Convert.ToDouble(cboSize.Text), Sample.Font.Style);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
