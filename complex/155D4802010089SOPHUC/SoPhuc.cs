using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _155D4802010089SOPHUC
{
   public class SoPhuc
    {
        private double real;
        private double imaginary;



        public SoPhuc(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public static SoPhuc operator /(SoPhuc v1, SoPhuc v2)
        {
            return new SoPhuc(v1.real + v2.real, v1.imaginary + v2.imaginary);
        }
        public static SoPhuc operator -(SoPhuc v1, SoPhuc v2)
        {
            return new SoPhuc(v1.real - v2.real, v1.imaginary - v2.imaginary);
        }
    }
}
