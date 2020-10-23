using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_chipher
{
    public class Program
    {
		static void Main(string[] args)
		{
			string text = "ABC".ToUpper();
			int key = 26;

			if (Operate(key, text))
			{
				Console.WriteLine("Code works good");
			}
			else Console.WriteLine("There is something bad");

		}

		public static bool Operate(int key, string text)
		{
			//Initial text
			Console.WriteLine("Initial text: {0}", text);

			//Return key module
			key = KeyModule(key);
			Console.WriteLine("Emcryption key: {0}", key);

			//Text Encryption
			string cipherText = DoCaesar(key, text);
			Console.WriteLine("Cipher text: {0}", cipherText);

			//Text decryption
			string decryptedText = DoCaesar(key * -1, cipherText);
			Console.WriteLine("Text after decryption: {0}", decryptedText);

			if (text.Equals(decryptedText)) return true;

			return false;
		}

		public static int KeyModule(int key)
		{
			if (Math.Abs(key) < 26) return key;

			//Perform module operation because alphabet consist of 26 letters
			return key % 26;
		}

		public static string DoCaesar(int key, string text)
		{
			//return plain text if key equals to zero
			if (key == 0) return text;

			char[] buffer = text.ToUpper().ToCharArray();
			for (int i = 0; i < buffer.Length; i++)
			{
				char letter = buffer[i];
				letter = (char)(letter + key);
				if (letter > 'Z')
				{
					letter = (char)(letter - 26);
				}
				else if (letter < 'A')
				{
					letter = (char)(letter + 26);
				}
				buffer[i] = letter;
			}
			return new string(buffer);
		}
	}
}
