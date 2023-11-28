using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "The “C# Professional” course includes the topics I discuss in my CLR via C# book and teaches how the CLR works thereby showing you how to develop applications and reusable components for the .NET Framework.";
            Console.WriteLine($"Input sentence: {sentence}\n");
            
            Dictionary<int, List<string>> words = GroupByWordsLength(sentence); //Create dictionary with grouped words by length using the GroupByWordsLength method

            Console.WriteLine("Output: ");
            foreach (var group in words.OrderBy(g => g.Key))//Order our groups by length increasing and show them with count of words, and these words
            {
                Console.WriteLine($"Words of length: {group.Key}, Count: {group.Value.Count}");
                foreach (var word in group.Value)
                {
                    Console.WriteLine(word);
                }
            }


            Console.ReadKey();
        }

        static Dictionary<int, List<string>> GroupByWordsLength(string sentence) // Method to group words by their lengths
        {
            string[] words = sentence.Split(new char[] { ' ' }); // Split a string into substrings(words) based on the character space(' ')
            var groupedWords = new Dictionary<int, List<string>>(); //Create new dictinary to group words by length

            foreach (string word in words.Distinct()) //Search unique words, create new dictionaries where key is length, and add words with appropriate length in these groups
            {
                int length = word.Length;
                if (!groupedWords.ContainsKey(length))
                    groupedWords[length] = new List<string>();

                groupedWords[length].Add(word);
            }

            return groupedWords;
        }
    }
}
