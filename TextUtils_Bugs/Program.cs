using System.Text;

namespace TextUtils_Bugs;

class Program
{
    static void Main(string[] args)
    {
        var analyzer = new TextAnalyzer();
        var formatter = new TextFormatter();
        var processor = new TextProcessor(analyzer, formatter);
        string sampleText = "Это пример текста с лишними пробелами и разными словами разной длины";
        var result = processor.ProcessText(sampleText);
       
        Console.WriteLine($"Текст: {sampleText}");
        Console.WriteLine($"Слов: {result.WordCount}");
        Console.WriteLine($"Самое длинное слово: {result.LongestWord}");
        Console.WriteLine("Частота символов:");
       
        foreach (var kvp in result.CharacterFrequency)
        {
            if (kvp.Value > 1)
            {
                Console.WriteLine($" '{kvp.Key}': {kvp.Value}");
            }
        }
        Console.WriteLine($"Очищенный текст: {result.CleanedText}");
       
        string upperText = formatter.ChangeCase(sampleText, TextCase.Upper);
        Console.WriteLine($"В верхнем регистре: {upperText}");
       
        string lorem = "Это длинный текст который нужно выровнять по ширине чтобы он выглядел красиво и аккуратно на экране";
    
        string aligned = formatter.JustifyText(lorem, 50);
        Console.WriteLine("\nВыровненный текст:");
      
        Console.WriteLine(aligned);
        Console.ReadLine();
    }
}
