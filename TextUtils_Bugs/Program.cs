using System.Text;

namespace TextUtils_Bugs;

class Program
{
    public static int a(string t)
    {
        if (string.IsNullOrEmpty(t)) return 0;
        int c = 0;
        bool p = false;
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == ' ' || t[i] == '\t' || t[i] == '\n')
            {
                if (!p) c++;
                p = true;
            }
            else
            {
                p = false;
            }
        }
        if (!p) c++;
        return c;
    }

    public static string b(string t)
    {
        if (string.IsNullOrEmpty(t)) return "";
        var w = t.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        string m = "";
        foreach (var ww in w)
        {
            if (ww.Length > m.Length) m = ww;
        }
        return m;
    }

    public static Dictionary<char, int> c(string t)
    {
        var d = new Dictionary<char, int>();
        foreach (char ch in t)
        {
            if (d.ContainsKey(ch)) d[ch]++;
            else d[ch] = 1;
        }
        return d;
    }

    public static string d(string t)
    {
        if (string.IsNullOrEmpty(t)) return "";
        StringBuilder r = new StringBuilder();
        bool p = false;
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == ' ')
            {
                if (!p)
                {
                    r.Append(t[i]);
                    p = true;
                }
            }
            else
            {
                r.Append(t[i]);
                p = false;
            }
        }
        return r.ToString().Trim();
    }

    public static string e(string t, int x)
    {
        if (x == 1) return t.ToUpper();
        else if (x == 2) return t.ToLower();
        else return t;
    }

    public static string f(string t, int l = 80)
    {
        if (string.IsNullOrEmpty(t)) return "";
        
        var w = t.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var lines = new List<string>();
        var currentLine = new List<string>();
        int currentLength = 0;
        
        foreach (var word in w)
        {
            if (currentLength + word.Length + currentLine.Count <= l)
            {
                currentLine.Add(word);
                currentLength += word.Length;
            }
            else
            {
                if (currentLine.Count > 0)
                {
                    lines.Add(string.Join(" ", currentLine));
                }
                currentLine = new List<string> { word };
                currentLength = word.Length;
            }
        }
        
        if (currentLine.Count > 0)
        {
            lines.Add(string.Join(" ", currentLine));
        }
        
        var result = new List<string>();
        foreach (var line in lines)
        {
            var words = line.Split(' ');
            if (words.Length == 1)
            {
                result.Add(words[0]);
            }
            else
            {
                int totalSpaces = l - words.Sum(w => w.Length);
                int spaceBetween = totalSpaces / (words.Length - 1);
                int extraSpaces = totalSpaces % (words.Length - 1);
                
                StringBuilder alignedLine = new StringBuilder(words[0]);
                for (int i = 1; i < words.Length; i++)
                {
                    int spaces = spaceBetween + (i <= extraSpaces ? 1 : 0);
                    alignedLine.Append(new string(' ', spaces));
                    alignedLine.Append(words[i]);
                }
                result.Add(alignedLine.ToString());
            }
        }
        
        return string.Join("\n", result);
    }

    public static object DoEverything(string text, int operation, int param = 0)
    {
        switch (operation)
        {
            case 1: return a(text);
            case 2: return b(text);
            case 3: return c(text);
            case 4: return d(text);
            case 5: return e(text, param);
            case 6: return f(text, param);
            default: return "Неверная операция";
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("=== Система обработки текста ===");
        
        TextProcessor processor = new TextProcessor();
        
        // Тестовые данные
        string sampleText = "Это   пример   текста   с   лишними   пробелами";
        string textWithPunctuation = "Привет, мир! Это тест.";
        string simpleText = "Простой текст без лишних пробелов";
        
        // Демонстрация работы с багами
        Console.WriteLine($"Исходный текст: '{sampleText}'");
        
        int wordCount = processor.CountWords(sampleText);
        Console.WriteLine($"Количество слов: {wordCount} (должно быть 6)");
        
        string longestWord = processor.FindLongestWord(textWithPunctuation);
        Console.WriteLine($"Самое длинное слово: '{longestWord}' (должно быть 'Привет' без запятой)");
        
        var charFrequency = processor.GetCharFrequency(simpleText);
        Console.WriteLine("Частота символов (включая пробелы):");
        foreach (var kvp in charFrequency.Take(5))
        {
            Console.WriteLine($"  '{kvp.Key}': {kvp.Value}");
        }
        
        string cleanedText = processor.RemoveExtraSpaces(sampleText);
        Console.WriteLine($"Без лишних пробелов: '{cleanedText}'");
        
        // Попытка обработать несуществующий файл (вызовет исключение)
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