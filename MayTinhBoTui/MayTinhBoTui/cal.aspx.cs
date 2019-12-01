using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MayTinhBoTui
{
    public partial class cal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //float num1, result;
        // int count;
        string sign;
        double val1;
        double val2;
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            val1 = 0;
            val2 = 0;
            sign = "";
        }

        protected void btnSum_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "")
            {
                //num1 = float.Parse(txtResult.Text);
                // txtResult.Text = "";
                // txtResult.Focus();
                //  count = 2;
                sign = "+";
                val1 = double.Parse(txtResult.Text);
                txtResult.Text = "";
            }
        }

        protected void btn0_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn0.Text;
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn1.Text;
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn2.Text;
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn3.Text;
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn4.Text;
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn5.Text;
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn6.Text;
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn7.Text;
        }

        protected void btn8_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn8.Text;
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "")
            {
                sign = "-";
                val1 = double.Parse(txtResult.Text);
                txtResult.Text = "";
            }
        }

        protected void btnMul_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "")
            {
                // num1 = float.Parse(txtResult.Text);
                //  txtResult.Text = "";
                //  txtResult.Focus();
                //  count = 3;
                sign = "*";
                val1 = double.Parse(txtResult.Text);
                txtResult.Text = "";
            }
        }

        protected void btnDiv_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "")
            {
                // num1 = float.Parse(txtResult.Text);
                // txtResult.Text = "";
                // txtResult.Focus();
                // count = 4;
                sign = "/";
                val1 = double.Parse(txtResult.Text);
                txtResult.Text = "";
            }
        }
        public void compute(int count)
        {
            /*switch (count)
            {
                case 1:
                    result = num1 - float.Parse(txtResult.Text);
                    txtResult.Text = result.ToString();
                    break;
                case 2:
                    result = num1 + float.Parse(txtResult.Text);
                    txtResult.Text = result.ToString();
                    break;
                case 3:
                    result = num1 * float.Parse(txtResult.Text);
                    txtResult.Text = result.ToString();
                    break;
                case 4:
                    result = num1 / float.Parse(txtResult.Text);
                    txtResult.Text = result.ToString();
                    break;
                default:
                    break;
            }*/
        }
        protected void btnE_Click(object sender, EventArgs e)
        {
            val2 = double.Parse(txtResult.Text);
            double result;
            if (sign == "+")
            {
                result = val1 + val2;
                txtResult.Text = result.ToString();
            }
            else if (sign == "-")
            {
                result = val1 - val2;
                txtResult.Text = result.ToString();
            }
            else if (sign == "*")
            {
                result = val1 * val2;
                txtResult.Text = result.ToString();
            }
            else
            {
                result = val1 / val2;
                txtResult.Text = result.ToString();
            }
            //compute(count);
        }

        protected void btn9_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + btn9.Text;
        }
    }
}