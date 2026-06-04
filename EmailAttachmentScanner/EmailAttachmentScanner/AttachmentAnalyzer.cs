using System;
using System.Linq;

public class AttachmentAnalyzer
{
    private readonly string fileName;

    public AttachmentAnalyzer(string fileName)
    {
        this.fileName = fileName?.Trim() ?? string.Empty;
    }

    // 1. Виконувані файли
    public bool IsExecutableFile()
    {
        string ext = GetExtension();
        return ext == ".exe" || ext == ".bat" || ext == ".cmd" ||
               ext == ".ps1" || ext == ".vbs" || ext == ".js" || ext == ".jar";
    }

    // 2. Файли з макросами
    public bool IsMacroFile()
    {
        string ext = GetExtension();
        return ext == ".docm" || ext == ".xlsm" || ext == ".pptm";
    }

    // 3. Подвійне розширення
    public bool HasDoubleExtension()
    {
        if (string.IsNullOrEmpty(fileName)) return false;

        // Знаходимо всі крапки
        var dots = fileName.Split('.');
        return dots.Length > 2 &&
               !fileName.EndsWith(".tar.gz", StringComparison.OrdinalIgnoreCase);
    }

    // 4. Підозрілі ключові слова
    public bool ContainsSuspiciousKeywords()
    {
        string lower = fileName.ToLowerInvariant();
        string[] suspicious = { "crack", "keygen", "patch", "hack", "free", "invoice",
                               "update", "secure", "password", "bank", "paypal", "urgent" };

        return suspicious.Any(word => lower.Contains(word));
    }

    // 5. Рівень ризику (0-100)
    public int CalculateRiskLevel()
    {
        int risk = 0;

        if (IsExecutableFile()) risk += 35;
        if (IsMacroFile()) risk += 30;
        if (HasDoubleExtension()) risk += 25;
        if (ContainsSuspiciousKeywords()) risk += 20;

        // Додаткові перевірки
        if (fileName.Contains(" ") && HasDoubleExtension()) risk += 10;
        if (fileName.Length > 60) risk += 5;

        return Math.Min(risk, 100);
    }

    private string GetExtension()
    {
        if (string.IsNullOrEmpty(fileName)) return string.Empty;
        int lastDot = fileName.LastIndexOf('.');
        return lastDot >= 0 ? fileName.Substring(lastDot).ToLowerInvariant() : string.Empty;
    }

    // Для зручного виведення
    public string GetAnalysisReport()
    {
        return $"Файл: {fileName}\n" +
               $"Виконуваний файл: {(IsExecutableFile() ? "Так" : "Ні")}\n" +
               $"Макроси Office: {(IsMacroFile() ? "Так" : "Ні")}\n" +
               $"Подвійне розширення: {(HasDoubleExtension() ? "Так" : "Ні")}\n" +
               $"Підозрілі слова: {(ContainsSuspiciousKeywords() ? "Так" : "Ні")}\n" +
               $"Рівень ризику: {CalculateRiskLevel()}%";
    }
}