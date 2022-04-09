using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TextReader
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Please enter the file path.");
            string fileGiven = Console.ReadLine();
            fileGiven.ToLower();
            bool doesExist = false;
            do
            {

                if (File.Exists(fileGiven))
                {
                    doesExist = true;
                }
                else
                {
                    Console.WriteLine(fileGiven + " is not a correct file path, try again.");
                    doesExist = false;
                    fileGiven = Console.ReadLine();
                    fileGiven.ToLower();
                }
            }
            while (doesExist == false);

            string lines = File.ReadAllText(fileGiven);
            string[] words = lines.Split(' ');
            var dict = new Dictionary<string, int>();

            foreach (var value in words)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }

            var myList = from entry in dict orderby entry.Value descending select entry;
            var myNewList = myList.ToList();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(myNewList[i].Key + " " + myNewList[i].Value);
            }
            //foreach (var pair in dict)

                //Console.WriteLine("Word {0} occurred {1} times.", pair.Key, pair.Value);
                //Console.WriteLine(words.Length);
        }
    }
}
