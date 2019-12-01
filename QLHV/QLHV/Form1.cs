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
namespace QLHV
{
    public partial class Form1 : Form
    {
        private string conStr = "Data Source=DESKTOP-L932V61\\SQLEXPRESS;Initial Catalog=QLHV;Persist Security Info=True;User ID=sa;Password=123456";
        private SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;
        private SqlCommandBuilder mySqlCommandBuilder;
        private bool modeNew;
        private DataTable tblNganhdaotao, tblKhoa;
        public Form1()
        {
            InitializeComponent();
        }
        private void Dislay()
        {
            string sSQL = "SELECT *FROM [QLHV].[dbo].[Nganhdaotao]";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblNganhdaotao = new DataTable();
            mySqlDataAdapter.Fill(tblNganhdaotao);
            dataGridView1.DataSource = tblNganhdaotao;
        }
        private void setControls(bool edit)
        {
            txtTennganh.Enabled = edit;
            btnSave.Enabled = edit;
            btnHuy.Enabled = edit;
            btnNew.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnXoa.Enabled = !edit;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            String sSQL = "SELECT *FROM [QLHV].[dbo].[Khoadaotao]";
            mySqlDataAdapter = new SqlDataAdapter(sSQL, mySqlConnection);
            mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
            tblKhoa= new DataTable();
            mySqlDataAdapter.Fill(tblKhoa);
            comboBox1.DataSource = tblKhoa;
            comboBox1.DisplayMember = "Tenkhoa";
            comboBox1.ValueMember = "Makhoa";
            Dislay();
            setControls(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            tblNganhdaotao.Rows[row].Delete();
            mySqlDataAdapter.Update(tblNganhdaotao);
            Dislay();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = false;
            txtTennganh.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setControls(true);
            modeNew = true;
            txtTennganh.Clear();
            txtTennganh.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControls(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (modeNew)
            {
                DataRow newRow = tblNganhdaotao.NewRow();
                newRow["Tennganh"] = txtTennganh.Text;
                tblNganhdaotao.Rows.Add(newRow);
            }
            else
            {
                int row = dataGridView1.CurrentRow.Index;
                DataRow editRow = tblNganhdaotao.Rows[row];
                editRow["Tennganh"] = txtTennganh.Text;

            }
            mySqlDataAdapter.Update(tblNganhdaotao);
            Dislay();
            setControls(false);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTennganh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
