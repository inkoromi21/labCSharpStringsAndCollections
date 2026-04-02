using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextFileCorrector
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Введите путь к директории: ");
      string directoryPath;
      directoryPath = Console.ReadLine();

      bool directoryExists;
      directoryExists = Directory.Exists(directoryPath);

      if (!directoryExists)
      {
        Console.WriteLine("Указанная директория не существует!");
        return;
      }

      ErrorDictionary errorDictionaryBuilder;
      errorDictionaryBuilder = new ErrorDictionary();

      Dictionary<string, List<string>> errorWords;
      errorWords = errorDictionaryBuilder.Build();

      string[] files;
      files = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

      int filesCount;
      filesCount = files.Length;

      if (filesCount == 0)
      {
        Console.WriteLine("В указанной директории нет текстовых файлов.");
        return;
      }

      Console.WriteLine(string.Format("Найдено файлов: {0}", filesCount));
      Console.WriteLine("Начинаю обработку...");
      Console.WriteLine();

      int fileIndex;
      fileIndex = 0;

      string currentFilePath;
      currentFilePath = null;

      while (fileIndex < filesCount)
      {
        currentFilePath = files[fileIndex];
        ProcessFile(currentFilePath, errorWords);
        ++fileIndex;
      }

      Console.WriteLine();
      Console.WriteLine("Обработка завершена!");
    }

    static void ProcessFile(string filePath, Dictionary<string, List<string>> errorWords)
    {
      Console.WriteLine(string.Format("Обрабатывается файл: {0}", Path.GetFileName(filePath)));

      string content;
      content = File.ReadAllText(filePath, Encoding.UTF8);

      string originalContent;
      originalContent = content;

      SpellingCorrector spellingCorrector;
      spellingCorrector = new SpellingCorrector(errorWords);

      int spellingCorrectionsCount;
      spellingCorrectionsCount = 0;

      string contentAfterSpelling;
      contentAfterSpelling = spellingCorrector.Correct(content, out spellingCorrectionsCount);

      PhoneNumberFormatter phoneFormatter;
      phoneFormatter = new PhoneNumberFormatter();

      string finalContent;
      finalContent = phoneFormatter.Format(contentAfterSpelling);

      bool hasChanges;
      hasChanges = (finalContent != originalContent);

      string backupPath;
      backupPath = null;

      if (hasChanges)
      {
        backupPath = filePath + ".bak";
        File.Copy(filePath, backupPath, true);
        File.WriteAllText(filePath, finalContent, Encoding.UTF8);

        Console.WriteLine(string.Format("  Исправлено: {0} орфографических ошибок", spellingCorrectionsCount));
        Console.WriteLine("  Изменения сохранены");
      }
      else
      {
        Console.WriteLine("  Изменений не требуется");
      }
    }
  }
}