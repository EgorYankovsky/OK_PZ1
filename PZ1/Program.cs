using System;
using System.IO;
using System.Collections.Generic;

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

		public static char find(char littera, string alph, string key)
		{
			char elem;
			int i = 0;

			while (littera != alph[i])
				i++;
			elem = key[i];

			return elem;
		}

		public static void simpleChange(string alph, string key, string inTitle, string outTitle)
		{
			// А: C:\\Users\\salyaev.2020\\Desktop\\
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\
			try
			{
				StreamReader sr = new StreamReader($"C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\{inTitle}.txt");
				string line = sr.ReadToEnd();
				sr.Close();
				char[] elems = line.ToCharArray();     // Achtung! Не самое мудрое решение
				List<char> outElems = new List<char>();

				foreach (char litera in elems)
				{
					if (System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(litera), @"\p{IsCyrillic}"))
						outElems.Add(find(Char.ToLower(litera), alph, key));
				}

				StreamWriter sw = new StreamWriter($"C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\{outTitle}.txt");
				foreach (char elem in outElems)
					sw.Write(elem);
				sw.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception: {e}");
			}
		}
	}
	public class Program
	{
		static void Main(string[] args)
		{
			string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя",
				key, key1, key2, 
				inputTitle0 = "inputDefText", outputTitle0 = "outputDefText",
				inputTitle1 = "inputEssay", outputTitle1 = "outputEssay",
				inputTitle2 = "inputHugeText", outputTitle2 = "outputHugeText";


			// Task № 1.1
			// А: C:\\Users\\salyaev.2020\\Desktop\\
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\
			StreamWriter sw = new StreamWriter("C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\key.txt");
			sw.WriteLine(TSK1.shuffleFY(alph));
			Console.WriteLine($"Ключ сгенерирован в файл key.txt");
			sw.Close();
			Console.WriteLine("Task1 passed");



			// Task № 1.2
			// А: C:\\Users\\salyaev.2020\\Desktop\\
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\
			StreamReader sr = new StreamReader("C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\key.txt");
			key = sr.ReadLine();
			sr.Close();
			TSK1.simpleChange(alph, key, inputTitle0, outputTitle0);
			Console.WriteLine("Task2 passed");


			// Task № 1.3
			key1 = TSK1.shuffleFY(alph);
			key2 = TSK1.shuffleFY(alph);
			TSK1.simpleChange(alph, key1, inputTitle1, outputTitle1);
			TSK1.simpleChange(alph, key2, inputTitle2, outputTitle2);
			Console.WriteLine("Task3 passed");
		}
	}
}
