using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООP_Laba_3
{
    class Memento
    {
        public int a { get; private set; }
        public int b { get; private set; }
        public Memento(int A,int B)
        {
            a = A;
            b = B;
        }
    }
    static class Restover
    {
        public static void rest(ref Button B,int i)
        {
            if (i < B.m && i >= 0)
            {
                Console.WriteLine("Восстановление состояния {0}", i + 1);
                B.a = B.M[i].a;
                B.b = B.M[i].b;
            }
            else Console.WriteLine("Восстановление не возможно");
        }
    }
}
