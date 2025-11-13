namespace TextUtils_Bugs;

public enum TextCase { Original, Upper, Lower }

public class TextAnalyzer : ITextAnalyzer
{
    private static readonly char[] WordSeparators = { ' ', '\t',
        '\n', '\r' };
    public int CountWords(string text)
    {
        if (string.IsNullOrEmpty(text))
            return 0;
        int wordCount = 0;
        bool inWord = false;
        foreach (char character in text)
        {
            if (IsWordSeparator(character))
            {
                if (inWord)
                    wordCount++;
                inWord = false;
            }
            else
            {
                inWord = true;
            }
        }
        if (inWord)
            wordCount++;
        return wordCount;
    }
    public string FindLongestWord(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        var words = text.Split(WordSeparators,
            StringSplitOptions.RemoveEmptyEntries);
        string longestWord = string.Empty;
        foreach (var word in words)
        {
            if (word.Length > longestWord.Length)
                longestWord = word;
        }
        return longestWord;
    }
    public Dictionary<char, int> GetCharacterFrequency(string text)
    {
        var frequency = new Dictionary<char, int>();
        foreach (char character in text)
        {
            if (frequency.ContainsKey(character))
                frequency[character]++;
            else
                frequency[character] = 1;
        }
        return frequency;
    }
    private bool IsWordSeparator(char character)
    {
        return character == ' ' || character == '\t' || character
            == '\n' || character == '\r';
    }
}