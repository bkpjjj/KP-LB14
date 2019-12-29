using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba
{
    class Matrix : IComparable<Matrix>,IComparable<int>
    {
        //Fields
        private int[,] arr;
        //Propertys
        public int Rows { get; set; }
        public int Cols { get; set; }
        //Indexer
        public int this[int i , int j] { get { return arr[i, j]; } set { arr[i, j] = value; } }
        //Constructors
        public Matrix(int Rows,int Cols)
        {
            this.Rows = Rows;
            this.Cols = Cols;
            ValidationCheck();
            arr = new int[this.Rows, this.Cols];
        }

        public Matrix() : this(1, 1) { }
        //Methods
        //
        #region FOREACH
        private static void ForEach(Matrix src,Func<int,int,int> f)
        {
            for (int i = 0; i < src.Rows; i++)
            {
                for (int j = 0; j < src.Cols; j++)
                {
                    src[i, j] = f(i, j);
                }
            }
        }
        private static void ForEach(Matrix src, Action<int> f)
        {
            for (int i = 0; i < src.Rows; i++)
            {
                for (int j = 0; j < src.Cols; j++)
                {
                    f(src[i, j]);
                }
            }
        }
        private static void ForEach(Matrix src, Action<int,int,int> f)
        {
            for (int i = 0; i < src.Rows; i++)
            {
                for (int j = 0; j < src.Cols; j++)
                {
                    f(src[i, j],i,j);
                }
            }
        }
        #endregion
        //
        #region INOUT
        public void Read()
        {
            for (int i = 0; i < Rows; i++)
            {
                int[] tmp = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                for (int j = 0; j < Cols; j++)
                {
                    arr[i, j] = tmp[j];
                }
            }
        }
        public void Write()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{arr[i,j]}".PadLeft(3));
                }
                Console.WriteLine();
            }
        }
        public void FillRandom()
        {
            Random r = new Random();
            ForEach(this,(x,y) => r.Next(0,10));
        }
        #endregion
        //
        #region MATH
        public static Matrix Sum(Matrix a,Matrix b)
        {
            a.SizeCheck(b);
            Matrix tmp = new Matrix(a.Rows, a.Cols);
            ForEach(tmp, (x, y) => a[x, y] + b[x, y]);
            return tmp;
        }
        public static Matrix Sum(Matrix a,int b)
        {
            Matrix tmp = new Matrix(a.Rows, a.Cols);
            ForEach(tmp, (x, y) => a[x, y] + b);
            return tmp;
        }
        public static Matrix Sub(Matrix a,Matrix b)
        {
            a.SizeCheck(b);
            Matrix tmp = new Matrix(a.Rows, a.Cols);
            ForEach(tmp, (x, y) => a[x, y] - b[x, y]);
            return tmp;
        }
        public static Matrix Sub(Matrix a, int b)
        {
            Matrix tmp = new Matrix(a.Rows, a.Cols);
            ForEach(tmp, (x, y) => a[x, y] - b);
            return tmp;
        }
        //Length
        public int GetLength()
        {
            int sum = 0;
            ForEach(this, (x) => { sum += x * x; });
            return Convert.ToInt32(Math.Sqrt(sum));
        }
        #endregion
        //
        #region OPERATOR_OV
        public static Matrix operator+(Matrix a,Matrix b)
        {
            return Sum(a, b);
        }
        public static Matrix operator +(Matrix a, int b)
        {
            return Sum(a, b);
        }
        public static Matrix operator +(int b, Matrix a)
        {
            return Sum(a, b);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Sub(a, b);
        }
        public static Matrix operator -(Matrix a, int b)
        {
            return Sub(a, b);
        }
        //Comparesing
        public static bool operator >(Matrix a, Matrix b) => a.CompareTo(b) > 0;
        public static bool operator <(Matrix a, Matrix b) => a.CompareTo(b) < 0;
        public static bool operator !=(Matrix a, Matrix b) => a.CompareTo(b) != 0;
        public static bool operator ==(Matrix a, Matrix b) => a.CompareTo(b) == 0;
        public static bool operator >(Matrix a, int b) => a.CompareTo(b) > 0;
        public static bool operator <(Matrix a, int b) => a.CompareTo(b) < 0;
        public static bool operator !=(Matrix a, int b) => a.CompareTo(b) != 0;
        public static bool operator ==(Matrix a, int b) => a.CompareTo(b) == 0;
        public static bool operator >(int a, Matrix b) => b.CompareTo(a) < 0;
        public static bool operator <(int a, Matrix b) => b.CompareTo(a) > 0;
        public static bool operator !=(int a, Matrix b) => b.CompareTo(a) != 0;
        public static bool operator ==(int a, Matrix b) => b.CompareTo(a) == 0;
        //
        #endregion
        //IComparable realisation
        public int CompareTo(Matrix other)
        {
            SizeCheck(other);
            int l1 = GetLength();
            int l2 = other.GetLength();
            if (l1 > l2) return 1;
            else if (l1 == l2) return 0;
            else return -1;
        }
        public int CompareTo(int other)
        {
            int l1 = GetLength();
            if (l1 > other) return 1;
            else if (l1 == other) return 0;
            else return -1;
        }
        //
        private void ValidationCheck()
        {
            if(Cols < 0 || Rows < 0)
                throw new IndexOutOfRangeException();
        }
        private void SizeCheck(Matrix b)
        {
            if (Cols != b.Cols || Rows != b.Rows)
                throw new Exception("Matrix must be same size!");
        }
    }
}
