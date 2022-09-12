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

		public static void simpleChange(Dictionary<char, char> KVP, string inTitle, string outTitle)
		{
			// А: C:\\Users\\salyaev.2020\\Desktop\\
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\
			try
			{
				StreamReader sr = new StreamReader($"C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\{inTitle}.txt");
				string line = sr.ReadToEnd().ToLower();
				sr.Close();

				List<char> outElems = new List<char>();

				foreach (char litera in line)
				{
					if (System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(litera).ToLower(), @"\p{IsCyrillic}"))
					{
						outElems.Add(KVP[litera]);
					}
					else if (litera == '\n')
					{
						outElems.Add(litera);
					}
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
			Dictionary<char, char> keyValuePairs = new Dictionary<char, char>();
			string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя",
				key, key1, key2, 
				inputTitle0 = "inputDefText", outputTitle0 = "outputDefText",
				inputTitle1 = "inputEssay", outputTitle1 = "outputEssay",
				inputTitle2 = "inputHugeText", outputTitle2 = "outputHugeText";


			// Task № 1.1
			// А: C:\\Users\\salyaev.2020\\Desktop\\texts\\
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\
			StreamWriter sw = new StreamWriter("C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\key.txt");
			string formedKey = TSK1.shuffleFY(alph);
			sw.WriteLine(formedKey);
			Console.WriteLine($"Ключ записан в файл key.txt");
			sw.Close();


			Console.WriteLine("Task1 passed");



			// Task № 1.2
			// А: C:\\Users\\salyaev.2020\\Desktop\\texts\\
			// Е: C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\
			StreamReader sr = new StreamReader("C:\\Users\\Админ\\Desktop\\Учебное\\Основы криптографии\\Code\\PZ1\\texts\\key.txt");
			key = sr.ReadLine();

			int i = 0;
			foreach (char litera in alph)
			{
				keyValuePairs.Add(litera, key[i]);
				i++;
			}
			sr.Close();

			TSK1.simpleChange(keyValuePairs, inputTitle0, outputTitle0);
			keyValuePairs.Clear();
			Console.WriteLine("Task2 passed");


			//// Task № 1.3
			key1 = TSK1.shuffleFY(alph);
			i = 0;
			foreach (char litera in alph)
			{
				keyValuePairs.Add(litera, key1[i]);
				i++;
			}
			TSK1.simpleChange(keyValuePairs, inputTitle1, outputTitle1);
			keyValuePairs.Clear();
			key2 = TSK1.shuffleFY(alph);
			i = 0;
			foreach (char litera in alph)
			{
				keyValuePairs.Add(litera, key2[i]);
				i++;
			}
			TSK1.simpleChange(keyValuePairs, inputTitle2, outputTitle2);
			keyValuePairs.Clear();
			Console.WriteLine("Task3 passed");
		}
	}
}
