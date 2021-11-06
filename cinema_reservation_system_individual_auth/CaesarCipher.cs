using System;
namespace cinema_reservation_system_individual_auth
{
    public class CaesarCipher
    {
		private static char Cipher(char ch, int key)
		{
			if (!char.IsLetter(ch))
				return ch;

			char offset = char.IsUpper(ch) ? 'A' : 'a';
			return (char)((((ch + key) - offset) % 26) + offset);
		}

		public static string Encipher(string input, int key)
		{
			string output = string.Empty;

			foreach (char ch in input)
				output += Cipher(ch, key);

			return output;
		}

		public static string Decipher(string input, int key)
		{
			return Encipher(input, 26 - key);
		}
	}

}
