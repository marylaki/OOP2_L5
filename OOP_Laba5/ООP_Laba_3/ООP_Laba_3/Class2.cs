using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ООP_Laba_3
{
    partial class Rectangle
    {
        public override void PrintInfo()
        {
            Console.WriteLine("{0} a={1}, b={2}", figuraName, a, b);
        }
        //public override string ToString()
        //{
        //    return figuraName+" "+a+"x"+b;
        //}
        public override string ToString() => figuraName + " " + a + "x" + b;
        public override void WriteToFile(string FileName)
        {
            Console.WriteLine("Write to File");
            using (StreamWriter sw = new StreamWriter(FileName, true))
            {
                sw.WriteLine(ToString());
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine(ToString());
                }
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine("Error {0}", e.Message);
                Console.Write("Don't ");
            }
            finally
            {
                Console.WriteLine("sucsesfull");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Rectangle m = obj as Rectangle;
            if (m as Rectangle == null)
                return false;
            return m.figuraName == this.figuraName && m.a == this.a && m.b == this.b;
        }
        public override int GetHashCode()
        {
            return ((a * b) - (a + b)) * figuraName.Length;
        }
        public static Rectangle operator +(Rectangle R1, Rectangle R2)
        {
            try
            {
                Rectangle t = new Rectangle(checked(R1.a + R2.a), checked(R1.b + R2.b));
                return t;
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine("Error {0}", e.Message);
                return new Rectangle(0, 0);
            }
        }
        public static Rectangle operator -(Rectangle R1, Rectangle R2)
        {
            try
            {
                Rectangle t = new Rectangle(checked(Math.Abs(R1.a - R2.a)), checked(Math.Abs(R1.b - R2.b)));
                return t;
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine("Error {0}", e.Message);
                return new Rectangle(0, 0);
            }
        }
        public static Rectangle operator *(Rectangle R1, Rectangle R2)
        {
            try
            {
                Rectangle t = new Rectangle(checked(R1.a * R2.a), checked(R1.b * R2.b));
                return t;
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine("Error {0}", e.Message);
                return new Rectangle(0, 0);
            }
        }
        public static int operator /(Rectangle R1, Rectangle R2)
        {
            int n = 0;
            while (true)
            {
                if (R1.a >= R2.a && R1.b >= R2.b)
                {
                    n++;
                    R1 = R1 - R2;
                }
                else
                    return n;
            }
        }
        public static bool operator >(Rectangle R1, Rectangle R2)
        {
            return (R1.a * R1.b > R2.a * R2.b);
        }
        public static bool operator <(Rectangle R1, Rectangle R2)
        {
            return (R1.a * R1.b < R2.a * R2.b);
        }
        public static bool operator ==(Rectangle R1, Rectangle R2)
        {
            return R1.GetHashCode() == R2.GetHashCode();
        }
        public static bool operator !=(Rectangle R1, Rectangle R2)
        {
            return R1.GetHashCode() != R2.GetHashCode();
        }
    }
}
