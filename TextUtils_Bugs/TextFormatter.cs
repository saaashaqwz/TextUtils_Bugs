using System.Text;

namespace TextUtils_Bugs;

public class TextFormatter : ITextFormatter
{
    public string RemoveExtraSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;
        return string.Join(' ', text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
    }

    public string ChangeCase(string text, TextCase textCase)
    {
        return textCase switch
        {
            TextCase.Upper => text.ToUpper(),
            TextCase.Lower => text.ToLower(),
            _ => text
        };
    }

    public string JustifyText(string text, int lineWidth = 80)
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var lines = BuildLines(words, lineWidth);
        return string.Join("\n", lines.Select(JustifyLine));
    }

    private List<List<string>> BuildLines(string[] words, int width)
    {
        var lines = new List<List<string>>();
        var current = new List<string>();
        int length = 0;

        foreach (var word in words)
        {
            if (length + word.Length + current.Count > width)
            {
                lines.Add(current);
                current = new List<string>();
                length = 0;
            }
            current.Add(word);
            length += word.Length;
        }
        if (current.Count > 0) lines.Add(current);
        return lines;
    }

    private string JustifyLine(List<string> words)
    {
        if (words.Count == 1) return words[0];
        int totalLength = words.Sum(w => w.Length);
        int spaces = 80 - totalLength;
        int gaps = words.Count - 1;
        int baseSpaces = spaces / gaps;
        int extra = spaces % gaps;

        var result = new StringBuilder();
        for (int i = 0; i < words.Count; i++)
        {
            result.Append(words[i]);
            if (i < gaps) result.Append(' ', baseSpaces + (i < extra ? 1 : 0));
        }
        return result.ToString();
    }
}