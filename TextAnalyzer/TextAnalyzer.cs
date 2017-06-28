using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public interface OnProgressChangedListener
    {
        void onProgressInitialized(int max);
        void onProgressChanged();
        void onProgressCompleted();
    }

    public partial class TextAnalyzer : Form,
        OnProgressChangedListener,
        OnTextLoadedListener,
        OnWordsFoundListener,
        OnWordsCountedListener

    {
        private string fileName;
        private string text;
        private List<string> words;
        private Dictionary<string, int> counts;
        private List<string> wordsWithCounts;
        private Thread workerThread;
        private Analyzer analyzer;
        private Reader reader;
        private const int TTS = 1000;

        private delegate void EmptyDelegate();

        public TextAnalyzer()
        {
            InitializeComponent();
        }

        private void TextAnalyzer_Load(object sender, EventArgs e)
        {
            analyzer = new Analyzer(this, this, this);
        }

        public void showMessage(string message)
        {
            Invoke(new EmptyDelegate(() =>
            {
                lb_words.Items.Clear();
                lb_words.Items.Add(message);
            }));
        }

        private void writeToListBox(List<string> items)
        {
            new Thread(new ThreadStart(() =>
            {
                onProgressInitialized(items.Count);
                showMessage("Всего слов: " + items.Count);
                foreach (string item in items)
                {
                    Invoke(new EmptyDelegate(() =>
                    {
                        lb_words.Items.Add(item);
                    }));
                    onProgressChanged();
                }
                onProgressCompleted();
            })).Start();
        }

        private void countSameWords()
        {
            showMessage("Идет подсчёт слов...");
            workerThread = new Thread(new ParameterizedThreadStart(analyzer.getWordsCount));
            workerThread.Start(words);
        }

        private void findWordsInText()
        {
            showMessage("Идет поиск слов...");
            workerThread = new Thread(new ParameterizedThreadStart(analyzer.getWordsFromText));
            workerThread.Start(text);
        }

        private void loadText()
        {
            reader = new Reader(fileName, this, this);
            showMessage("Загрузка текста...");
            workerThread = new Thread(reader.readTextFromFile);
            workerThread.Start();
        }

        private void openFile()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.docx",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mi_analysis.Enabled = true;
                gb_finding.Visible = false;
                fileName = dialog.FileName;
                showMessage("Файл выбран!");
            }
            else
            {
                showMessage("Файл не выбран!");
            }
        }

        public void onProgressInitialized(int max)
        {
            pb_progress.Invoke(new EmptyDelegate(() => 
            {
                pb_progress.Maximum = max;
                pb_progress.Value = 0;
            }));
        }

        public void onProgressChanged()
        {
            pb_progress.Invoke(new EmptyDelegate(() => 
            {
                pb_progress.Value++;
            }));
        }

        public void onProgressCompleted()
        {
            pb_progress.Invoke(new EmptyDelegate(() =>
            {
                pb_progress.Value = pb_progress.Maximum;
            }));
        }

        public void onTextLoadingCompleted(string text)
        {
            Invoke(new EmptyDelegate(() =>
            {
                this.text = text;
                showMessage("Текст загружен!");
            }));
            Thread.Sleep(TTS);
            findWordsInText();
        }

        public void onWordsFindingCompleted(List<string> words)
        {
            Invoke(new EmptyDelegate(() =>
            {
                this.words = words;
                showMessage("Поиск слов завершен!");
            }));
            Thread.Sleep(TTS);
            countSameWords();
        }

        public void onWordsCountingCompleted(Dictionary<string, int> counts)
        {
            Invoke(new EmptyDelegate(() => 
            {
                gb_finding.Visible = true;
                this.counts = counts;
                wordsWithCounts = new List<string>();
                foreach (string key in counts.Keys)
                {
                    wordsWithCounts.Add(key + ": " + counts[key]);
                }
            }));
            showMessage("Подсчёт слов завершен!");
            Thread.Sleep(TTS);
            writeToListBox(wordsWithCounts);
        }

        private void mi_open_Click(object sender, EventArgs e)
        {
            mi_analysis.Enabled = false;
            openFile();
        }

        private void mi_startAnalysis_Click(object sender, EventArgs e)
        {
            gb_finding.Visible = false;
            loadText();
        }

        private List<string> sortItemsByAlphabet(List<string> items)
        {
            items.Sort((s1, s2) =>
            {
                return s1.CompareTo(s2);
            });
            return items;
        }

        private Dictionary<string, int> sortItemsByCount(Dictionary<string, int> items)
        {
            return items.OrderByDescending(pair => pair.Value).Take(items.Count)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private List<string> getItemsFromListBox()
        {
            List<string> items = new List<string>();
            if (lb_words.Items.Count > 1)
            {
                for (int i = 1; i < lb_words.Items.Count; i++)
                    items.Add((string)lb_words.Items[i]);
            }   
            return items;
        }

        private void rb_byCount_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_byCount.Checked)
            {
                List<string> items = getItemsFromListBox();
                Dictionary<string, int> itemsWithCount = new Dictionary<string, int>();
                foreach (string item in items)
                {
                    string pattern = @"\w+";
                    Match match = Regex.Match(item, pattern);
                    string word = match.Value;
                    string count = match.NextMatch().Value;
                    itemsWithCount.Add(word, Convert.ToInt32(count));
                }
                itemsWithCount = sortItemsByCount(itemsWithCount);
                items = new List<string>();
                foreach (string key in itemsWithCount.Keys)
                {
                    items.Add(key + ": " + counts[key]);
                }
                writeToListBox(items);
            }
        }

        private void rb_byAlphabet_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_byAlphabet.Checked)
            {
                List<string> items = getItemsFromListBox();
                items = sortItemsByAlphabet(items);
                writeToListBox(items);
            }
        }

        private void btn_startFinding_Click(object sender, EventArgs e)
        {
            string subword = tb_wordToFind.Text;
            if (subword.Length > 0)
            {
                workerThread = new Thread(new ThreadStart(() => 
                {
                    onProgressInitialized(wordsWithCounts.Count);
                    showMessage("Поиск...");
                    List<string> items = new List<string>();
                    foreach (string word in wordsWithCounts)
                    {
                        if (Regex.Match(word, subword, RegexOptions.IgnoreCase).Success)
                        {
                            items.Add(word);
                        }
                        onProgressChanged();
                    }
                    onFindingCompleted(items);
                }));
                workerThread.Start();
            }
        }

        private void onFindingCompleted(List<string> items)
        {
            showMessage("Поиск завершён!");
            Thread.Sleep(TTS);
            onProgressCompleted();
            writeToListBox(items);
        }

        private void btn_resetFinding_Click(object sender, EventArgs e)
        {
            writeToListBox(wordsWithCounts);
        }

        private void btn_showTop_Click(object sender, EventArgs e)
        {

        }
    }

}
