namespace TextUtils_Bugs;

public interface ITextAnalyzer
{
    int CountWords(string text);
    string FindLongestWord(string text);
    Dictionary<char, int> GetCharacterFrequency(string text);
}