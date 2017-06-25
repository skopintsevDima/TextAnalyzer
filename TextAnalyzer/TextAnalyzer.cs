using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public interface OnProgressChangedListener
    {
        void onProgressInitialized(int max);
        void onProgressChanged();
        void onProgressCompleted(string message);
    }

    public partial class TextAnalyzer : Form, 
        OnProgressChangedListener, 
        OnTextLoadedListener,
        OnWordsLoadedListener,
        OnWordsCountedListener

    {
        private string text;
        private List<string> words;
        private Dictionary<string, int> counts;
        private Thread workerThread;
        private Analyzer analyzer;
        private Reader reader;

        private delegate void EmptyDelegate();

        public TextAnalyzer()
        {
            InitializeComponent();
        }

        private void TextAnalyzer_Load(object sender, EventArgs e)
        {
            analyzer = new Analyzer(this, this, this);
        }

        private void writeToListBox(List<string> items)
        {
            showMessage("Всего: " + items.Count);
            foreach (string item in items)
            {
                lb_words.Items.Add(item);
            }
        }

        private void btn_words_Click(object sender, EventArgs e)
        {
            showMessage("Идет поиск...");
            workerThread = new Thread(new ParameterizedThreadStart(analyzer.getWordsFromText));
            workerThread.Start(text);
        }

        private void btn_count_Click(object sender, EventArgs e)
        {
            showMessage("Идет подсчёт...");
            workerThread = new Thread(new ParameterizedThreadStart(analyzer.getWordsCount));
            workerThread.Start(words);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            btn_words.Enabled = false;
            btn_count.Enabled = false;
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.docx",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                showMessage("Загрузка...");
                reader = new Reader(dialog.FileName, this, this);
                workerThread = new Thread(reader.readTextFromFile);
                workerThread.Start();
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

        public void showMessage(string message)
        {
            lb_words.Invoke(new EmptyDelegate(() => 
            {
                lb_words.Items.Clear();
                lb_words.Items.Add(message);
            }));
        }

        public void onTextLoadingCompleted(string text)
        {
            this.text = text;
            btn_words.Enabled = true;
        }

        public void onProgressCompleted(string message)
        {
            pb_progress.Invoke(new EmptyDelegate(() =>
            {
                pb_progress.Value = pb_progress.Maximum;
            }));
            showMessage(message);
        }

        public void onWordsLoadingCompleted(List<string> words)
        {
            this.words = words;
            btn_count.Enabled = true;
            writeToListBox(words);
        }

        public void onWordsCountingCompleted(Dictionary<string, int> counts)
        {
            this.counts = counts;
            List<string> items = new List<string>();
            foreach (string key in counts.Keys)
            {
                items.Add(key + ": " + counts[key]);
            }
            writeToListBox(items);
        }
    }

}
