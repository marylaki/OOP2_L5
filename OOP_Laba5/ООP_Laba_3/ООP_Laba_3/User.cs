using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООP_Laba_3
{
   
    class User
    {
        public delegate void per(int x, int y);
        public delegate void sz(int kof);
        public event per onPeremes;
        public event sz onSzatb;
        public void Peremes(int x,int y)
        {
            Console.WriteLine("\nUser peremeschaet na {0} i {1}\n",x,y);
            onPeremes(x, y);
        }
        public void Szatie(int kof)
        {
            Console.WriteLine("\nUser szimaet v {0} raz\n", kof);
            onSzatb(kof);
        }
    }
}
