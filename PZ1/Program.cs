using System;

namespace PZ1
{
	public class TSK1
	{
		public static void shuffleFY(string str)
		{
			char[] elems = str.ToCharArray();
			Random rnd = new Random();
			for(int i = 0; i < elems.Length; i++)
			{
				int j = rnd.Next(0, elems.Length - 1);
				char elem = elems[j];
				elems[j] = elems[i];
				elems[i] = elem;
			}
			foreach (char elem in elems)
				Console.Write(elem);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
			// 10 штук исключительно для демострации разноброса
			for (int i = 0; i < 10; i++)
			{
				TSK1.shuffleFY(alph);
				Console.WriteLine();
			}
		}
	}
}
