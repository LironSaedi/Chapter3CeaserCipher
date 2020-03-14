using System;
using System.Collections.Generic;
using System.IO;

namespace Chapter3CeaserCipher
{
    class Program
    {
        static List<string> bruteForce(string cipherText)
        {
            List<string> combinations = new List<string>();

            for (int i = 0; i < 26; i++)
            {
                string temp = Decrypt(cipherText, i);

                combinations.Add(temp);
            }

            return combinations;
        }

        static string[] listToArray(List<string> temp)
        {
            string[] array = new string[temp.Count];

            for (int i = 0; i < temp.Count; i++)
            {
                array[i] = temp[i];
            }

            return array;
        }
        static string[] SmartCracker(string cipherText)
        {
            int otherCount = 0;

            int holderTwo = 0;

            List<string> everything = new List<string>();

            everything.Add("");

            string[] array = new string[1];

            for (int l = 0; l < otherCount + 1; l++)
            {
                for (int k = 0; k < cipherText.Length; k++)
                {
                    if (cipherText[k] == ' ')
                    {
                        otherCount++;
                        holderTwo++;
                        everything.Add("");

                        break;
                    }

                    else
                    {
                        everything[holderTwo] += cipherText[k];
                    }

                }
                string empty = "";

                List<string> final = new List<string>();

                final.Add(empty);

                string filename = "output.txt";

                List<string> temp = new List<string>();

                temp = bruteForce(everything[l]);

                array = new string[final.Count];

                int count = 0;

                string[] holder = new string[temp.Count];

                holder = listToArray(temp);

                if (File.Exists(filename))
                {
                    string[] checker = File.ReadAllLines(filename);
                    for (int i = 0; i < holder.Length; i++)
                    {
                        for (int j = 0; j < checker.Length; j++)
                        {
                            if (holder[i].Length == checker[j].Length && holder[i] == checker[j])
                            {
                                final[count] += holder[i];
                                count++;
                                final.Add("");

                            }
                        }

                    }
                }



                


                  array = listToArray(final);

               
                     
            }

            return array;
        }
        static string Decrypt(string cipherText, int key)
        {
            string plainText = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < cipherText.Length; i++)
            {


                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (cipherText[i] == alphabet[j])
                    {
                        int temp = j - key;

                        if (temp < 0)
                        {
                            temp = 26 + temp;
                        }
                        plainText += alphabet[temp % 26];
                    }

                }
            }

            cipherText = plainText;
            return cipherText;

        }

        static string ShortDecrypt(string cipherText, int key, int shortkey)
        {
            shortkey = -key;
            EncryptShortVersion(cipherText, key, shortkey);

            return cipherText;
        }


        static string EncryptShortVersion(string plainText, int key, int shortkey)
        {
            shortkey = +key;
            string cipherText = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < plainText.Length; i++)
            {


                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (plainText[i] == alphabet[j])
                    {
                        cipherText += alphabet[(j + shortkey) % 26];
                    }

                }
            }

            plainText = cipherText;
            return plainText;
        }

        static string Encrypt(string plainText, int key)
        {

            string cipherText = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < plainText.Length; i++)
            {


                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (plainText[i] == alphabet[j])
                    {
                        cipherText += alphabet[(j + key) % 26];
                    }

                }
            }

            plainText = cipherText;
            return plainText;
        }


        static string LanguageDetection(string input)
        {
            string empty = "";

            List<string> final = new List<string>();
           
            
            List<string> everything = new List<string>();

            everything.Add("");

            string[] array = new string[1];
            final.Add(empty);

            string filename = "output.txt"; 
            array = new string[final.Count];

            int count = 0;

            string[] holder = new string[temp.Count];

            holder = listToArray(temp);

            if (File.Exists(filename))
            {
                string[] checker = File.ReadAllLines(filename);
                for (int i = 0; i < holder.Length; i++)
                {
                    for (int j = 0; j < checker.Length; j++)
                    {
                        if (holder[i].Length == checker[j].Length && holder[i] == checker[j])
                        {
                            final[count] += holder[i];
                            count++;
                            final.Add("");

                        }
                    }

                }
            }

        }

        static void Main(string[] args)
        {




            // Console.WriteLine(someText);

            // string encrypted = Encrypt(someText, 7);
            //            Console.WriteLine(encrypted);

            //   string[] array = new string[26];
            /*
             int key = 7;

             int shortkey = key + 26;
             Console.WriteLine(word);
             holder = EncryptShortVersion(word, key, shortkey);
             Console.WriteLine();
             Console.WriteLine($"{holder}");
             Console.WriteLine();
             shortkey = 26 - key;
             otherHolder = ShortDecrypt(word, key, shortkey);
             Console.WriteLine(word);

     */

            /*
            List<string> allcombinations = bruteForce(encrypted);

            Console.WriteLine("Brute forced all combos");


            for (int i = 0; i < allcombinations.Count; i++)
            {
                Console.WriteLine(allcombinations[i]);
            }

    */
            //     holder = Decrypt(encrypted, 7);
            //    Console.WriteLine(holder);


            //Console.ReadKey(true);
            string someText = "axeeh";
            Console.WriteLine(someText);
            string[] hold = SmartCracker(someText);

            for (int i = 0; i < hold.Length; i++)
            {
                Console.WriteLine(hold[i]);
            }








        }
    }
}

