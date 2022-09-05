using System;
using System.IO;

namespace PZ1
{
	public class TSK1
	{
		public static string shuffleFY(string str)
		{
			char[] elems = str.ToCharArray();
			Random rnd = new Random();
			for (int i = 0; i < elems.Length; i++)
			{
				int j = rnd.Next(0, elems.Length - 1);
				char elem = elems[j];
				elems[j] = elems[i];
				elems[i] = elem;
			}
			return new string(elems);
		}

		public static void find(char n, string m, string v)
		{
			char elem;
			int i = 0;
			if (n != '\n' && n != '\r')
			{
				while (n != m[i])
				{
					i++;
				}
				elem = v[i];
				Console.Write(elem);
			}
		}

		public static void simpleChange(string a, string b)
		{
			// А: C:\\Users\\salyaev.2020\\Desktop\\input.txt
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\input.txt
			StreamReader sr = new StreamReader("C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\input.txt");
			string line = sr.ReadLine();
			while (line != null)
			{
				foreach (char litera in line)
				{
					if (litera >= 'А' && litera <= 'Я')
						find(Char.ToLower(litera), a, b);

					if (litera >= 'а' && litera <= 'я')
						find(litera, a, b);
					//j = Char.ToLower(litera);
					//find(j, a, b);
				}
				Console.Write('\n');
				line = sr.ReadLine();
			}
			sr.Close();
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
			Console.WriteLine(TSK1.shuffleFY(alph));
			TSK1.simpleChange(alph, TSK1.shuffleFY(alph));
		}
	}
}
