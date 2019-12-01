using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiHePhuongTrinhClass
{
    class HPT
    {
        static double a1,b1,c1,a2,b2,c2;
        public static string GHPT(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            double  Dy, Dx, D;
            string kq = "";
            D = a2 * b2 - b1 * a2;
            Dx = c1 * b2 - b1 * c2;
            Dy = a1 * c2 - c1 * a2;
            if (D == 0 && Dy == 0)
                kq = "Phương trình có vô số nghiệm!";
            if (D == 0 && Dy != 0)
                kq = "Phương trình vô nghiệm!";
            if (D != 0)
            {
               kq = Convert.ToString(Dx / D);
               kq = Convert.ToString(Dy / D);

            }
            return kq;
        }
    }
}
