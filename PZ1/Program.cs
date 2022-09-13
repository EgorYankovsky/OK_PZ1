using System;
using System.IO;
using System.Collections.Generic;

namespace PZ1
{
	public class TSK1
	{
		private static Dictionary<char, char> KVP = new Dictionary<char, char>();

		public static void clearDict() => KVP.Clear();

		public static void generateKey(char[] keys, char[] values)
		{
			if (keys.Length == values.Length)
			{
				for (int i = 0; i < keys.Length; i++)
				{
					KVP.Add(keys[i], values[i]);
				}
			}
			else
			{
				Console.WriteLine("Keys and Values have different sizes");
			}
		}

		public static char[] shuffleFY(string str)
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
			return elems;
		}

		public static void simpleChange(string inTitle, string outTitle)
		{
			try
			{
				StreamReader sr = new StreamReader($"{inTitle}.txt");
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

				StreamWriter sw = new StreamWriter($"{outTitle}.txt");
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
			string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя", value,
				inputTitle0 = "inputDefText", outputTitle0 = "outputDefText",
				inputTitle1 = "inputEssay", outputTitle1 = "outputEssay",
				inputTitle2 = "inputHugeText", outputTitle2 = "outputHugeText";


			// Task № 1.1
			StreamWriter sw = new StreamWriter("key.txt");
			sw.WriteLine(new string(TSK1.shuffleFY(alph)));
			Console.WriteLine($"Ключ записан в файл key.txt");
			sw.Close();
			Console.WriteLine("Task1 passed");



			// Task № 1.2
			StreamReader sr = new StreamReader("key.txt");
			value = sr.ReadLine();
			sr.Close();
			TSK1.generateKey(alph.ToCharArray(), value.ToCharArray());
			TSK1.simpleChange(inputTitle0, outputTitle0);
			TSK1.clearDict();
			Console.WriteLine("Task2 passed");


			//// Task № 1.3
			TSK1.generateKey(alph.ToCharArray(), TSK1.shuffleFY(alph));
			TSK1.simpleChange(inputTitle1, outputTitle1);
			TSK1.clearDict();

			TSK1.generateKey(alph.ToCharArray(), TSK1.shuffleFY(alph));
			TSK1.simpleChange(inputTitle2, outputTitle2);
			TSK1.clearDict();
			Console.WriteLine("Task3 passed");
		}
	}
}
