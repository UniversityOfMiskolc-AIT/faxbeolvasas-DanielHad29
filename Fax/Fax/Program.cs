using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fax
{
    public class Numbers
    {
        public string elsosor { get; private set; }
        public string masodiksor { get; private set; }
        public string harmadiksor { get; private set; }
        public static string szamlaszam { get; set; }
        public Numbers(string a)
        {
            string[] cast = a.Split(';');
            elsosor = cast[0];
            masodiksor = cast[1];
            harmadiksor = cast[2];
        }

        public void cast()
        {
            int j = 0;
            for (int i = 0; i < 9; i++)
            {
                szamlaSzam(kiemelSzamlaszam(elsosor.Substring(j, 3), masodiksor.Substring(j, 3), harmadiksor.Substring(j, 3)));
                j = j + 3;
            }

        }

        public char[,] matrix = new char[3, 3];
        public string kiemelSzamlaszam(string a, string b, string c)
        {
            for (int i = 0; i < 3; i++)
            {
                matrix[0, i] = a[i];
                matrix[1, i] = b[i];
                matrix[2, i] = c[i];
            }

            return atalakitSzamokra(matrix);
        }

        public string atalakitSzamokra(char[,] a)
        {
            string numberid = null;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[i, j] != ' ')
                        numberid += i.ToString() + j.ToString();
                }
            }
            return numberid;
        }

        public static void szamlaSzam(string a)
        {
            switch (a)
            {
                case "1222":
                    {
                        szamlaszam += "1";
                        break;
                    }
                case "0111122021":
                    {
                        szamlaszam += "2";
                        break;
                    }
                case "0111122122":
                    {
                        szamlaszam += "3";
                        break;
                    }
                case "10111222":
                    {
                        szamlaszam += "4";
                        break;
                    }
                case "0110112122":
                    {
                        szamlaszam += "5";
                        break;
                    }
                case "011011202122":
                    {
                        szamlaszam += "6";
                        break;
                    }
                case "011222":
                    {
                        szamlaszam += "7";
                        break;
                    }
                case "01101112202122":
                    {
                        szamlaszam += "8";
                        break;
                    }
                case "011011122122":
                    {
                        szamlaszam += "9";
                        break;
                    }
                default:
                    {
                        szamlaszam += "?";
                        break;
                    }
            }
        }
        public static int ellenorzes(string a)
        {
            int sum = 0;
            int j = 1;
            for (int i = 0; i < Numbers.szamlaszam.Length; i++)
            {
                if (Numbers.szamlaszam != "?")
                    sum += Convert.ToInt32((Numbers.szamlaszam[i] * j).ToString());

                j++;
            }

            return sum % 11;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("adat.txt");

            while (!sr.EndOfStream)
            {
                string accountnumber = "";
                for (int i = 0; i < 4; i++)
                    accountnumber += sr.ReadLine() + ";";

                Numbers n = new Numbers(accountnumber);
                n.cast();

                if (Numbers.ellenorzes(Numbers.szamlaszam) != 0 && !Numbers.szamlaszam.Contains("?"))
                    Console.WriteLine(Numbers.szamlaszam + " ERR");
                else if (Numbers.ellenorzes(Numbers.szamlaszam) == 0)
                    Console.WriteLine(Numbers.szamlaszam);
                else
                    Console.WriteLine(Numbers.szamlaszam + " ILL");

                Console.WriteLine("CheckSum: " + Numbers.ellenorzes(Numbers.szamlaszam));
                Numbers.szamlaszam = null;
            }
            sr.Close();
        }
    }
}