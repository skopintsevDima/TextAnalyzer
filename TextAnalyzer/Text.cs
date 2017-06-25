using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace TextAnalyzer
{
    public interface OnTextLoadedListener
    {
        void onTextLoadingCompleted(string text);
    }

    public interface OnWordsLoadedListener
    {
        void onWordsLoadingCompleted(List<string> words);
    }

    public interface OnWordsCountedListener
    {
        void onWordsCountingCompleted(Dictionary<string, int> counts);
    }

    public class Reader
    {

        private Object fileName;
        private OnTextLoadedListener onTextLoadedListener;
        private OnProgressChangedListener onProgressChangedListener;

        public Reader(string fileName,
            OnTextLoadedListener onTextLoadedListener,
            OnProgressChangedListener onProgressChangedListener)
        {
            this.fileName = fileName;
            this.onTextLoadedListener = onTextLoadedListener;
            this.onProgressChangedListener = onProgressChangedListener;
        }

        public void readTextFromFile()
        {
            string text = "";
            Word.Application wordApp = new Word.Application();
            wordApp.Documents.Open(ref fileName);
            Word.Document wordDoc = wordApp.ActiveDocument;
            //Init progress bar on Form
            onProgressChangedListener.onProgressInitialized(wordDoc.Paragraphs.Count);
            foreach (Word.Paragraph paragraph in wordDoc.Paragraphs)
            {
                string line = paragraph.Range.Text;
                text = string.Concat(text, line);
                //Set new position on progress bar
                onProgressChangedListener.onProgressChanged();
            }
            onProgressChangedListener.onProgressCompleted("Текст загружен!");
            wordApp.Quit();
            onTextLoadedListener.onTextLoadingCompleted(text);
        }
    }

    public class Analyzer
    {
        private OnProgressChangedListener onProgressChangedListener;
        private OnWordsLoadedListener onWordsLoadedListener;
        private OnWordsCountedListener onWordsCountedListener;

        public Analyzer(OnProgressChangedListener onProgressChangedListener,
            OnWordsLoadedListener onWordsLoadedListener,
            OnWordsCountedListener onWordsCountedListener)
        {
            this.onProgressChangedListener = onProgressChangedListener;
            this.onWordsLoadedListener = onWordsLoadedListener;
            this.onWordsCountedListener = onWordsCountedListener;
        }

        public void getWordsFromText(object parameter)
        {
            string text = (string)parameter;
            List<string> words = new List<string>();
            char[] separator = { ' ', ',', '.', ':', '"', '\'', ';', '-', ')', '\\', '*', '%', '$', '@', 
                '(', '?', '!', '_', '\t', '\n', '\r', '<', '>', '/', '~', '#', '+', '—' };
            string[] splittedWords = text.Split(separator);
            //Init progress bar on Form
            onProgressChangedListener.onProgressInitialized(splittedWords.Length);
            foreach (string splittedWord in splittedWords)
            {
                string word = splittedWord.Trim();
                if (word.Length > 0 && !Int32.TryParse(word, out int res))
                {
                    words.Add(word);
                }
                // Set new position on progress bar
                onProgressChangedListener.onProgressChanged();
            }
            onWordsLoadedListener.onWordsLoadingCompleted(words);
        }

        public void getWordsCount(object parameter)
        {
            List<string> words = (List<string>)parameter;
            Dictionary<string, int> counts = new Dictionary<string, int>();
            //Init progress bar on Form
            onProgressChangedListener.onProgressInitialized(words.Count);
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
                onProgressChangedListener.onProgressChanged();
            }
            onWordsCountedListener.onWordsCountingCompleted(counts);
        }
    }
}
