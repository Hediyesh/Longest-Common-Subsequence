using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DonbaleMoshtarak
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            try
            {
                while (i == 1)
                {
                    Console.WriteLine("please enter first string:");
                    string str1 = Console.ReadLine();
                    Console.WriteLine("please enter second string:");
                    string str2 = Console.ReadLine();
                    MaxDonbalePrint(str1, str2);
                    //"abcbdab", "bdcaba"
                    Console.Write("Baraye edame 1 va baraye khoroj 0 ra vared konid:");
                    i = Convert.ToInt32(Console.ReadLine());
                    //Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void MaxDonbalePrint(string str1, string str2)
        {
            int max = MaxDonbale(str1, str2);
            Console.WriteLine("Bozorgtrin tule donbale moshtarak : " + max);
            List<string> sub1 = ZirMajmueha(str1);
            List<string> sub2 = ZirMajmueha(str2);
            Console.WriteLine("_______________________________");
            Console.WriteLine("Donbale ha :");
            foreach (var item1 in sub1)
            {
                foreach (var item2 in sub2)
                {
                    if (item1 == item2 && item2.Length == max)
                    {
                        Console.WriteLine(item2);
                    }
                }
            }
        }
        public static int MaxDonbale(string str1, string str2)
        {
            int len1 = str1.Length + 1;
            int len2 = str2.Length + 1;
            int[,] d = new int[len1, len2];
            for (int i = 0; i < len1; i++)
            {
                d[i, 0] = 0;
            }
            for (int i = 0; i < len2; i++)
            {
                d[0, i] = 0;
            }
            for (int i = 1; i < len1; i++)
            {
                for (int j = 1; j < len2; j++)
                {
                    d[i, j] = Math.Max(d[i - 1, j], d[i, j - 1]);
                    if (str1[i - 1] == str2[j - 1])
                    {
                        d[i, j] = Math.Max(d[i, j], d[i - 1, j - 1] + 1);
                    }
                }
            }
            return d[len1 - 1, len2 - 1];
        }
        public static List<string> ZirMajmueha(string str1)
        {
            List<string> substr1 = new List<string>();
            int[] adder = new int[str1.Length + 1];
            for (int i = 0; i < str1.Length + 1; i++)
            {
                adder[i] = 0;
            }
            do
            {
                for (int i = 1; i < str1.Length + 1; i++)
                {
                    string s2 = "";
                    for (int j = 1; j < adder.Length; j++)
                    {
                        if (adder[j] == 1)
                        {
                            s2 += str1[j - 1];
                        }
                    }
                    if (s2.Length != 0)
                    {
                        substr1.Add(s2);
                    }
                    if (adder[str1.Length] == 0)
                    {
                        adder[str1.Length] = 1;
                    }
                    else
                    {
                        int l = str1.Length;
                        while (adder[l] == 1)
                        {
                            adder[l] = 0;
                            l--;
                        }
                        adder[l] = 1;
                    }
                }
            } while (adder[0] == 0);
            return substr1;
        }
    }
}
