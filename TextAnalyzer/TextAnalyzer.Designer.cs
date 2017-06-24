namespace TextAnalyzer
{
    partial class TextAnalyzer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_words = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.lb_words = new System.Windows.Forms.ListBox();
            this.btn_count = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_words
            // 
            this.btn_words.Location = new System.Drawing.Point(362, 41);
            this.btn_words.Name = "btn_words";
            this.btn_words.Size = new System.Drawing.Size(110, 23);
            this.btn_words.TabIndex = 0;
            this.btn_words.Text = "Показать слова";
            this.btn_words.UseVisualStyleBackColor = true;
            this.btn_words.Click += new System.EventHandler(this.btn_words_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(362, 12);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(110, 23);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "Выбрать текст";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lb_words
            // 
            this.lb_words.FormattingEnabled = true;
            this.lb_words.Location = new System.Drawing.Point(12, 7);
            this.lb_words.Name = "lb_words";
            this.lb_words.Size = new System.Drawing.Size(194, 342);
            this.lb_words.TabIndex = 3;
            // 
            // btn_count
            // 
            this.btn_count.Location = new System.Drawing.Point(362, 70);
            this.btn_count.Name = "btn_count";
            this.btn_count.Size = new System.Drawing.Size(110, 23);
            this.btn_count.TabIndex = 4;
            this.btn_count.Text = "Подсчитать слова";
            this.btn_count.UseVisualStyleBackColor = true;
            this.btn_count.Click += new System.EventHandler(this.btn_count_Click);
            // 
            // TextAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btn_count);
            this.Controls.Add(this.lb_words);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_words);
            this.Name = "TextAnalyzer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextAnalyzer";
            this.Load += new System.EventHandler(this.TextAnalyzer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_words;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ListBox lb_words;
        private System.Windows.Forms.Button btn_count;
    }
}

