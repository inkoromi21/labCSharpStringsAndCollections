using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextFileCorrector
{
  public class SpellingCorrector
  {
    private Dictionary<string, List<string>> _errorWords;

    public SpellingCorrector(Dictionary<string, List<string>> errorWords)
    {
      _errorWords = errorWords;
    }

    public string Correct(string content, out int correctionsCount)
    {
      correctionsCount = 0;
      string result;
      result = content;

      Dictionary<string, List<string>>.KeyCollection correctWords;
      correctWords = _errorWords.Keys;

      List<string> correctWordsList;
      correctWordsList = new List<string>(correctWords);

      int wordIndex;
      wordIndex = 0;

      string correctWord;
      correctWord = null;

      List<string> wrongVariants;
      wrongVariants = null;

      int variantIndex;
      variantIndex = 0;

      string wrongWord;
      wrongWord = null;

      string pattern;
      pattern = null;

      string newResult;
      newResult = null;

      bool wasReplaced;
      wasReplaced = false;

      while (wordIndex < correctWordsList.Count)
      {
        correctWord = correctWordsList[wordIndex];
        wrongVariants = _errorWords[correctWord];

        variantIndex = 0;

        while (variantIndex < wrongVariants.Count)
        {
          wrongWord = wrongVariants[variantIndex];
          pattern = string.Format(@"\b{0}\b", Regex.Escape(wrongWord));
          newResult = Regex.Replace(result, pattern, correctWord, RegexOptions.IgnoreCase);

          wasReplaced = (newResult != result);

          if (wasReplaced)
          {
            ++correctionsCount;
            result = newResult;
          }

          ++variantIndex;
        }

        ++wordIndex;
      }

      return result;
    }
  }
}
