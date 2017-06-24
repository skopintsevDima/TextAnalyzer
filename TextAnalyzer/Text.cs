using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace TextAnalyzer
{
    public class Reader
    {
        public static string readTextFromFile()
        {
            string text = "";
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.docx",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application wordApp = new Word.Application();
                Object fileName = dialog.FileName;
                wordApp.Documents.Open(ref fileName);
                Word.Document wordDoc = wordApp.ActiveDocument;
                foreach (Word.Paragraph paragraph in wordDoc.Paragraphs)
                {
                    string line = paragraph.Range.Text;
                    text = string.Concat(text, line);
                }
                wordApp.Quit();
            }
            return text;
        }
    }

    public class Analyzer
    {
        public static List<string> getWordsFromText(string text)
        {
            List<string> words = new List<string>();
            char[] separator = { ' ', ',', '.', ':', '"', '\'', ';', '-', '\t' };
            string[] splittedWords = text.Split(separator);
            foreach (string splittedWord in splittedWords)
            {
                string word = splittedWord.Trim();
                if (word.Length > 0)
                {
                    words.Add(word);
                }
            }
            return words;
        }

        public static Dictionary<string, int> getWordsCount(List<string> words)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                string key = words[i];
                try
                {
                    counts[key]++;
                }
                catch(KeyNotFoundException e)
                {
                    counts.Add(key, 1);
                }
            }
            return counts;
        }
    }
}
