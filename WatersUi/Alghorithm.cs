using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WatersUi
{
    public class Alghorithm
    {
        public static string Path { get; set; }

        public static List<string> Go(char[] input)
        {
            return GetWordsFromDb(DoPermutations(GetSeed(input)), ReadWordsDb());
        }

        #region logic

        private static List<string> ReadWordsDb()
        {
            List<string> wordsDb = null;
            try
            {
                // get all words from file
                wordsDb =
                    File.ReadAllText(Path, Encoding.ASCII)
                        .Replace("\r", "")
                        .Split('\n')
                        .ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Can't read file");
            }
            return wordsDb;
        }

        private static List<string> GetSeed(char[] input)
        {
            // seed are the varius combinations 
            // of chars that will be permutated
            var seed = new List<string>();

            var charApperenceCount = CountNumberOfCharApperences(input);

            foreach (var charInput in input)
            {
                var newPerm = new List<string>();

                // branch the list
                newPerm.AddRange(seed);

                var temp = RemoveMaxChar(newPerm, charInput, charApperenceCount);

                // add char to all strings
                newPerm = newPerm.Select(x => x + charInput).ToList();

                // some of the have been excluded and nothing happend
                newPerm.AddRange(temp);
                
                // put list back to main branch
                foreach (var n in newPerm.Where(n => !seed.Contains(n)))
                    seed.Add(n);

                // add itself
                if(!seed.Contains(charInput.ToString()))
                    seed.Add(charInput.ToString());
            }
            return seed;
        }

        private static List<string> GetWordsFromDb(List<string> permutations, List<string> wordsDb)
        {
            var resultFromDb = new List<string>();
            foreach (var p in permutations)
            {
                resultFromDb.AddRange(wordsDb.Where(x => x == p));
            }
            return resultFromDb;
        }

        private static List<string> DoPermutations(List<string> seed)
        {
            var permutations = new List<string>();
            foreach (var s in seed)
            {
                if (s.Length > 1)
                {
                    var perm = Permutaions.GetPer(s.ToCharArray()).ToList();
                    foreach (var p in perm)
                    {
                        if (!permutations.Contains(p))
                        {
                            permutations.Add(p);
                        }
                    }
                }
            }
            return permutations;
        }

        private static List<string> RemoveMaxChar(List<string> newPerm, char charInput,
            Dictionary<char, int> charApperenceCount)
        {
            // get max char
            var temp = newPerm.Where(x => x.Split(charInput).Length - 1 == charApperenceCount[charInput]).ToList();

            // remove them
            foreach (var t in temp)
            {
                newPerm.Remove(t);
            }

            // remmeber what has been excluded as we will add it back
            return temp;
        }

        private static Dictionary<char, int> CountNumberOfCharApperences(char[] stringInput)
        {
            // count number of char apperences
            var charApperenceCount = new Dictionary<char, int>();
            foreach (var charInput in stringInput)
            {
                if (charApperenceCount.ContainsKey(charInput))
                {
                    charApperenceCount[charInput]++;
                }
                else
                {
                    charApperenceCount[charInput] = 1;
                }
            }
            return charApperenceCount;
        }

        #endregion
    }
}