using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public static void SaveDictionaries(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
    {
        foreach (var dictionaryName in dictionaries.Keys)
        {
            string dictionariesFolderPath = null;
            string dictionaryFilePath = Path.Combine(dictionariesFolderPath, dictionaryName + ".txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(dictionaryFilePath))
                {
                    foreach (var word in dictionaries[dictionaryName])
                    {
                        string translations = string.Join(", ", word.Value);
                        writer.WriteLine($"{word.Key}: {translations}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка при збереженні словника \"" + dictionaryName + "\": " + ex.Message);
            }
        }
    }

    public static Dictionary<string, Dictionary<string, List<string>>> LoadDictionaries()
    {
        var dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();

        string dictionariesFolderPath = null;
        var dictionaryFiles = Directory.GetFiles(dictionariesFolderPath);

        foreach (var dictionaryFile in dictionaryFiles)
        {
            string dictionaryName = Path.GetFileNameWithoutExtension(dictionaryFile);

            try
            {
                var dictionaryContent = File.ReadAllLines(dictionaryFile);
                var dictionary = new Dictionary<string, List<string>>();

                foreach (var line in dictionaryContent)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string word = parts[0].Trim();
                        string[] translations = parts[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray();

                        if (!dictionary.ContainsKey(word))
                        {
                            dictionary.Add(word, translations.ToList());
                        }
                        else
                        {
                            dictionary[word].AddRange(translations);
                        }
                    }
                }

                dictionaries.Add(dictionaryName, dictionary);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка при зчитуванні словника \"" + dictionaryName + "\": " + ex.Message);
            }
        }

        return dictionaries;
    }
}
