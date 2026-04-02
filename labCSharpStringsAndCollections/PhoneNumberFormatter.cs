using System.Text.RegularExpressions;

namespace TextFileCorrector
{
  public class PhoneNumberFormatter
  {
    private string _searchPattern;
    private string _replacementPattern;

    public PhoneNumberFormatter()
    {
      _searchPattern = @"\((\d{3})\)\s*(\d{3})-(\d{2})-(\d{2})";
      _replacementPattern = "+380 $1 $2 $3 $4";
    }

    public string Format(string content)
    {
      string result;
      result = Regex.Replace(content, _searchPattern, _replacementPattern);

      return result;
    }
  }
}
