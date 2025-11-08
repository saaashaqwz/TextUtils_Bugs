using System.Text;

namespace TextUtils_Bugs;

public class TextProcessor
{
    private int maxLineLength = 80;
    private int minWordLength = 3;
        
    public void ProcessText(string inputFile, string outputFile, int operation)
    {
        string text = File.ReadAllText(inputFile);
        string result;

        if (operation == 1) result = text.ToUpper();
        else if (operation == 2) result = text.ToLower();
        else result = text;
        
        File.WriteAllText(outputFile, result);
    }
    
    public int CountWords(string text)
    {
        if (string.IsNullOrEmpty(text)) return 0;
        return text.Split(' ').Length;
    }
    
    public int CountWords2(string text)
    {
        if (string.IsNullOrEmpty(text)) return 0;
        return text.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    
    public string FindLongestWord(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        var words = text.Split(' ');
        string longest = "";
        foreach (var word in words)
        {
            if (word.Length > longest.Length) longest = word;
        }
        return longest;
    }
    
    public Dictionary<char, int> GetCharFrequency(string text)
    {
        var frequency = new Dictionary<char, int>();
        foreach (char ch in text)
        {
            if (frequency.ContainsKey(ch)) frequency[ch]++;
            else frequency[ch] = 1;
        }
        return frequency;
    }
    
    public string RemoveExtraSpaces(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        
        StringBuilder result = new StringBuilder();
        bool previousWasSpace = false;
        
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                if (!previousWasSpace)
                {
                    result.Append(text[i]);
                    previousWasSpace = true;
                }
            }
            else
            {
                result.Append(text[i]);
                previousWasSpace = false;
            }
        }
        
        return result.ToString().Trim();
    }
    
    public string TransformText(string text, string operation)
    {
        if (operation == "upper") return text.ToUpper();
        else if (operation == "lower") return text.ToLower();
        else if (operation == "trim") return text.Trim();
        else return text;
    }
    
    private void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}   