using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLSACH
{
    public partial class frmLoaiSach : Form
    {
        private string  conStr= "Data Source=DESKTOP-L932V61\\SQLEXPRESS;Initial Catalog=QLSach;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;
        private SqlCommandBuilder mySqlCommandBuilder;
        private bool modeNew;
        private DataTable tblLoaisach;
        public frmLoaiSach()
        {
            InitializeComponent();
        }
        private void Dislay()
        {
            string sSql = "SELECT *FROM [QLSach].[dbo].[Loaisach] ";
            mySqlDataAdapter = new SqlDataAdapter(sSql, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblLoaisach = new DataTable();
            mySqlDataAdapter.Fill(tblLoaisach);
            dataGridView1.DataSource = tblLoaisach;
        }
        private void setControls(bool edit)
        {
            txttenloai.Enabled = edit;
            btnSave.Enabled = edit;
            btnEdit.Enabled = !edit;
            btnDelete.Enabled = !edit;
            btnNew.Enabled = !edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;


        }
        private void frmLoaiSach_Load(object sender, EventArgs e)
        {
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            Dislay();
            setControls(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            setControls(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = true;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = false;
            
            textBox1.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            tblLoaisach.Rows[row].Delete();
            mySqlDataAdapter.Update(tblLoaisach);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (modeNew)
                {
                    DataRow newRow = tblLoaisach.NewRow();
                    newRow["tenloai"] = textBox1.Text;
                    tblLoaisach.Rows.Add(newRow);
                }
                else
                {
                    int row = dataGridView1.CurrentCell.RowIndex;
                    DataRow editRow = tblLoaisach.Rows[row];
                    editRow["tenloai"] = textBox1.Text;
                }
                mySqlDataAdapter.Update(tblLoaisach);
                Dislay();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi");
            }
            setControls(false);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String sSQL = "SELECT* FROM Loaisach WHERE tenloai like N'%"+txtSearch.Text+"%'";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            tblLoaisach = new DataTable();
            
            mySqlDataAdapter.Fill(tblLoaisach);
            dataGridView1.DataSource=tblLoaisach;
        }
    }
}
