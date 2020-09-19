using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nemzeti_parkok
{
	class NemzetiP
	{
		public string nev;
		public int ai;
		public double ter;
		public NemzetiP(string s)
		{
			string[] sor = s.Split(';');
			nev = sor[0];
			ai = int.Parse(sor[1]);
			ter = double.Parse(sor[2]);
		}
	}
	class Parkok
	{
		List<NemzetiP> lista;
		public Parkok(string z)
		{
			StreamReader sr = new StreamReader(z);
			lista = new List<NemzetiP>();
			while (!sr.EndOfStream)
			{
				lista.Add(new NemzetiP(sr.ReadLine()));
			}
		}
		public void f1()
		{
			foreach (var item in lista)
			{
				Console.WriteLine(item.nev + "	" + item.ai + "	" + item.ter);
			}
		}
		public void f2()
		{
			NemzetiP max = lista[0];
			foreach (var item in lista)
			{
				if (item.ai < max.ai)
				{
					Console.WriteLine("A legelső nemzeti park a {0}",item.nev);
				}
			}
		}
		public void f34()
		{
			double ossz = 0;
			foreach (var item in lista)
			{
				ossz += item.ter;
			}
			Console.WriteLine("A nemzeti parkok összterülete {0} km^2",ossz);
			double szaz1 = 93030 / 100;
			double szaz = ossz / szaz1;
			Console.WriteLine("A nemzeti parkok Magyarország {0}% területét foglalják el.",szaz);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Parkok pr = new Parkok("npark.txt");
			pr.f1();
			Console.WriteLine();
			pr.f2();
			Console.WriteLine();
			pr.f34();
		}
	}
}
