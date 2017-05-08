using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Классы – фигура(абстрактный),
 *  прямоугольник, 
 *  действия (интерфейс с методами click, move), 
 *  кнопка (бесп)*/
namespace ООP_Laba_3
{
     abstract class figura
    {
        protected string figuraName { set; get; }
        public figura (string name)
        {
            figuraName = name;
        }
        public abstract void PrintInfo();
        public abstract void WriteToFile(string FileName);
    }

    partial class Rectangle:figura
    {
        
        public int a { set; get; }
        public int b { set; get; }
        public Rectangle(int A,int B):base("Прямоугольник")
        {
            a = A;
            b = B;
        }
        public Rectangle() : this(20,30)
        {
          
        }
        public void peremesch(int x,int y)
        {
            a += x;
            b += y;
            PrintInfo();
        }
        public void szat(int k)
        {
            a = a / k;
            b = b / k;
            PrintInfo();
        }
      
    }
    public interface Actions
    {
        void click();
        void move();
    }

    sealed class Button:Rectangle, Actions
    {
        public Memento[] M=new Memento[10];
        public int m = 0;
        string text { set; get; }
        public Button(string Text) : base(12, 12)
        {
            text = Text;
        }
        public Button():this("GO!")
        {
        }
        public void CreateMemento()
        {
            try
            {
                Console.WriteLine("Сохранение №{0}", m + 1);
                M[m] = new Memento(a, b);
                m++;
            }
            catch(System.IndexOutOfRangeException e)
            {
                Console.WriteLine("Error {0}", e.Message);
                Console.Write("Не сохранено");
            }
        }
        public void click()
        {
            a -= 3;
            b -= 3;
        }
        public void move()
        {
            a += 2;
            b += 2;
        }
        public override void PrintInfo()
        {
            Console.WriteLine("Кнопка {3} форма-{0}(a={1}, b={2})", figuraName, a, b,text);
        }
        new
        public string ToString() => "Кнопка " + text + ": форма " + figuraName + " (" + a + "x" + b + ")";
        public override void WriteToFile(string FileName)
        {
            Console.WriteLine("Write to File");

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
       public Tuple<string,string,int,int> Get()
        {
            return Tuple.Create<string, string, int, int>(text, figuraName, a, b);
        }
    }

    public class BeginCoord
    {
        int x = 0;
        int y = 0;
        private static  BeginCoord bgn;
        private BeginCoord() { }
        public static BeginCoord Get()
        {
            if (bgn==null)
            {
                bgn = new BeginCoord();
            }
            return bgn;
        }
    }
}
