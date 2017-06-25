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
        void onProgressInitialized(int max, int offset);
        void onProgressChanged(int position);
        void onProgressCompleted(string message);
    }

    public partial class TextAnalyzer : Form, OnProgressChangedListener
    {
        private string text;
        private List<string> words;
        private Analyzer analyzer;
        private Reader reader;

        public TextAnalyzer()
        {
            InitializeComponent();
        }

        private void TextAnalyzer_Load(object sender, EventArgs e)
        {
            analyzer = new Analyzer(this);
            reader = new Reader(this);
        }

        private void writeToListBox(List<string> items)
        {
            lb_words.Items.Clear();
            if (words.Count > 0)
            {
                lb_words.Items.Add("Всего: " + items.Count);
                foreach (string item in items)
                {
                    lb_words.Items.Add(item);
                }
            }
            else
            {
                lb_words.Items.Add("Элементы не найдены!");
            }
            
        }

        private void btn_words_Click(object sender, EventArgs e)
        {
            words = analyzer.getWordsFromText(text);
            writeToListBox(words);
            
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            text = reader.readTextFromFile();
            if (text.Length < 0)
            {
                lb_words.Items.Clear();
                lb_words.Items.Add("Ошибка чтения файла!");
            }
        }

        private void btn_count_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> counts = analyzer.getWordsCount(words);
            List<string> items = new List<string>();
            foreach (string key in counts.Keys)
            {
                items.Add(key + ": " + counts[key]);
            }
            writeToListBox(items);
        }

        public void onProgressInitialized(int max, int step)
        {
            pb_progress.Maximum = max;
            pb_progress.Step = step;
            pb_progress.Value = 0;
        }

        public void onProgressChanged(int offset)
        {
            pb_progress.Value = pb_progress.Value + offset * pb_progress.Step;
        }

        public void onProgressCompleted(string message)
        {
            lb_words.Items.Clear();
            lb_words.Items.Add(message);
        }
    }

}
