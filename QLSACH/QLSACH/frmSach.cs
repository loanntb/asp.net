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
    public partial class frmSach : Form
    {
        private string conStr = "Data Source=DESKTOP-L932V61\\SQLEXPRESS;Initial Catalog=QLSach;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;
        private SqlCommandBuilder mySqlCommandBuilde;
        private bool modeNew;
        private DataTable tblSach, tblLoaisach, tblNhaxb;
        public frmSach()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtMasach.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTensach.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTacgia.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSotrang.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtGhichu.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
        private void setControls(bool edit)
        {
            txtGhichu.Enabled = edit;
            txtMasach.Enabled = edit;
            txtSearch.Enabled = edit;
            txtSotrang.Enabled = edit;
            txtTacgia.Enabled = edit;
            txtTensach.Enabled = edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;
            btnDelete.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnNew.Enabled = !edit;
            btnCancel.Enabled = edit;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = true;
            txtGhichu.Clear();
            txtMasach.Clear();
            txtSotrang.Clear();
            txtTensach.Clear();
            txtTacgia.Clear();
            txtMasach.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = false;
            txtMasach.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            tblSach.Rows[row].Delete();
            mySqlDataAdapter.Update(tblSach);
            Dislay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setControls(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (modeNew)
            {
                DataRow newRow = tblSach.NewRow();
                newRow["Ghichu"] = txtGhichu.Text;
                newRow["Masach"] = txtMasach.Text;
                newRow["Sotrang"] = txtSotrang.Text;
                newRow["Tacgia"] = txtTacgia.Text;
                newRow["Tensach"] = txtTensach.Text;
                tblSach.Rows.Add(newRow);

            }
            else
            {
                int row = dataGridView1.CurrentRow.Index;
                DataRow editRow = tblSach.Rows[row];
                editRow["Ghichu"] = txtGhichu.Text;
                editRow["Masach"] = txtMasach.Text;
                editRow["Sotrang"] = txtSotrang.Text;
                editRow["Tacgia"] = txtTacgia.Text;
                editRow["Tensach"] = txtTensach.Text;
            }
            mySqlDataAdapter.Update(tblSach);
            Dislay();
            setControls(false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dislay()
        {
            string sSQL = "SELECT * FROM [QLSach].[dbo].[Sach]";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilde = new SqlCommandBuilder(mySqlDataAdapter);
            tblSach = new DataTable();
            mySqlDataAdapter.Fill(tblSach);
            dataGridView1.DataSource = tblSach;
        }
        private void frmSach_Load(object sender, EventArgs e)
        {
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            //
            string sSql = "SELECT *FROM [QLSach].[dbo].[Loaisach]";
            mySqlDataAdapter = new SqlDataAdapter(sSql, mySqlConnection);
            mySqlCommandBuilde = new SqlCommandBuilder(mySqlDataAdapter);
            tblLoaisach = new DataTable();
            mySqlDataAdapter.Fill(tblLoaisach);
            comboBox1.DataSource = tblLoaisach;
            comboBox1.DisplayMember = "tenloai";
            comboBox1.ValueMember = "Maloai";
            //
            sSql = "SELECT * FROM [QLSach].[dbo].[Nhaxb]";
            mySqlDataAdapter = new SqlDataAdapter(sSql, mySqlConnection);
            mySqlCommandBuilde = new SqlCommandBuilder(mySqlDataAdapter);
            tblNhaxb = new DataTable();
            mySqlDataAdapter.Fill(tblNhaxb);
            comboBox2.DataSource = tblNhaxb;
            comboBox2.DisplayMember = "Tenxb";
            comboBox2.ValueMember = "Maxb";
            Dislay();
        }
    }
}
