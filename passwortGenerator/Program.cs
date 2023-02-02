using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace passwortGenerator
{
    internal class Program
    {
        public static int passwordLength = 15;

        public static List<int> allLetters = new List<int>();
        public static string passwordLengthInput;

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            while (DoJob()) {}
        }

        static bool DoJob()
        {
            Console.Title = "Password Generator by Dornkimik";

            InitializeLetters();
            Console.WriteLine("Write generate to create a password");

            string input = Console.ReadLine();

            if (input == "generate")
            {
                Console.WriteLine("Please enter the password length: ");
                passwordLengthInput = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error, try again");
                return true;
            }

            if (passwordLengthInput != null)
            {
                try
                {
                    passwordLength = Convert.ToInt32(passwordLengthInput);
                    GeneratePassword();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return true;
                }
            }

            Console.ReadKey();
            return false;
        }

        private static void InitializeLetters()
        {
            // small letters from a - z
            for (int i = 65; i <= 90; i++)
            {
                allLetters.Add(i);
            }

            // big letters from A - Z
            for (int i = 97; i <= 122; i++)
            {
                allLetters.Add(i);
            }

            // numbers from 0 - 9
            for (int i = 48; i <= 57; i++)
            {
                allLetters.Add(i);
            }
        }

        public static string GeneratePassword()
        {
            Random random = new Random();

            // empty string
            string password = "";

            for (int i = 0; i < passwordLength; i++)
            {
                password += (char)allLetters[random.Next(0, allLetters.Count)];
            }

            Console.WriteLine(password);

            if (password.Length > 0)
            {
                Clipboard.SetText(password);
                Console.WriteLine("Passwort was copied to the clipboard");
            } else
            {
                Console.WriteLine("Error, password length must be greater than 0");
            }
            return password;
        }
    }
}
