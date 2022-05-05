using System;

namespace Ceaser_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a phrase: ");
            string input = Console.ReadLine();
            input = input.ToLower();
            Console.WriteLine("What would you like to do with this string?");
            Console.WriteLine("e = encrypt; d = decrypt; any other character to exit");
            string option = Console.ReadLine();
            switch (option)
            {
                case "e":
                    Console.WriteLine("Enter encryption coefficient: ");

                    int n;
                    if (int.TryParse(Console.ReadLine(), out n))
                    {
                        if (0 < n)
                        {
                            Console.WriteLine("Enter your phrase: ");
                            Console.WriteLine(Encrypt(input, n));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter an integer");
                    }
                    break;
                case "d":
                    Decrypt(input);
                    break;
                default:
                    break;

            }

        }
        static string Encrypt(string input, int n)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] inputArr = input.ToCharArray();
            int len = inputArr.Length;
            char[] encryptedString = new char[len];
            for (int i = 0; i < len; i++)
            {
                var letter = inputArr[i];
                int index = Array.IndexOf(alphabet, letter);
                int encIndex = (n + index) % 26;
                char encLetter = alphabet[encIndex];
                encryptedString[i] = encLetter;
            }
            string postEncString = String.Join("", encryptedString);
            return postEncString;
        }
        static string Decrypt(string input)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] inputArr = input.ToCharArray();
            int len = inputArr.Length;
            char[] encryptedString = new char[len];
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    var letter = inputArr[j];
                    int index = Array.IndexOf(alphabet, letter);
                    int encIndex = (i + index);
                    char encLetter = alphabet[encIndex];
                    encryptedString[j] = encLetter;

                }
                string postEncString = String.Join("", encryptedString);
                return postEncString;
            }
            return null;
        }
    }
}