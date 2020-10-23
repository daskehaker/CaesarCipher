using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_chipher
{
    public class Program
    {
		const int MODULE_NUMBER = 26;

		static void Main(string[] args)
		{
			string text = "ABC";
			int key = 1;

			if (Operate(key, text))
			{
				Console.WriteLine("Code works good");
			}
			else Console.WriteLine("There is something bad");

		}

		public static bool Operate(int key, string text)
		{
			//Initial text
			text = text.ToUpper();
			Console.WriteLine("Initial text: {0}", text);

			//Return key module
			key = KeyModule(key);
			Console.WriteLine("Emcryption key: {0}", key);

			//Text Encryption
			string cipherText = DoCaesar(key, text);
			Console.WriteLine("Cipher text: {0}", cipherText);

			//Text decryption, invert the same key and method should return initial text
			string decryptedText = DoCaesar(key * -1, cipherText);
			Console.WriteLine("Text after decryption: {0}", decryptedText);

			if (text.Equals(decryptedText)) return true;

			return false;
		}

		public static int KeyModule(int key)
		{
			if (Math.Abs(key) < MODULE_NUMBER) return key;

			//Perform module operation because alphabet consist of MODULE_NUMBER letters
			return key % MODULE_NUMBER;
		}

		public static string DoCaesar(int key, string text)
		{
			//return plain text if key equals to zero
			if (key == 0) return text;

			char[] buffer = text.ToUpper().ToCharArray();
			for (int i = 0; i < buffer.Length; i++)
			{
				char letter = buffer[i];

				//shift letter by key positions
				letter = (char)(letter + key);
				//check if letter is still in alphebet range
				if (letter > 'Z')
				{
					letter = (char)(letter - MODULE_NUMBER);
				}
				else if (letter < 'A')
				{
					letter = (char)(letter + MODULE_NUMBER);
				}
				buffer[i] = letter;
			}
			return new string(buffer);
		}
	}
}
