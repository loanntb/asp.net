using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoTroSinhVien
{
    public partial class Maincs : Form
    {
        public Maincs()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frAddStudent ad = new frAddStudent();
            ad.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ManagementStudent ma = new ManagementStudent();
            ma.ShowDialog();
        }
    }
}
