using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalizer.Models;

namespace TextAnalizer.Services
{
    public class WordsAmount
    {
        public List<WordInText> TextAnalize(string iputText)
        {
            char[] delimiterChars = {' ', ',', '.', ':'};
            List<WordInText> orderedWords = iputText
              .Split(delimiterChars)
              .GroupBy(x => x)
              .Select(x => new WordInText
              {
                  Word = x.Key,
                  Amount = x.Count()
              })
              .OrderByDescending(x => x.Amount).ToList();
            for (int i = 0; i< orderedWords.Count(); i++)
            {
                if (orderedWords[i].Word == "")
                    orderedWords.Remove(orderedWords[i]);
            }

            return orderedWords;

        }
    }
}
