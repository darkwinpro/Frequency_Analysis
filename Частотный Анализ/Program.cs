using System;

namespace Частотный_Анализ
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] allWords = UserInput();
            var uniqueWords = FindUniueWords(allWords);
            var repeting = CountRepetedWords(allWords, uniqueWords);
            Sort(uniqueWords, repeting);
            PrintPairs(repeting, uniqueWords);
        }

        private static string[] UserInput()
        {
            var countWords = Convert.ToInt32(Console.ReadLine());
            string[] words = new string[countWords];
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = Console.ReadLine();
            }

            return words;
        }

        private static bool IsStringGreater(string a, string b)
        {
            var minLength = Math.Min(a.Length, b.Length);
            a = a.ToLower();
            b = b.ToLower();
            
            for (int i = 0; i < minLength; i++)
            {
                if (a[i] > b[i])
                {
                    return true;
                }

                if (a[i] < b[i])
                {
                    return false;
                }
            }

            return a.Length > b.Length;
        }

        private static void Sort(string[] words, int[] repeating)
        {
            for (var firstUnsortedIndex = 0; firstUnsortedIndex < repeating.Length; firstUnsortedIndex++)
            {
                var maxIndex = FindMaxNumber(firstUnsortedIndex, repeating, words);

                Swap(ref repeating[maxIndex], ref repeating[firstUnsortedIndex]);
                Swap(ref words[maxIndex], ref words[firstUnsortedIndex]);
            }
        }

        private static int FindMaxNumber(int startIndex, int[] repeting, string[] words)
        {
            var maxIndex = startIndex;
            for (int j = startIndex; j < repeting.Length; j++)
            {
                if (repeting[j] > repeting[maxIndex])
                {
                    maxIndex = j;
                }

                if (repeting[j] == repeting[maxIndex] && !IsStringGreater(words[j], words[maxIndex]))
                {
                    maxIndex = j;
                }
            }

            return maxIndex;
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            var temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
        private static void Swap(ref string firstWord, ref string secondWord)
        {
            var temp = firstWord;
            firstWord = secondWord;
            secondWord = temp;
        }

        private static int[] CountRepetedWords(string[] allWords, string[] uniqueWords)
        {
            var repetedWords = new int[uniqueWords.Length];
            for (var i = 0; i < uniqueWords.Length; i++)
            {
                var uniqueWord = uniqueWords[i];
                int countRepeatedWords = 0;
                foreach (var word in allWords)
                {
                    if (uniqueWord == word)
                    {
                        countRepeatedWords++;
                    }
                }

                repetedWords[i] = countRepeatedWords;
            }

            return repetedWords;
        }

        private static string[] FindUniueWords(params string[] allWords)
        {
            var uniueWords = new string[allWords.Length];
            var currentUnieWordsIndex = 0;
            
            foreach (var word in allWords)
            {
                if (!Contains(uniueWords, word))
                {
                    uniueWords[currentUnieWordsIndex] = word;
                    currentUnieWordsIndex++;
                }
            }

            var uniqueWordsResized = Resize(uniueWords, currentUnieWordsIndex);
            return uniqueWordsResized;
        }

        private static string[] Resize(string[] array, int newSize)
        {
            var resisedArray = new string[newSize];
            for (var index = 0; index < newSize; index++)
            {
                var uniqueWord = array[index];
                resisedArray[index] = uniqueWord;
            }
            
            return resisedArray;
        }

        private static bool Contains(string[] array, string word)
        {
            foreach (var someWord in array)
            {
                if (word == someWord)
                {
                    return true;
                }
            }
            
            return false;
        }

        private static void PrintPairs(int[] repeating, string[] words)
        {
            for (var i = 0; i < repeating.Length; i++)
            {
                Console.WriteLine(words[i] + " - " + repeating[i]);
            }
        }
    }
}