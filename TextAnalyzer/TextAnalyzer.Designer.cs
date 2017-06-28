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
            this.lb_words = new System.Windows.Forms.ListBox();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.ms_menu = new System.Windows.Forms.MenuStrip();
            this.mi_text = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_open = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_analysis = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_startAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_analysis = new System.Windows.Forms.GroupBox();
            this.gb_finding = new System.Windows.Forms.GroupBox();
            this.gb_sorting = new System.Windows.Forms.GroupBox();
            this.tb_wordToFind = new System.Windows.Forms.TextBox();
            this.btn_startFinding = new System.Windows.Forms.Button();
            this.rb_byCount = new System.Windows.Forms.RadioButton();
            this.rb_byAlphabet = new System.Windows.Forms.RadioButton();
            this.lbl_wordToFind = new System.Windows.Forms.Label();
            this.btn_resetFinding = new System.Windows.Forms.Button();
            this.num_showTop = new System.Windows.Forms.NumericUpDown();
            this.lbl_showTop = new System.Windows.Forms.Label();
            this.btn_showTop = new System.Windows.Forms.Button();
            this.ms_menu.SuspendLayout();
            this.gb_analysis.SuspendLayout();
            this.gb_finding.SuspendLayout();
            this.gb_sorting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_showTop)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_words
            // 
            this.lb_words.FormattingEnabled = true;
            this.lb_words.Location = new System.Drawing.Point(6, 19);
            this.lb_words.Name = "lb_words";
            this.lb_words.Size = new System.Drawing.Size(208, 277);
            this.lb_words.TabIndex = 3;
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(6, 301);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(208, 15);
            this.pb_progress.TabIndex = 5;
            // 
            // ms_menu
            // 
            this.ms_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_text,
            this.mi_analysis,
            this.помощьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.ms_menu.Location = new System.Drawing.Point(0, 0);
            this.ms_menu.Name = "ms_menu";
            this.ms_menu.Size = new System.Drawing.Size(484, 24);
            this.ms_menu.TabIndex = 6;
            this.ms_menu.Text = "menuStrip1";
            // 
            // mi_text
            // 
            this.mi_text.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_open});
            this.mi_text.Name = "mi_text";
            this.mi_text.Size = new System.Drawing.Size(49, 20);
            this.mi_text.Text = "Текст";
            // 
            // mi_open
            // 
            this.mi_open.Name = "mi_open";
            this.mi_open.Size = new System.Drawing.Size(153, 22);
            this.mi_open.Text = "Выбрать файл";
            this.mi_open.Click += new System.EventHandler(this.mi_open_Click);
            // 
            // mi_analysis
            // 
            this.mi_analysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_startAnalysis});
            this.mi_analysis.Enabled = false;
            this.mi_analysis.Name = "mi_analysis";
            this.mi_analysis.Size = new System.Drawing.Size(59, 20);
            this.mi_analysis.Text = "Анализ";
            // 
            // mi_startAnalysis
            // 
            this.mi_startAnalysis.Name = "mi_startAnalysis";
            this.mi_startAnalysis.Size = new System.Drawing.Size(152, 22);
            this.mi_startAnalysis.Text = "Начать";
            this.mi_startAnalysis.Click += new System.EventHandler(this.mi_startAnalysis_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // gb_analysis
            // 
            this.gb_analysis.Controls.Add(this.gb_finding);
            this.gb_analysis.Controls.Add(this.pb_progress);
            this.gb_analysis.Controls.Add(this.lb_words);
            this.gb_analysis.Location = new System.Drawing.Point(12, 27);
            this.gb_analysis.Name = "gb_analysis";
            this.gb_analysis.Size = new System.Drawing.Size(460, 322);
            this.gb_analysis.TabIndex = 7;
            this.gb_analysis.TabStop = false;
            this.gb_analysis.Text = "Анализ";
            // 
            // gb_finding
            // 
            this.gb_finding.Controls.Add(this.btn_showTop);
            this.gb_finding.Controls.Add(this.lbl_showTop);
            this.gb_finding.Controls.Add(this.num_showTop);
            this.gb_finding.Controls.Add(this.btn_resetFinding);
            this.gb_finding.Controls.Add(this.lbl_wordToFind);
            this.gb_finding.Controls.Add(this.gb_sorting);
            this.gb_finding.Controls.Add(this.tb_wordToFind);
            this.gb_finding.Controls.Add(this.btn_startFinding);
            this.gb_finding.Location = new System.Drawing.Point(230, 19);
            this.gb_finding.Name = "gb_finding";
            this.gb_finding.Size = new System.Drawing.Size(224, 297);
            this.gb_finding.TabIndex = 6;
            this.gb_finding.TabStop = false;
            this.gb_finding.Text = "Поиск";
            this.gb_finding.Visible = false;
            // 
            // gb_sorting
            // 
            this.gb_sorting.Controls.Add(this.rb_byCount);
            this.gb_sorting.Controls.Add(this.rb_byAlphabet);
            this.gb_sorting.Location = new System.Drawing.Point(6, 118);
            this.gb_sorting.Name = "gb_sorting";
            this.gb_sorting.Size = new System.Drawing.Size(209, 70);
            this.gb_sorting.TabIndex = 7;
            this.gb_sorting.TabStop = false;
            this.gb_sorting.Text = "Сортировать";
            // 
            // tb_wordToFind
            // 
            this.tb_wordToFind.Location = new System.Drawing.Point(6, 45);
            this.tb_wordToFind.Name = "tb_wordToFind";
            this.tb_wordToFind.Size = new System.Drawing.Size(209, 20);
            this.tb_wordToFind.TabIndex = 7;
            // 
            // btn_startFinding
            // 
            this.btn_startFinding.Location = new System.Drawing.Point(6, 71);
            this.btn_startFinding.Name = "btn_startFinding";
            this.btn_startFinding.Size = new System.Drawing.Size(75, 23);
            this.btn_startFinding.TabIndex = 0;
            this.btn_startFinding.Text = "Найти";
            this.btn_startFinding.UseVisualStyleBackColor = true;
            this.btn_startFinding.Click += new System.EventHandler(this.btn_startFinding_Click);
            // 
            // rb_byCount
            // 
            this.rb_byCount.AutoSize = true;
            this.rb_byCount.Location = new System.Drawing.Point(6, 19);
            this.rb_byCount.Name = "rb_byCount";
            this.rb_byCount.Size = new System.Drawing.Size(161, 17);
            this.rb_byCount.TabIndex = 8;
            this.rb_byCount.TabStop = true;
            this.rb_byCount.Text = "По количеству повторений";
            this.rb_byCount.UseVisualStyleBackColor = true;
            this.rb_byCount.CheckedChanged += new System.EventHandler(this.rb_byCount_CheckedChanged);
            // 
            // rb_byAlphabet
            // 
            this.rb_byAlphabet.AutoSize = true;
            this.rb_byAlphabet.Location = new System.Drawing.Point(6, 42);
            this.rb_byAlphabet.Name = "rb_byAlphabet";
            this.rb_byAlphabet.Size = new System.Drawing.Size(90, 17);
            this.rb_byAlphabet.TabIndex = 9;
            this.rb_byAlphabet.TabStop = true;
            this.rb_byAlphabet.Text = "По алфавиту";
            this.rb_byAlphabet.UseVisualStyleBackColor = true;
            this.rb_byAlphabet.CheckedChanged += new System.EventHandler(this.rb_byAlphabet_CheckedChanged);
            // 
            // lbl_wordToFind
            // 
            this.lbl_wordToFind.AutoSize = true;
            this.lbl_wordToFind.Location = new System.Drawing.Point(6, 27);
            this.lbl_wordToFind.Name = "lbl_wordToFind";
            this.lbl_wordToFind.Size = new System.Drawing.Size(44, 13);
            this.lbl_wordToFind.TabIndex = 8;
            this.lbl_wordToFind.Text = "Искать";
            // 
            // btn_resetFinding
            // 
            this.btn_resetFinding.Location = new System.Drawing.Point(140, 268);
            this.btn_resetFinding.Name = "btn_resetFinding";
            this.btn_resetFinding.Size = new System.Drawing.Size(75, 23);
            this.btn_resetFinding.TabIndex = 9;
            this.btn_resetFinding.Text = "Сброс";
            this.btn_resetFinding.UseVisualStyleBackColor = true;
            this.btn_resetFinding.Click += new System.EventHandler(this.btn_resetFinding_Click);
            // 
            // num_showTop
            // 
            this.num_showTop.Location = new System.Drawing.Point(88, 198);
            this.num_showTop.Name = "num_showTop";
            this.num_showTop.Size = new System.Drawing.Size(57, 20);
            this.num_showTop.TabIndex = 8;
            // 
            // lbl_showTop
            // 
            this.lbl_showTop.AutoSize = true;
            this.lbl_showTop.Location = new System.Drawing.Point(6, 200);
            this.lbl_showTop.Name = "lbl_showTop";
            this.lbl_showTop.Size = new System.Drawing.Size(76, 13);
            this.lbl_showTop.TabIndex = 10;
            this.lbl_showTop.Text = "Показать топ";
            // 
            // btn_showTop
            // 
            this.btn_showTop.Location = new System.Drawing.Point(6, 216);
            this.btn_showTop.Name = "btn_showTop";
            this.btn_showTop.Size = new System.Drawing.Size(75, 23);
            this.btn_showTop.TabIndex = 11;
            this.btn_showTop.Text = "Показать";
            this.btn_showTop.UseVisualStyleBackColor = true;
            this.btn_showTop.Click += new System.EventHandler(this.btn_showTop_Click);
            // 
            // TextAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.gb_analysis);
            this.Controls.Add(this.ms_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.ms_menu;
            this.Name = "TextAnalyzer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Синтаксический анализатор";
            this.Load += new System.EventHandler(this.TextAnalyzer_Load);
            this.ms_menu.ResumeLayout(false);
            this.ms_menu.PerformLayout();
            this.gb_analysis.ResumeLayout(false);
            this.gb_finding.ResumeLayout(false);
            this.gb_finding.PerformLayout();
            this.gb_sorting.ResumeLayout(false);
            this.gb_sorting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_showTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lb_words;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.MenuStrip ms_menu;
        private System.Windows.Forms.ToolStripMenuItem mi_text;
        private System.Windows.Forms.ToolStripMenuItem mi_open;
        private System.Windows.Forms.ToolStripMenuItem mi_analysis;
        private System.Windows.Forms.GroupBox gb_analysis;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_startAnalysis;
        private System.Windows.Forms.GroupBox gb_finding;
        private System.Windows.Forms.TextBox tb_wordToFind;
        private System.Windows.Forms.Button btn_startFinding;
        private System.Windows.Forms.GroupBox gb_sorting;
        private System.Windows.Forms.RadioButton rb_byCount;
        private System.Windows.Forms.RadioButton rb_byAlphabet;
        private System.Windows.Forms.Label lbl_wordToFind;
        private System.Windows.Forms.Button btn_resetFinding;
        private System.Windows.Forms.Button btn_showTop;
        private System.Windows.Forms.Label lbl_showTop;
        private System.Windows.Forms.NumericUpDown num_showTop;
    }
}

