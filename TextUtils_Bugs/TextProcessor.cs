using System.Text;

namespace TextUtils_Bugs;

public class TextProcessor
{
    private readonly ITextAnalyzer _analyzer;
    private readonly ITextFormatter _formatter;
    public TextProcessor(ITextAnalyzer analyzer, ITextFormatter formatter)
    {
        _analyzer = analyzer;
        _formatter = formatter;
    }
    public TextResult Process(string text)
    {
        return new TextResult
        {
            WordCount = _analyzer.CountWords(text),
            LongestWord = _analyzer.FindLongestWord(text),
            Frequency = _analyzer.GetCharacterFrequency(text),
            Cleaned = _formatter.RemoveExtraSpaces(text)
        };
    }
}   