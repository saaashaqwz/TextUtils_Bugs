namespace TextUtils_Bugs;

public class TextResult
{
    public int WordCount { get; set; }
    public string LongestWord { get; set; } = string.Empty;
    public Dictionary<char, int> CharacterFrequency { get; set; } = new();
    public string CleanedText { get; set; } = string.Empty;
}