using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public partial class TextAnalyzer : Form
    {
        private string text;
        private List<string> words;

        public TextAnalyzer()
        {
            InitializeComponent();
        }

        private void TextAnalyzer_Load(object sender, EventArgs e)
        {

        }

        private void writeToListBox(List<string> items)
        {
            lb_words.Items.Clear();
            if (words.Count > 0)
            {
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
            words = Analyzer.getWordsFromText(text);
            writeToListBox(words);
            
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            text = Reader.readTextFromFile();
            lb_words.Items.Clear();
            if (text.Length > 0)
            {
                lb_words.Items.Add("Текст загружен!");
            }
            else
            {
                lb_words.Items.Add("Ошибка чтения файла!");
            }
        }

        private void btn_count_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> counts = Analyzer.getWordsCount(words);
            List<string> items = new List<string>();
            foreach (string key in counts.Keys)
            {
                items.Add(key + ": " + counts[key]);
            }
            writeToListBox(items);
        }
    }

}
