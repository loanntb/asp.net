using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chuanhoaxau
{
    public partial class hoten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string StandardString(string strInput)
        {
            strInput = strInput.Trim().ToLower();
            while (strInput.Contains("  "))
                strInput = strInput.Replace("  ", " ");
            string strResult = "";
            string[] arrResult = strInput.Split(' ');
            foreach (string item in arrResult)
                strResult += item.Substring(0, 1).ToUpper() + item.Substring(1) + " ";
            return strResult.TrimEnd();
        }
        protected void btnChuanhoa_Click(object sender, EventArgs e)
        {
            
        }
    }
}