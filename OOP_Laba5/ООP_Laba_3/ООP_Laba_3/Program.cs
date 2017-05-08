using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ООP_Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(12, 36);
            r1.PrintInfo();
            Rectangle r2 = new Rectangle(6, 24);
            r2.PrintInfo();
            Rectangle r3 = new Rectangle(30, 18);
            r3.PrintInfo();
            Button b1 = new Button("B1");
            b1.PrintInfo();
            Button b2 = new Button("B2");
            b2.PrintInfo();
            User User1 = new User();
            User1.onPeremes += r1.peremesch;
            User1.onPeremes += r2.peremesch;
            User1.onPeremes += b1.peremesch;
            User1.onSzatb += b2.szat;
            User1.onSzatb += r1.szat;
            User1.Szatie(6);
            User1.Peremes(4, 6);
            Console.WriteLine("\nItog:");
            r1.PrintInfo();
            r2.PrintInfo();
            r3.PrintInfo();
            b1.PrintInfo();
            b2.PrintInfo();
            
            Reflection r = new Reflection();
            r.ClassInfoToFile("ООP_Laba_3.Rectangle");
            r.ClassInfoToFile("ООP_Laba_3.figura");
            r.ClassInfoToFile("ООP_Laba_3.Button");
            r.ClassInfoToFile("ООP_Laba_3.User");
            r.ClassInfoToFile("Nezarabotaet");

            Console.WriteLine("\nGet Methods Rectangle");
            foreach (var i in r.GetMethods("ООP_Laba_3.Rectangle")) 
                Console.WriteLine(i);

            Console.WriteLine("\nGet Fields And Properites {0}", b1.GetType());
            foreach (var i in r.GetFieldAndProperites(b1))
                Console.WriteLine(i);
            Console.WriteLine("\nGet Fields And Properites {0}", r1.GetType());
            foreach (var i in r.GetFieldAndProperites(r1))
                Console.WriteLine(i);


            Console.WriteLine("\nGet interfaces {0}", b1.GetType());
            foreach (var i in r.GetInterfaces(b1))
                Console.WriteLine(i);

            r.PrintMethodsParam("ООP_Laba_3.Rectangle", "System.Int32");
            r.PrintMethodsParam("ООP_Laba_3.figura", "System.String");

            r.RunMethod("ООP_Laba_3.Rectangle", "PrintInfo");
            r.RunMethod("ООP_Laba_3.Button", "PrintInfo");
            r.RunMethod("ООP_Laba_3.Rectangle", "set_figuraName");
            r.RunMethod("ООP_Laba_3.Rectangle", "peremesch");
            r.RunMethod("ООP_Laba_3.Button", "WriteToFile");
            r.RunMethod("ООP_Laba_3.Button", "move");

        }
    }
}
