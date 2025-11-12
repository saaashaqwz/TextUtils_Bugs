using System.Text;

namespace TextUtils_Bugs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Система обработки текста ===");
        
        TextProcessor processor = new TextProcessor();
        
        string sampleText = "Это   пример   текста   с   лишними   пробелами";
        string textWithPunctuation = "Привет, мир! Это тест.";
        string simpleText = "Простой текст без лишних пробелов";
        
        Console.WriteLine($"Исходный текст: '{sampleText}'");
        
        int wordCount = processor.CountWords(sampleText);
        Console.WriteLine($"Количество слов: {wordCount}");
        
        string longestWord = processor.FindLongestWord(textWithPunctuation);
        Console.WriteLine($"Самое длинное слово: '{longestWord}'");
        
        var charFrequency = processor.GetCharFrequency(simpleText);
        Console.WriteLine("Частота символов:");
        foreach (var kvp in charFrequency.Take(5))
        {
            Console.WriteLine($"  '{kvp.Key}': {kvp.Value}");
        }
        
        string cleanedText = processor.RemoveExtraSpaces(sampleText);
        Console.WriteLine($"Без лишних пробелов: '{cleanedText}'");
        
        try
        {
            processor.ProcessText("nonexistent.txt", "output.txt", 1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
        }
        
        Console.ReadLine();
    }
}