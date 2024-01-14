namespace University.Puzzle.UI
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dataGridViewGames = new System.Windows.Forms.DataGridView();
            this.Navigation = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxScoreMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.dataGridViewRecord = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPageSaves = new System.Windows.Forms.TabPage();
            this.buttonDeleteSave = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.dataGridViewSaves = new System.Windows.Forms.DataGridView();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).BeginInit();
            this.Navigation.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPageSaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaves)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.buttonPlay);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.dataGridViewGames);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1147, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Игры";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 420);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 39);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBoxGameHelp_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlay.Location = new System.Drawing.Point(888, 419);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(196, 42);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "Играть";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.ButttonPlay_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(638, 420);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(140, 37);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "На очки";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(291, 420);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(162, 37);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "На время";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewGames
            // 
            this.dataGridViewGames.AllowUserToAddRows = false;
            this.dataGridViewGames.AllowUserToDeleteRows = false;
            this.dataGridViewGames.AllowUserToResizeColumns = false;
            this.dataGridViewGames.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewGames.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGames.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGames.Location = new System.Drawing.Point(4, 0);
            this.dataGridViewGames.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewGames.MultiSelect = false;
            this.dataGridViewGames.Name = "dataGridViewGames";
            this.dataGridViewGames.ReadOnly = true;
            this.dataGridViewGames.RowHeadersVisible = false;
            this.dataGridViewGames.RowHeadersWidth = 49;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewGames.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewGames.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewGames.RowTemplate.Height = 30;
            this.dataGridViewGames.Size = new System.Drawing.Size(1525, 394);
            this.dataGridViewGames.TabIndex = 0;
            this.dataGridViewGames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGames_CellClick);
            // 
            // Navigation
            // 
            this.Navigation.Controls.Add(this.tabPage1);
            this.Navigation.Controls.Add(this.tabPage2);
            this.Navigation.Controls.Add(this.tabPageSaves);
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Navigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Navigation.ItemSize = new System.Drawing.Size(431, 40);
            this.Navigation.Location = new System.Drawing.Point(0, 0);
            this.Navigation.Margin = new System.Windows.Forms.Padding(4);
            this.Navigation.Name = "Navigation";
            this.Navigation.Padding = new System.Drawing.Point(50, 5);
            this.Navigation.SelectedIndex = 0;
            this.Navigation.Size = new System.Drawing.Size(1155, 527);
            this.Navigation.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Navigation.TabIndex = 1;
            this.Navigation.SelectedIndexChanged += new System.EventHandler(this.Navigation_SelectedIndexChanged);
            this.Navigation.Selected += new System.Windows.Forms.TabControlEventHandler(this.Navigation_Selected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxScoreMode);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboBoxDifficulty);
            this.tabPage2.Controls.Add(this.dataGridViewRecord);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1147, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Рейтинг";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxScoreMode
            // 
            this.comboBoxScoreMode.AutoCompleteCustomSource.AddRange(new string[] {
            "Лёгкий",
            "Средний",
            "Сложный"});
            this.comboBoxScoreMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScoreMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxScoreMode.FormattingEnabled = true;
            this.comboBoxScoreMode.Items.AddRange(new object[] {
            "На очки",
            "На время"});
            this.comboBoxScoreMode.Location = new System.Drawing.Point(840, 405);
            this.comboBoxScoreMode.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxScoreMode.Name = "comboBoxScoreMode";
            this.comboBoxScoreMode.Size = new System.Drawing.Size(243, 32);
            this.comboBoxScoreMode.TabIndex = 8;
            this.comboBoxScoreMode.SelectedValueChanged += new System.EventHandler(this.comboBoxScoreMode_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(835, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Тип подсчёта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(408, 361);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сложность";
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.comboBoxDifficulty.AutoCompleteCustomSource.AddRange(new string[] {
            "Лёгкий",
            "Средний",
            "Сложный"});
            this.comboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Items.AddRange(new object[] {
            "Лёгкий",
            "Средний",
            "Сложный"});
            this.comboBoxDifficulty.Location = new System.Drawing.Point(413, 405);
            this.comboBoxDifficulty.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(243, 32);
            this.comboBoxDifficulty.TabIndex = 4;
            this.comboBoxDifficulty.SelectedValueChanged += new System.EventHandler(this.comboBoxDifficulty_SelectedValueChanged);
            // 
            // dataGridViewRecord
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRecord.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecord.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRecord.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewRecord.MultiSelect = false;
            this.dataGridViewRecord.Name = "dataGridViewRecord";
            this.dataGridViewRecord.ReadOnly = true;
            this.dataGridViewRecord.RowHeadersVisible = false;
            this.dataGridViewRecord.RowHeadersWidth = 49;
            this.dataGridViewRecord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewRecord.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewRecord.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRecord.Size = new System.Drawing.Size(1142, 341);
            this.dataGridViewRecord.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(73, 382);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 39);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBoxRecordHelp_Click);
            // 
            // tabPageSaves
            // 
            this.tabPageSaves.Controls.Add(this.buttonDeleteSave);
            this.tabPageSaves.Controls.Add(this.buttonContinue);
            this.tabPageSaves.Controls.Add(this.dataGridViewSaves);
            this.tabPageSaves.Location = new System.Drawing.Point(4, 44);
            this.tabPageSaves.Name = "tabPageSaves";
            this.tabPageSaves.Size = new System.Drawing.Size(1147, 479);
            this.tabPageSaves.TabIndex = 2;
            this.tabPageSaves.Text = "Сохранения";
            this.tabPageSaves.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteSave
            // 
            this.buttonDeleteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteSave.Location = new System.Drawing.Point(715, 415);
            this.buttonDeleteSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteSave.Name = "buttonDeleteSave";
            this.buttonDeleteSave.Size = new System.Drawing.Size(196, 42);
            this.buttonDeleteSave.TabIndex = 9;
            this.buttonDeleteSave.Text = "Удалить";
            this.buttonDeleteSave.UseVisualStyleBackColor = true;
            this.buttonDeleteSave.Click += new System.EventHandler(this.ButtonDeleteSave_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonContinue.Location = new System.Drawing.Point(929, 415);
            this.buttonContinue.Margin = new System.Windows.Forms.Padding(4);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(196, 42);
            this.buttonContinue.TabIndex = 8;
            this.buttonContinue.Text = "Продолжить";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // dataGridViewSaves
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewSaves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewSaves.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSaves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaves.Location = new System.Drawing.Point(5, 0);
            this.dataGridViewSaves.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewSaves.MultiSelect = false;
            this.dataGridViewSaves.Name = "dataGridViewSaves";
            this.dataGridViewSaves.ReadOnly = true;
            this.dataGridViewSaves.RowHeadersVisible = false;
            this.dataGridViewSaves.RowHeadersWidth = 49;
            this.dataGridViewSaves.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewSaves.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewSaves.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewSaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSaves.Size = new System.Drawing.Size(1142, 384);
            this.dataGridViewSaves.TabIndex = 2;
            this.dataGridViewSaves.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSaves_CellClick);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 527);
            this.Controls.Add(this.Navigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GamerForm_FormClosing);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).EndInit();
            this.Navigation.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPageSaves.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewGames;
        private System.Windows.Forms.TabControl Navigation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewRecord;
        private System.Windows.Forms.Button Reference;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
        private System.Windows.Forms.ComboBox comboBoxScoreMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabPageSaves;
        private System.Windows.Forms.DataGridView dataGridViewSaves;
        private System.Windows.Forms.Button buttonDeleteSave;
        private System.Windows.Forms.Button buttonContinue;
    }
}