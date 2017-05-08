using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Collections;


namespace ООP_Laba_3
{
    class Reflection
    {
        public bool ClassInfoToFile(string Name)//запись информации о классе в файл
        {
            Console.Write("\nWrite file {0}", Name);
            Type ourType = Type.GetType(Name, false,true);
            if (ourType == null)
            {
                Console.Write(" FAILED\n");
                Console.WriteLine("Error {0} NOT FOUND!",Name);
                return false;
            }
            using (StreamWriter sw = new StreamWriter("E:\\"+Name+".txt"))
            {
                
                sw.WriteLine(ourType.ToString());
                sw.WriteLine("\nПоля:");
                foreach (var i in ourType.GetFields())
                    sw.WriteLine(i);
                sw.WriteLine("\nСвойства:");
                foreach (var i in ourType.GetProperties())
                    sw.WriteLine(i);
                sw.WriteLine("\nИнетерфейсы:");
                foreach (var i in ourType.GetInterfaces())
                    sw.WriteLine(i);
                sw.WriteLine("\nСобытия:");
                foreach (var i in ourType.GetEvents())
                    sw.WriteLine(i);
                sw.WriteLine("\nКонструкторы:");
                foreach (var i in ourType.GetConstructors())
                    sw.WriteLine(i);
                sw.WriteLine("\nМетоды:");
                foreach (var i in ourType.GetMethods())
                    sw.WriteLine(i);
                sw.WriteLine("\nЧлены типа:");
                foreach (var i in ourType.GetMembers())
                    sw.WriteLine(i);
                Console.Write(" SUCSESSFUL\n");
                return true;
            }
        }
        public IEnumerable<MethodInfo> GetMethods(string Name)
        {
            Type ourType = Type.GetType(Name, false, true);
            return ourType.GetRuntimeMethods();
        }
        public ArrayList GetFieldAndProperites(object obj)
        {
            ArrayList fp = new ArrayList();
            Type ourType = obj.GetType();
            if (ourType != null)
            {
                foreach (FieldInfo i in ourType.GetFields())
                    fp.Add(i);
                foreach (PropertyInfo i in ourType.GetProperties())
                    fp.Add(i);
            }
            return fp;
        }
        public Type[] GetInterfaces(object obj)
        {
            Type ourType = obj.GetType();
            return ourType.GetInterfaces();
        }
        public void PrintMethodsParam(string Name, string typ)
        {
            Console.WriteLine("\nMethods {0} with param {1}", Name,typ);
            Type ourType = Type.GetType(Name, false, true);
            Type ype = Type.GetType(typ, false, true);
            LinkedList<MethodInfo> D= new LinkedList<MethodInfo>(ourType.GetMethods());
            var s = D.Where(p => { bool f = false; foreach (var i in p.GetParameters()) if (i.ParameterType == ype) f = true; return f; }).Select(p => p);
            foreach (var i in s)
                Console.WriteLine(i);
        }
      
        public void RunMethod(string Name, string Method)
        {
            bool t = false;
            using (StreamReader sr = new StreamReader(@"E:\\Read.txt"))
            {
                string line;
                Console.WriteLine("\nRun Methos {1} to Type {0}", Name, Method);
                Type ourType = Type.GetType(Name, false, true);

                MethodInfo ourMethod = ourType.GetMethod(Method);
                
                if (ourMethod != null)
                {
                    var param = ourMethod.GetParameters();
                    int k = ourMethod.GetParameters().Count();
                    object[] p = new object[k];
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(Method))
                        {
                            t = true;
                            for (int i = 0; i < k; i++)
                            {
                                string f = sr.ReadLine();
                                if (param[i].ParameterType == f.GetType())
                                { p[i] = f; }
                                else
                                { p[i] = Convert.ToInt32(f); }
                                Console.WriteLine("{0}", p[i].ToString());
                                
                            }
                        }
                    }

                    if (t)
                    {
                        ConstructorInfo ourTypeConstructor = ourType.GetConstructor(Type.EmptyTypes);
                    object ourObj = ourTypeConstructor.Invoke(new object[] { });
                    ourMethod.Invoke(ourObj, p);
                        Console.WriteLine(ourObj);
                    }
                }
            }
        }
    }
}
