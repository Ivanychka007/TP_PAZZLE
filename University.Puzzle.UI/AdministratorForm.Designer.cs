namespace University.Puzzle.UI
{
    partial class AdministratorForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlNavigation = new System.Windows.Forms.TabControl();
            this.tabPageGames = new System.Windows.Forms.TabPage();
            this.DeleteGame = new System.Windows.Forms.Button();
            this.dataGridViewGames = new System.Windows.Forms.DataGridView();
            this.tabPageGameCreation = new System.Windows.Forms.TabPage();
            this.buttonMixImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxGameName = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBoxDifficulty = new System.Windows.Forms.TextBox();
            this.buttonSelectDifficulty = new System.Windows.Forms.Button();
            this.buttonCreateGame = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.textBoxSelectedImage = new System.Windows.Forms.TextBox();
            this.tabPageDifficultyCreation = new System.Windows.Forms.TabPage();
            this.dataGridViewDifficulty = new System.Windows.Forms.DataGridView();
            this.buttonAddDifficulty = new System.Windows.Forms.Button();
            this.buttonDeleteDifficulty = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxFigure = new System.Windows.Forms.CheckBox();
            this.checkBoxSquare = new System.Windows.Forms.CheckBox();
            this.checkBoxTriangle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxOnHeap = new System.Windows.Forms.CheckBox();
            this.checkBoxOnLine = new System.Windows.Forms.CheckBox();
            this.checkBoxOnField = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownVerticalPieces = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHorizontalPieces = new System.Windows.Forms.NumericUpDown();
            this.Height = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.tabPageGallery = new System.Windows.Forms.TabPage();
            this.textBoxImageName = new System.Windows.Forms.TextBox();
            this.buttonDeleteImage = new System.Windows.Forms.Button();
            this.buttonAddImage = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PictureBoxDisplayImage = new System.Windows.Forms.PictureBox();
            this.listBoxImages = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlNavigation.SuspendLayout();
            this.tabPageGames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).BeginInit();
            this.tabPageGameCreation.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageDifficultyCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDifficulty)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVerticalPieces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorizontalPieces)).BeginInit();
            this.tabPageGallery.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDisplayImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlNavigation
            // 
            this.tabControlNavigation.Controls.Add(this.tabPageGames);
            this.tabControlNavigation.Controls.Add(this.tabPageGameCreation);
            this.tabControlNavigation.Controls.Add(this.tabPageDifficultyCreation);
            this.tabControlNavigation.Controls.Add(this.tabPageGallery);
            this.tabControlNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlNavigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlNavigation.ItemSize = new System.Drawing.Size(264, 40);
            this.tabControlNavigation.Location = new System.Drawing.Point(0, 0);
            this.tabControlNavigation.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlNavigation.Name = "tabControlNavigation";
            this.tabControlNavigation.Padding = new System.Drawing.Point(50, 5);
            this.tabControlNavigation.SelectedIndex = 0;
            this.tabControlNavigation.Size = new System.Drawing.Size(1044, 513);
            this.tabControlNavigation.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlNavigation.TabIndex = 0;
            this.tabControlNavigation.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlNavigation_Selected);
            // 
            // tabPageGames
            // 
            this.tabPageGames.Controls.Add(this.DeleteGame);
            this.tabPageGames.Controls.Add(this.dataGridViewGames);
            this.tabPageGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageGames.Location = new System.Drawing.Point(4, 44);
            this.tabPageGames.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageGames.Name = "tabPageGames";
            this.tabPageGames.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageGames.Size = new System.Drawing.Size(1036, 465);
            this.tabPageGames.TabIndex = 0;
            this.tabPageGames.Text = "Игры";
            this.tabPageGames.UseVisualStyleBackColor = true;
            // 
            // DeleteGame
            // 
            this.DeleteGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteGame.Location = new System.Drawing.Point(815, 399);
            this.DeleteGame.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteGame.Name = "DeleteGame";
            this.DeleteGame.Size = new System.Drawing.Size(196, 42);
            this.DeleteGame.TabIndex = 1;
            this.DeleteGame.Text = "Удалить игру";
            this.DeleteGame.UseVisualStyleBackColor = true;
            this.DeleteGame.Click += new System.EventHandler(this.DeleteGame_Click);
            // 
            // dataGridViewGames
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewGames.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGames.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGames.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGames.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewGames.Name = "dataGridViewGames";
            this.dataGridViewGames.ReadOnly = true;
            this.dataGridViewGames.RowHeadersVisible = false;
            this.dataGridViewGames.RowHeadersWidth = 60;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewGames.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewGames.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewGames.Size = new System.Drawing.Size(1028, 391);
            this.dataGridViewGames.TabIndex = 0;
            this.dataGridViewGames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGames_CellClick);
            // 
            // tabPageGameCreation
            // 
            this.tabPageGameCreation.Controls.Add(this.buttonMixImage);
            this.tabPageGameCreation.Controls.Add(this.panel1);
            this.tabPageGameCreation.Controls.Add(this.groupBox6);
            this.tabPageGameCreation.Controls.Add(this.groupBox7);
            this.tabPageGameCreation.Controls.Add(this.buttonCreateGame);
            this.tabPageGameCreation.Controls.Add(this.groupBox4);
            this.tabPageGameCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageGameCreation.Location = new System.Drawing.Point(4, 44);
            this.tabPageGameCreation.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageGameCreation.Name = "tabPageGameCreation";
            this.tabPageGameCreation.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageGameCreation.Size = new System.Drawing.Size(1036, 465);
            this.tabPageGameCreation.TabIndex = 1;
            this.tabPageGameCreation.Text = "Создать игру";
            this.tabPageGameCreation.UseVisualStyleBackColor = true;
            // 
            // buttonMixImage
            // 
            this.buttonMixImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMixImage.Location = new System.Drawing.Point(379, 404);
            this.buttonMixImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMixImage.Name = "buttonMixImage";
            this.buttonMixImage.Size = new System.Drawing.Size(196, 43);
            this.buttonMixImage.TabIndex = 17;
            this.buttonMixImage.Text = "Перемещать";
            this.buttonMixImage.UseVisualStyleBackColor = true;
            this.buttonMixImage.Visible = false;
            this.buttonMixImage.Click += new System.EventHandler(this.ButtonMixImage_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(363, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 375);
            this.panel1.TabIndex = 16;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxGameName);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(9, 7);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(345, 95);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Название игры";
            // 
            // textBoxGameName
            // 
            this.textBoxGameName.Location = new System.Drawing.Point(25, 46);
            this.textBoxGameName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGameName.Name = "textBoxGameName";
            this.textBoxGameName.Size = new System.Drawing.Size(296, 37);
            this.textBoxGameName.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBoxDifficulty);
            this.groupBox7.Controls.Add(this.buttonSelectDifficulty);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.Location = new System.Drawing.Point(9, 256);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(345, 160);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Сложность";
            // 
            // textBoxDifficulty
            // 
            this.textBoxDifficulty.Location = new System.Drawing.Point(11, 59);
            this.textBoxDifficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDifficulty.Name = "textBoxDifficulty";
            this.textBoxDifficulty.ReadOnly = true;
            this.textBoxDifficulty.Size = new System.Drawing.Size(311, 37);
            this.textBoxDifficulty.TabIndex = 1;
            this.textBoxDifficulty.Text = "Сложность не выбрана";
            // 
            // buttonSelectDifficulty
            // 
            this.buttonSelectDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectDifficulty.Location = new System.Drawing.Point(11, 103);
            this.buttonSelectDifficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectDifficulty.Name = "buttonSelectDifficulty";
            this.buttonSelectDifficulty.Size = new System.Drawing.Size(295, 42);
            this.buttonSelectDifficulty.TabIndex = 0;
            this.buttonSelectDifficulty.Text = "Выбрать сложность";
            this.buttonSelectDifficulty.UseVisualStyleBackColor = true;
            this.buttonSelectDifficulty.Click += new System.EventHandler(this.ButtonSelectDifficulty_Click);
            // 
            // buttonCreateGame
            // 
            this.buttonCreateGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateGame.Location = new System.Drawing.Point(827, 404);
            this.buttonCreateGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateGame.Name = "buttonCreateGame";
            this.buttonCreateGame.Size = new System.Drawing.Size(196, 43);
            this.buttonCreateGame.TabIndex = 13;
            this.buttonCreateGame.Text = "Создать игру";
            this.buttonCreateGame.UseVisualStyleBackColor = true;
            this.buttonCreateGame.Click += new System.EventHandler(this.ButtonCreateGame_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSelectImage);
            this.groupBox4.Controls.Add(this.textBoxSelectedImage);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(9, 108);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(345, 142);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Изображение";
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectImage.Location = new System.Drawing.Point(8, 89);
            this.buttonSelectImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(295, 42);
            this.buttonSelectImage.TabIndex = 11;
            this.buttonSelectImage.Text = "Выбрать картинку";
            this.buttonSelectImage.UseVisualStyleBackColor = true;
            this.buttonSelectImage.Click += new System.EventHandler(this.ButtonSelectImage_Click);
            // 
            // textBoxSelectedImage
            // 
            this.textBoxSelectedImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSelectedImage.Location = new System.Drawing.Point(11, 48);
            this.textBoxSelectedImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSelectedImage.Name = "textBoxSelectedImage";
            this.textBoxSelectedImage.ReadOnly = true;
            this.textBoxSelectedImage.Size = new System.Drawing.Size(311, 32);
            this.textBoxSelectedImage.TabIndex = 14;
            this.textBoxSelectedImage.Text = "Изображение не выбрано";
            // 
            // tabPageDifficultyCreation
            // 
            this.tabPageDifficultyCreation.Controls.Add(this.dataGridViewDifficulty);
            this.tabPageDifficultyCreation.Controls.Add(this.buttonAddDifficulty);
            this.tabPageDifficultyCreation.Controls.Add(this.buttonDeleteDifficulty);
            this.tabPageDifficultyCreation.Controls.Add(this.groupBox3);
            this.tabPageDifficultyCreation.Controls.Add(this.groupBox2);
            this.tabPageDifficultyCreation.Controls.Add(this.groupBox1);
            this.tabPageDifficultyCreation.Location = new System.Drawing.Point(4, 44);
            this.tabPageDifficultyCreation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDifficultyCreation.Name = "tabPageDifficultyCreation";
            this.tabPageDifficultyCreation.Size = new System.Drawing.Size(1036, 465);
            this.tabPageDifficultyCreation.TabIndex = 3;
            this.tabPageDifficultyCreation.Text = "Сложность";
            this.tabPageDifficultyCreation.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDifficulty
            // 
            this.dataGridViewDifficulty.AllowUserToAddRows = false;
            this.dataGridViewDifficulty.AllowUserToDeleteRows = false;
            this.dataGridViewDifficulty.AllowUserToResizeColumns = false;
            this.dataGridViewDifficulty.AllowUserToResizeRows = false;
            this.dataGridViewDifficulty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDifficulty.Location = new System.Drawing.Point(8, 16);
            this.dataGridViewDifficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDifficulty.MultiSelect = false;
            this.dataGridViewDifficulty.Name = "dataGridViewDifficulty";
            this.dataGridViewDifficulty.ReadOnly = true;
            this.dataGridViewDifficulty.RowHeadersVisible = false;
            this.dataGridViewDifficulty.RowHeadersWidth = 49;
            this.dataGridViewDifficulty.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDifficulty.RowTemplate.Height = 36;
            this.dataGridViewDifficulty.RowTemplate.ReadOnly = true;
            this.dataGridViewDifficulty.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDifficulty.Size = new System.Drawing.Size(672, 213);
            this.dataGridViewDifficulty.TabIndex = 24;
            this.dataGridViewDifficulty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDifficulty_CellClick);
            this.dataGridViewDifficulty.DoubleClick += new System.EventHandler(this.DataGridViewDifficulty_DoubleClick);
            // 
            // buttonAddDifficulty
            // 
            this.buttonAddDifficulty.Location = new System.Drawing.Point(649, 263);
            this.buttonAddDifficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddDifficulty.Name = "buttonAddDifficulty";
            this.buttonAddDifficulty.Size = new System.Drawing.Size(163, 64);
            this.buttonAddDifficulty.TabIndex = 23;
            this.buttonAddDifficulty.Text = "Добавить";
            this.buttonAddDifficulty.UseVisualStyleBackColor = true;
            this.buttonAddDifficulty.Click += new System.EventHandler(this.ButtonAddDifficulty_Click);
            // 
            // buttonDeleteDifficulty
            // 
            this.buttonDeleteDifficulty.Location = new System.Drawing.Point(839, 263);
            this.buttonDeleteDifficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteDifficulty.Name = "buttonDeleteDifficulty";
            this.buttonDeleteDifficulty.Size = new System.Drawing.Size(163, 64);
            this.buttonDeleteDifficulty.TabIndex = 22;
            this.buttonDeleteDifficulty.Text = "Удалить";
            this.buttonDeleteDifficulty.UseVisualStyleBackColor = true;
            this.buttonDeleteDifficulty.Click += new System.EventHandler(this.ButtonDeleteDifficulty_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox3.Controls.Add(this.checkBoxFigure);
            this.groupBox3.Controls.Add(this.checkBoxSquare);
            this.groupBox3.Controls.Add(this.checkBoxTriangle);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(716, 34);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(285, 217);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вид фрагмента";
            // 
            // checkBoxFigure
            // 
            this.checkBoxFigure.AutoSize = true;
            this.checkBoxFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFigure.Location = new System.Drawing.Point(29, 121);
            this.checkBoxFigure.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxFigure.Name = "checkBoxFigure";
            this.checkBoxFigure.Size = new System.Drawing.Size(237, 34);
            this.checkBoxFigure.TabIndex = 7;
            this.checkBoxFigure.Text = "Фигурная форма";
            this.checkBoxFigure.UseVisualStyleBackColor = true;
            this.checkBoxFigure.Click += new System.EventHandler(this.CheckBoxFigure_Click);
            // 
            // checkBoxSquare
            // 
            this.checkBoxSquare.AutoSize = true;
            this.checkBoxSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSquare.Location = new System.Drawing.Point(29, 79);
            this.checkBoxSquare.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSquare.Name = "checkBoxSquare";
            this.checkBoxSquare.Size = new System.Drawing.Size(132, 34);
            this.checkBoxSquare.TabIndex = 6;
            this.checkBoxSquare.Text = "Квадрат";
            this.checkBoxSquare.UseVisualStyleBackColor = true;
            this.checkBoxSquare.Click += new System.EventHandler(this.CheckBoxSquare_Click);
            // 
            // checkBoxTriangle
            // 
            this.checkBoxTriangle.AutoSize = true;
            this.checkBoxTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxTriangle.Location = new System.Drawing.Point(29, 37);
            this.checkBoxTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTriangle.Name = "checkBoxTriangle";
            this.checkBoxTriangle.Size = new System.Drawing.Size(184, 34);
            this.checkBoxTriangle.TabIndex = 5;
            this.checkBoxTriangle.Text = "Треугольник";
            this.checkBoxTriangle.UseVisualStyleBackColor = true;
            this.checkBoxTriangle.Click += new System.EventHandler(this.CheckBoxTriangle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.checkBoxOnHeap);
            this.groupBox2.Controls.Add(this.checkBoxOnLine);
            this.groupBox2.Controls.Add(this.checkBoxOnField);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(44, 236);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(216, 181);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип сборки";
            // 
            // checkBoxOnHeap
            // 
            this.checkBoxOnHeap.AutoSize = true;
            this.checkBoxOnHeap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxOnHeap.Location = new System.Drawing.Point(21, 79);
            this.checkBoxOnHeap.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxOnHeap.Name = "checkBoxOnHeap";
            this.checkBoxOnHeap.Size = new System.Drawing.Size(110, 34);
            this.checkBoxOnHeap.TabIndex = 7;
            this.checkBoxOnHeap.Text = "В куче";
            this.checkBoxOnHeap.UseVisualStyleBackColor = true;
            this.checkBoxOnHeap.Click += new System.EventHandler(this.CheckBoxOnHeap_Click);
            // 
            // checkBoxOnLine
            // 
            this.checkBoxOnLine.AutoSize = true;
            this.checkBoxOnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxOnLine.Location = new System.Drawing.Point(21, 122);
            this.checkBoxOnLine.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxOnLine.Name = "checkBoxOnLine";
            this.checkBoxOnLine.Size = new System.Drawing.Size(141, 34);
            this.checkBoxOnLine.TabIndex = 6;
            this.checkBoxOnLine.Text = "На ленте";
            this.checkBoxOnLine.UseVisualStyleBackColor = true;
            this.checkBoxOnLine.Click += new System.EventHandler(this.CheckBoxOnLine_Click);
            // 
            // checkBoxOnField
            // 
            this.checkBoxOnField.AutoSize = true;
            this.checkBoxOnField.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxOnField.Location = new System.Drawing.Point(21, 37);
            this.checkBoxOnField.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxOnField.Name = "checkBoxOnField";
            this.checkBoxOnField.Size = new System.Drawing.Size(129, 34);
            this.checkBoxOnField.TabIndex = 5;
            this.checkBoxOnField.Text = "На поле";
            this.checkBoxOnField.UseVisualStyleBackColor = true;
            this.checkBoxOnField.Click += new System.EventHandler(this.CheckBoxOnField_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.numericUpDownVerticalPieces);
            this.groupBox1.Controls.Add(this.numericUpDownHorizontalPieces);
            this.groupBox1.Controls.Add(this.Height);
            this.groupBox1.Controls.Add(this.Width);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(339, 235);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(281, 182);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество пазлов";
            // 
            // numericUpDownVerticalPieces
            // 
            this.numericUpDownVerticalPieces.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownVerticalPieces.Location = new System.Drawing.Point(188, 102);
            this.numericUpDownVerticalPieces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownVerticalPieces.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownVerticalPieces.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownVerticalPieces.Name = "numericUpDownVerticalPieces";
            this.numericUpDownVerticalPieces.Size = new System.Drawing.Size(69, 37);
            this.numericUpDownVerticalPieces.TabIndex = 6;
            this.numericUpDownVerticalPieces.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownHorizontalPieces
            // 
            this.numericUpDownHorizontalPieces.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownHorizontalPieces.Location = new System.Drawing.Point(188, 58);
            this.numericUpDownHorizontalPieces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownHorizontalPieces.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownHorizontalPieces.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownHorizontalPieces.Name = "numericUpDownHorizontalPieces";
            this.numericUpDownHorizontalPieces.Size = new System.Drawing.Size(69, 37);
            this.numericUpDownHorizontalPieces.TabIndex = 5;
            this.numericUpDownHorizontalPieces.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Height
            // 
            this.Height.AutoSize = true;
            this.Height.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Height.Location = new System.Drawing.Point(35, 103);
            this.Height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(139, 30);
            this.Height.TabIndex = 3;
            this.Height.Text = "По высоте";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Width.Location = new System.Drawing.Point(35, 60);
            this.Width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(146, 30);
            this.Width.TabIndex = 2;
            this.Width.Text = "По ширине";
            // 
            // tabPageGallery
            // 
            this.tabPageGallery.Controls.Add(this.textBoxImageName);
            this.tabPageGallery.Controls.Add(this.buttonDeleteImage);
            this.tabPageGallery.Controls.Add(this.buttonAddImage);
            this.tabPageGallery.Controls.Add(this.groupBox5);
            this.tabPageGallery.Location = new System.Drawing.Point(4, 44);
            this.tabPageGallery.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageGallery.Name = "tabPageGallery";
            this.tabPageGallery.Size = new System.Drawing.Size(1036, 465);
            this.tabPageGallery.TabIndex = 2;
            this.tabPageGallery.Text = "Галерея";
            this.tabPageGallery.UseVisualStyleBackColor = true;
            // 
            // textBoxImageName
            // 
            this.textBoxImageName.Location = new System.Drawing.Point(3, 390);
            this.textBoxImageName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxImageName.Name = "textBoxImageName";
            this.textBoxImageName.Size = new System.Drawing.Size(487, 32);
            this.textBoxImageName.TabIndex = 17;
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteImage.Location = new System.Drawing.Point(772, 391);
            this.buttonDeleteImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Size = new System.Drawing.Size(248, 54);
            this.buttonDeleteImage.TabIndex = 15;
            this.buttonDeleteImage.Text = "Удалить картинку";
            this.buttonDeleteImage.UseVisualStyleBackColor = true;
            this.buttonDeleteImage.Click += new System.EventHandler(this.ButtonDeleteImage_Click);
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddImage.Location = new System.Drawing.Point(504, 391);
            this.buttonAddImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(260, 54);
            this.buttonAddImage.TabIndex = 14;
            this.buttonAddImage.Text = "Добавить картинку";
            this.buttonAddImage.UseVisualStyleBackColor = true;
            this.buttonAddImage.Click += new System.EventHandler(this.ButtonAddImage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PictureBoxDisplayImage);
            this.groupBox5.Controls.Add(this.listBoxImages);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox5.Size = new System.Drawing.Size(1036, 388);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // PictureBoxDisplayImage
            // 
            this.PictureBoxDisplayImage.Location = new System.Drawing.Point(241, 26);
            this.PictureBoxDisplayImage.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBoxDisplayImage.Name = "PictureBoxDisplayImage";
            this.PictureBoxDisplayImage.Size = new System.Drawing.Size(785, 350);
            this.PictureBoxDisplayImage.TabIndex = 1;
            this.PictureBoxDisplayImage.TabStop = false;
            // 
            // listBoxImages
            // 
            this.listBoxImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxImages.FormattingEnabled = true;
            this.listBoxImages.ItemHeight = 24;
            this.listBoxImages.Location = new System.Drawing.Point(9, 26);
            this.listBoxImages.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxImages.Name = "listBoxImages";
            this.listBoxImages.Size = new System.Drawing.Size(193, 340);
            this.listBoxImages.TabIndex = 0;
            this.listBoxImages.SelectedIndexChanged += new System.EventHandler(this.ListBoxImages_SelectedIndexChanged);
            this.listBoxImages.DoubleClick += new System.EventHandler(this.ListBoxImages_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::University.Puzzle.UI.Properties.Resources.вопрос;
            this.pictureBox1.Location = new System.Drawing.Point(33, 516);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 39);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(University.Puzzle.ObjectsLibrary.Game);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControlNavigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AdministratorForm";
            this.Text = "Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorForm_FormClosing);
            this.tabControlNavigation.ResumeLayout(false);
            this.tabPageGames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).EndInit();
            this.tabPageGameCreation.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageDifficultyCreation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDifficulty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVerticalPieces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorizontalPieces)).EndInit();
            this.tabPageGallery.ResumeLayout(false);
            this.tabPageGallery.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDisplayImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlNavigation;
        private System.Windows.Forms.TabPage tabPageGames;
        private System.Windows.Forms.TabPage tabPageGameCreation;
        private System.Windows.Forms.TabPage tabPageGallery;
        private System.Windows.Forms.Button DeleteGame;
        private System.Windows.Forms.Button buttonCreateGame;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listBoxImages;
        private System.Windows.Forms.Button buttonDeleteImage;
        private System.Windows.Forms.Button buttonAddImage;
        private System.Windows.Forms.PictureBox PictureBoxDisplayImage;
        private System.Windows.Forms.TextBox textBoxImageName;
        private System.Windows.Forms.TabPage tabPageDifficultyCreation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxFigure;
        private System.Windows.Forms.CheckBox checkBoxSquare;
        private System.Windows.Forms.CheckBox checkBoxTriangle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxOnHeap;
        private System.Windows.Forms.CheckBox checkBoxOnLine;
        private System.Windows.Forms.CheckBox checkBoxOnField;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownVerticalPieces;
        private System.Windows.Forms.NumericUpDown numericUpDownHorizontalPieces;
        private System.Windows.Forms.Label Height;
        private System.Windows.Forms.Label Width;
        private System.Windows.Forms.TextBox textBoxSelectedImage;
        private System.Windows.Forms.Button buttonAddDifficulty;
        private System.Windows.Forms.Button buttonDeleteDifficulty;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonSelectDifficulty;
        private System.Windows.Forms.TextBox textBoxDifficulty;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxGameName;
        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewGames;
        private System.Windows.Forms.DataGridView dataGridViewDifficulty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMixImage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}