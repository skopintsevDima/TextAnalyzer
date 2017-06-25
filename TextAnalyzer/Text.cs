using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace TextAnalyzer
{
    public class Reader
    {
        public OnProgressChangedListener onProgressChangedListener;

        public Reader(OnProgressChangedListener onProgressChangedListener)
        {
            this.onProgressChangedListener = onProgressChangedListener;
        }

        public string readTextFromFile()
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
                
                //Init progress bar on Form
                onProgressChangedListener.onProgressInitialized(wordDoc.Paragraphs.Count, 1);
                foreach (Word.Paragraph paragraph in wordDoc.Paragraphs)
                {
                    string line = paragraph.Range.Text;
                    text = string.Concat(text, line);
                    //Set new position on progress bar
                    onProgressChangedListener.onProgressChanged(1);
                }
                wordApp.Quit();
            }
            onProgressChangedListener.onProgressCompleted("Текст загружен!");
            return text;
        }
    }

    public class Analyzer
    {
        public OnProgressChangedListener onProgressChangedListener;

        public Analyzer(OnProgressChangedListener onProgressChangedListener)
        {
            this.onProgressChangedListener = onProgressChangedListener;
        }

        public List<string> getWordsFromText(string text)
        {
            List<string> words = new List<string>();
            char[] separator = { ' ', ',', '.', ':', '"', '\'', ';', '-', ')', '(', '?', '!', '_', '\t', '\n', '\r' };
            string[] splittedWords = text.Split(separator);
            //Init progress bar on Form
            onProgressChangedListener.onProgressInitialized(splittedWords.Length, 1);
            foreach (string splittedWord in splittedWords)
            {
                string word = splittedWord.Trim();
                if (word.Length > 0 && !Int32.TryParse(word, out int res))
                {
                    words.Add(word);
                }
                // Set new position on progress bar
                onProgressChangedListener.onProgressChanged(1);
            }
            return words;
        }

        public Dictionary<string, int> getWordsCount(List<string> words)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            //Init progress bar on Form
            onProgressChangedListener.onProgressInitialized(words.Count, 1);
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
                // Set new position on progress bar
                onProgressChangedListener.onProgressChanged(1);
            }
            return counts;
        }
    }
}
