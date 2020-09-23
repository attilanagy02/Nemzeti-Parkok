using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Halak_09_23
{
    class Balatonihal
    {
        public string nev;
        public int ido;
        public string gyak;
        public int elof;
        public int ved;
        public Balatonihal(string s)
        {
            string[] sor = s.Split('\t');
            nev = sor[0];
            ido = int.Parse(sor[1]);
            gyak = sor[2];
            elof = int.Parse(sor[3]);
            ved = int.Parse(sor[4]);
        }
    }
    class Halak
    {
        List<Balatonihal> l;
        public Halak(string f)
        {
            StreamReader sr = new StreamReader(f);
            l = new List<Balatonihal>();
            while (!sr.EndOfStream)
            {
                l.Add(new Balatonihal(sr.ReadLine()));
            }
        }
        public void F0()
        {
            foreach (var item in l)
            {
                Console.WriteLine(item.nev + "\t" + item.ido + "\t" + item.gyak + "\t" + item.elof + "\t" + item.ved);
            }
        }
        public void F1()
        {
            int db = 0;
            foreach (var item in l)
            {
                if (item.ido > 1849 && item.ido < 1901)
                {
                    db++;
                }
            }
            Console.WriteLine("1850 és 1900 között {0}db halat jegyeztek fel.", db);
        }
        public void F2()
        {
            foreach (var item in l)
            {
                if (item.nev.Contains("keszeg"))
                {
                    Console.WriteLine("Ez egy keszeg: " + item.nev);
                }
            }
        }
        public void F3()
        {
            Balatonihal min = l[0];
            foreach (var item in l)
            {
                if (item.ido < min.ido)
                {
                    min = item;
                }
            }
            Console.WriteLine("A legkorábban feljegyzett hal neve: {0} és feljegyzésének ideje: {1}"  ,min.nev,min.ido);
        }
        public void F4()
        {
            int a = 0;
            int b = 0;
            int c = 0;
            foreach (var item in l)
            {
                if (item.gyak == "A")
                {
                    a++;
                }
                else if (item.gyak == "B")
                {
                    b++;
                }
                else if (item.gyak == "C")
                {
                    c++;
                }
            }
            Console.WriteLine("-A- gyakoriság száma: " + a);
            Console.WriteLine("-B- gyakoriság száma: " + b);
            Console.WriteLine("-C- gyakoriság száma: " + c);
        }
        public void F5()
        {
            int sido = 0;
            foreach (var item in l)
            {
                if (item.nev.Contains("sügér"))
                {
                    sido = item.ido;
                }
            }
            foreach (var item in l)
            {
                if (item.ido == sido)
                {
                    Console.WriteLine("Sügér idejében feljegyzett hal(ak): {0}",item.nev);
                }
                else
                {
                    Console.WriteLine("Más dátumú!");
                }
            }
        }
        public void F6()
        {
            int v = 0;
            int nv = 0;
            foreach (var item in l)
            {
                if (item.ved == 1)
                {
                    v++;
                }
                else if(item.ved == 0)
                {
                    nv++;
                }
            }
            if (v > nv)
            {
                Console.WriteLine("Védett halakból van több.");
            }
            else
            {
                Console.WriteLine("A nem védett halakból van több.");
            }
        }
        public void F7()
        {
            StreamWriter sw = new StreamWriter("ritkahalak.txt");
            List<string> r = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].gyak == "C")
                {
                    r.Add(l[i].nev);
                }
            }
            r.Sort();
            foreach (var item in r)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }    
    }
    class Program
    {
        static void Main(string[] args)
        {
            Halak h = new Halak("halfaj.txt");
            h.F0();
            h.F1();
            h.F2();
            h.F3();
            h.F4();
            h.F5();
            h.F6();
            h.F7();
        }
    }
}
