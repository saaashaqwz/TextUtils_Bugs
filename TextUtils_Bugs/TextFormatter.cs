using System.Text;

namespace TextUtils_Bugs;

public class TextFormatter : ITextFormatter
{
    public string RemoveExtraSpaces(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        StringBuilder result = new StringBuilder();
        bool previousWasSpace = false;
        foreach (char character in text)
        {
            if (character == ' ')
            {
                if (!previousWasSpace)
                {
                    result.Append(character);
                    previousWasSpace = true;
                }
            }
            else
            {
                result.Append(character);
                previousWasSpace = false;
            }
        }
        return result.ToString().Trim();
    }
    public string ChangeCase(string text, TextCase textCase)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        return textCase switch
        {
            TextCase.Upper => text.ToUpper(),
            TextCase.Lower => text.ToLower(),
            _ => text
        };
    }
    public string JustifyText(string text, int lineWidth = 80)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        var words = text.Split(new[] { ' ' },
        StringSplitOptions.RemoveEmptyEntries);
        var lines = BuildLines(words, lineWidth);
        return JustifyLines(lines, lineWidth);
    }
    
    private List<List<string>> BuildLines(string[] words, int lineWidth)
    {
        var lines = new List<List<string>>();
        var currentLine = new List<string>();
        int currentLength = 0;
        foreach (var word in words)
        { 
            if (currentLength + word.Length + currentLine.Count <= lineWidth)
            {
                currentLine.Add(word);
                currentLength += word.Length;
            }
            else
            {
                if (currentLine.Count > 0)
                { 
                    lines.Add(currentLine);
                }
                currentLine = new List<string> { word };
                currentLength = word.Length;
            }
        }
        if (currentLine.Count > 0)
        {
            lines.Add(currentLine);
        }
        return lines;
    }
    private string JustifyLines(List<List<string>> lines, int lineWidth)
    {
        var result = new List<string>();
        foreach (var lineWords in lines)
        {
            if (lineWords.Count == 1)
            { 
                result.Add(lineWords[0]);
            }
            else
            {
                result.Add(JustifyLine(lineWords, lineWidth));
            }
        }
        return string.Join("\n", result);
    }
    private string JustifyLine(List<string> words, int lineWidth)
    {
        int totalSpaces = lineWidth - words.Sum(word => word.Length);
        int spaceBetween = totalSpaces / (words.Count - 1);
        int extraSpaces = totalSpaces % (words.Count - 1);
        StringBuilder alignedLine = new StringBuilder(words[0]);
        
        for (int i = 1; i < words.Count; i++)
        {
            int spaces = spaceBetween + (i <= extraSpaces ? 1 : 0);
            alignedLine.Append(new string(' ', spaces));
            alignedLine.Append(words[i]);
        }
        return alignedLine.ToString();
    }
}