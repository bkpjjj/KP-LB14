using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(4, 4);
            Matrix m2 = new Matrix(4, 4);
            m.FillRandom();
            m2.FillRandom();
            Console.WriteLine("Matrix:");
            m.Write();
            Console.WriteLine("Length:{0}", m.GetLength());
            Console.WriteLine("Matrix2:");
            m2.Write();
            Console.WriteLine("Length:{0}", m2.GetLength());
            var s = m + m2;
            Console.WriteLine("Sum:");
            s.Write();
            Console.WriteLine("Compare:{0}",m == m2);
            Console.ReadKey();
        }
    }
}
