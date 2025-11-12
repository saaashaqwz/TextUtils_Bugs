namespace TextUtils_Bugs;

public class TextResult
{
    public int WordCount { get; set; }
    public string LongestWord { get; set; } = "";
    public Dictionary<char, int> Frequency { get; set; } = new();
    public string Cleaned { get; set; } = "";
}