using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPhuongTrinhBacNhatClass
{
    class PTBN
    {
        static double a, b;
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
       
       
        public  static string GiaiPT(double a, double b)
        {
            String kq = "";
            if (a == 0)
            {
                if (b == 0)
                {
                    kq = "Phuong trinh co vo so nghiem";
                }
                else
                {
                    kq = "Phuong trinh vo nghiem";
                }
            }

            else
            {
                kq = "Phương trình có duy nhất nghiệm "+ (-b / a);

            }
            return kq;
        }
    }

}
