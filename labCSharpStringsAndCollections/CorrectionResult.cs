using System;

namespace TextFileCorrector
{
  public class CorrectionResult
  {
    private string _correctedContent;
    private int _correctionsCount;

    public CorrectionResult(string correctedContent, int correctionsCount)
    {
      _correctedContent = correctedContent;
      _correctionsCount = correctionsCount;
    }

    public string GetCorrectedContent()
    {
      return _correctedContent;
    }

    public int GetCorrectionsCount()
    {
      return _correctionsCount;
    }
  }
}