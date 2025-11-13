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
    public TextResult ProcessText(string text)
    {
        return new TextResult
        {
            WordCount = _analyzer.CountWords(text),
            LongestWord = _analyzer.FindLongestWord(text),
            CharacterFrequency = _analyzer.GetCharacterFrequency(text),
            CleanedText = _formatter.RemoveExtraSpaces(text)
        };
    }
} 
