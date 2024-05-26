using System;

namespace Clase_25_01_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short data_short;
            int data_int;
            char data_char;

            int character;
            string int_string = "";
            string short_string = "";

            char[] data_bytes = new char[20];

            Console.WriteLine("\r\nEntre un número -> ");
            int_string= Console.ReadLine() ?? "";

            Console.WriteLine("Entre otro número -> ");
            short_string = Console.ReadLine() ?? "";

            Console.WriteLine("Entre un caracter -> ");
            character = Console.Read();

            Console.WriteLine("Valores: " + short_string + " Otro: " + int_string + " Otro: " + character.ToString());

            Console.ReadKey();

            void Convertir()
            {
                char[] numhex = { (char)0x01, (char)2, (char)3, (char)4 };
                int valor;

                valor = numhex[0] - 0x30 << 24;
                valor = numhex[1] - 0x30 << 16;
                valor = numhex[2] - 0x30 << 8;
                valor = numhex[3] - 0x30 << 0;

                int num = 5500;
                char[] cifras = new char[4];

                cifras[0] = (char)(num >> 24);
                cifras[1] = (char)(num >> 16);
                cifras[2] = (char)(num >> 8);
                cifras[3] = (char)(num >> 0);
            }
        }
    }
}
