using System;
using System.Collections.Generic;

namespace TextFileCorrector
{
  public class ErrorDictionary
  {
    private Dictionary<string, List<string>> _errorWords;

    public ErrorDictionary()
    {
      _errorWords = new Dictionary<string, List<string>>();
    }

    public Dictionary<string, List<string>> Build()
    {
      List<string> helloMistakes;
      helloMistakes = new List<string>();
      helloMistakes.Add("првиет");
      helloMistakes.Add("пирвет");
      helloMistakes.Add("привт");
      helloMistakes.Add("превед");
      _errorWords.Add("привет", helloMistakes);

      List<string> byeMistakes;
      byeMistakes = new List<string>();
      byeMistakes.Add("покаа");
      byeMistakes.Add("покак");
      byeMistakes.Add("пака");
      _errorWords.Add("пока", byeMistakes);

      List<string> helloFormalMistakes;
      helloFormalMistakes = new List<string>();
      helloFormalMistakes.Add("здраствуйте");
      helloFormalMistakes.Add("здрасте");
      helloFormalMistakes.Add("здравствути");
      _errorWords.Add("здравствуйте", helloFormalMistakes);

      List<string> thanksMistakes;
      thanksMistakes = new List<string>();
      thanksMistakes.Add("спасиба");
      thanksMistakes.Add("спс");
      thanksMistakes.Add("спасибоо");
      _errorWords.Add("спасибо", thanksMistakes);

      List<string> pleaseMistakes;
      pleaseMistakes = new List<string>();
      pleaseMistakes.Add("пжалуйста");
      pleaseMistakes.Add("пожалуста");
      pleaseMistakes.Add("пажалуйста");
      _errorWords.Add("пожалуйста", pleaseMistakes);

      return _errorWords;
    }
  }
}