using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _155D4802010089_BaiThucHanh2
{
    class PTB2
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public double Delta => B * B - 4 * A * C;

        public static string GPTB2(double a, double b, double c)
        {
            double delta;
            String kq = "";
            if (a == 0 & b == 0 & c == 0)
            {
                kq = "Phuong trinh co vo so nghiem";
            }
            else if (a == 0)
            {
                kq = "Phương trình có duy nhất nghiệm " + (-c / b);

            }
            else
            {
                delta = b * b - 4 * a * c;
                if (delta < 0)
                {
                    kq = "Phuong trinh vo nghiem";
                }
                else if (delta == 0)
                {
                    kq = "Phuong trinh co 2 nghiem kep" + (-b / (2 * a));
                }
                else
                {
                    kq = "Phuong trinh co 2 nghiem phan biet" + (-b + Math.Sqrt(delta));
                }
               
            }
            return kq;
        }
    }
}