namespace TextUtils_Bugs;

public interface ITextFormatter
{
    string RemoveExtraSpaces(string text);
    string ChangeCase(string text, TextCase textCase);
    string JustifyText(string text, int lineWidth = 80);
}