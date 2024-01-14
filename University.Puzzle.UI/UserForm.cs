using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using University.Puzzle.Client;
using University.Puzzle.ObjectsLibrary.Enum;
using University.Puzzle.UI.Enum;
using University.Puzzle.UI.Models;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.UI
{
    #region Class: UserForm
    /// <summary>
    /// Форма пользователя.
    /// </summary>
    public partial class UserForm : Form
    {
        #region Fields: Private
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        private Guid _userId;

        /// <summary>
        /// Взаимодействует с записями изображений.
        /// </summary>
        private ImageHandler _imageHandler;

        /// <summary>
        /// Взаимодействует с записями сложности.
        /// </summary>
        private DifficultyHandler _difficultyHandler;

        /// <summary>
        /// Взаимодействует с записями игр.
        /// </summary>
        private GameHandler _gameHandler;

        /// <summary>
        /// Взаимодействует с записями рекордов.
        /// </summary>
        private RecordHandler _recordHandler;

        /// <summary>
        /// Взаимодействует с записями пользователей.
        /// </summary>
        private UserHandler _userHandler;

        /// <summary>
        /// Взаимодействует с записями сохранений.
        /// </summary>
        private SaveHandler _saveHandler;

        /// <summary>
        /// Идентификатор выбранной игры.
        /// </summary>
        private Guid _selectedGameId;

        /// <summary>
        /// Идентификатор выбранного сохранения.
        /// </summary>
        private Guid _selectedSaveId;

        public GameForm GameForm
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Methods: Private
        /// <summary>
        /// Обработчик события после закрытия формы.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Показывает сообщение об ошибке.
        /// </summary>
        /// <param name="message">Текст ошибки.</param>
        private void ShowErrorMessageBox(string message)
        {
            TextValidator.IsValidString(message);
            MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Играть".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButttonPlay_Click(object sender, System.EventArgs e)
        {
            if (_selectedGameId != Guid.Empty)
            {
                try
                {
                    var game = await _gameHandler.GetGame(_selectedGameId);
                    var difficulty = await _difficultyHandler.GetDifficulty(game.DifficultyId);
                    var imageName = await _imageHandler.GetImageName(game.ImageId);
                    var imagePath = $"..\\images\\{imageName}.jpg";

                    if (!File.Exists(imagePath))
                    {
                        var image = await _imageHandler.Download(imageName);

                        using (var fileStream = File.Create(imagePath))
                        {
                            image.Data.CopyTo(fileStream);
                        }
                    }

                    var gameForm = new GameForm(
                        difficulty.AssembleMode,
                        difficulty.PieceForm,
                        difficulty.HorizontalPieces,
                        difficulty.VerticalPieces,
                        GetSelectedRadioText(),
                        _userId,
                        game.Id);


                    gameForm.Tag = new Bitmap(imagePath);
                    gameForm.Show();
                    this.Dispose();
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }
            }
            else
            {
                ShowErrorMessageBox("Выберите игру из списка");
            }
        }

        /// <summary>
        /// Возвращает тексто выбранного RadioButton.
        /// </summary>
        /// <returns>Текст выбранного RadioButton.</returns>
        /// <exception cref="ArgumentException">Ни один RadioButton не нажат.</exception>
        private string GetSelectedRadioText()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                return radioButton2.Text;
            }

            throw new ArgumentException("Выберите режим игры");
        }

        /// <summary>
        /// Обрабатывает нажатие на ячейку в таблице игр.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void DataGridViewGames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRowCount = dataGridViewGames.CurrentCell.RowIndex;
            if (selectedRowCount > -1)
            {
                var selectedGame = dataGridViewGames.Rows[selectedRowCount].DataBoundItem as DataGridItemGame;
                _selectedGameId = selectedGame.Id;
            }
        }

        /// <summary>
        /// Открывает форму авторизации перед закрытием.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void GamerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new AuthorizationRegistrationForm().Show();
        }

        /// <summary>
        /// Выполняет настройку таблицы DataGridView.
        /// </summary>
        /// <param name="dataGrid">Таблица.</param>
        private void ConfigureDataGridView(DataGridView dataGrid)
        {
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.MultiSelect = false;
        }

        /// <summary>
        /// Обновляет список игр в DataGrid.
        /// </summary>
        private async void UpdateGames()
        {
            var dataGridGames = new List<DataGridItemGame>();
            var games = await _gameHandler.GetGames();

            foreach (var game in games)
            {
                game.Difficulty = await _difficultyHandler.GetDifficulty(game.DifficultyId);
                var imageName = await _imageHandler.GetImageName(game.ImageId);
                dataGridGames.Add(new DataGridItemGame
                {
                    Id = game.Id,
                    AssembleMode = game.Difficulty.GetAssembleMode(),
                    Difficulty = game.Difficulty.GetDifficultyType(),
                    FieldSize = $"{game.Difficulty.HorizontalPieces}x{game.Difficulty.VerticalPieces}",
                    ImageName = imageName,
                    Name = game.Name,
                    PieceForm = game.Difficulty.GetPieceForm(),
                });
            }

            dataGridViewGames.DataSource = dataGridGames;
            dataGridViewGames.Columns["Id"].Visible = false;
            dataGridViewGames.Columns["Name"].HeaderCell.Value = "Название";
            dataGridViewGames.Columns["Name"].Width = 160;
            dataGridViewGames.Columns["ImageName"].HeaderCell.Value = "Изображение";
            dataGridViewGames.Columns["ImageName"].Width = 210;
            dataGridViewGames.Columns["FieldSize"].HeaderCell.Value = "Размер";
            dataGridViewGames.Columns["FieldSize"].Width = 140;
            dataGridViewGames.Columns["AssembleMode"].HeaderCell.Value = "Тип сборки";
            dataGridViewGames.Columns["AssembleMode"].Width = 180;
            dataGridViewGames.Columns["PieceForm"].HeaderCell.Value = "Форма пазла";
            dataGridViewGames.Columns["PieceForm"].Width = 150;
            dataGridViewGames.Columns["Difficulty"].HeaderCell.Value = "Сложность";
            dataGridViewGames.Columns["Difficulty"].Width = 180;
            dataGridViewGames.Refresh();
        }

        /// <summary>
        /// Обрабатывает изменение вкладок в навигационной панели.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void Navigation_Selected(object sender, TabControlEventArgs e)
        {
            switch ((UserTabCode)Navigation.SelectedIndex)
            {
                case UserTabCode.Games:
                    UpdateGames();
                    break;
                case UserTabCode.Records:
                    UpdateRecords();
                    break;
                case UserTabCode.Saves:
                    break;
            }
        }

        /// <summary>
        /// Обновляет список игр.
        /// </summary>
        private async void UpdateRecords()
        {
            int difficultyType = comboBoxDifficulty.SelectedIndex;
            int scoreMode = comboBoxScoreMode.SelectedIndex;
            var records = await _recordHandler
                .GetRecords(difficultyType, scoreMode);
            var dataGridRecords = new List<DataGridItemRecord>();
            var i = 1;

            if (records == null || records.Count == 0)
            {
                return;
            }

            foreach (var record in records)
            {
                dataGridRecords.Add(new DataGridItemRecord()
                {
                    Id = record.Id,
                    Login = await _userHandler.GetLogin(record.UserId),
                    Score = scoreMode == (int)ScoreMode.Score
                        ? record.Score.ToString()
                        : record.Time.ToString("mm:ss"),
                    Position = i++
                });
            }

            dataGridViewRecord.DataSource = dataGridRecords;
            dataGridViewRecord.Columns["Id"].Visible = false;
            dataGridViewRecord.Columns["Login"].HeaderCell.Value = "Пользователь";
            dataGridViewRecord.Columns["Login"].Width = 400;
            dataGridViewRecord.Columns["Position"].HeaderCell.Value = "Место";
            dataGridViewRecord.Columns["Position"].Width = 300;
            dataGridViewRecord.Columns["Score"].HeaderCell.Value = "Результат";
            dataGridViewRecord.Columns["Score"].Width = 400;
            dataGridViewRecord.Refresh();
        }

        /// <summary>
        /// Срабатывает при изменении вкладки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void Navigation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((UserTabCode)Navigation.SelectedIndex)
            {
                case UserTabCode.Games:
                    UpdateGames();
                    break;
                case UserTabCode.Records:
                    UpdateRecords();
                    break;
                case UserTabCode.Saves:
                    UpdateSaves();
                    break;
            }
        }

        /// <summary>
        /// Обновляет список сохранений.
        /// </summary>
        private async void UpdateSaves()
        {
            var dataGridSaves = new List<DataGridItemSave>();
            var savesId = await _saveHandler.GetSavesId(_userId);

            foreach (var saveId in savesId)
            {
                var save = await _saveHandler.GetSave(saveId);
                var game = await _gameHandler.GetGame(save.GameId);
                var difficulty = await _difficultyHandler.GetDifficulty(game.DifficultyId);
                dataGridSaves.Add(new DataGridItemSave()
                {
                    Id = saveId,
                    DifficultyType = difficulty.GetDifficultyType(),
                    GameName = game.Name,
                });
            }

            dataGridViewSaves.DataSource = dataGridSaves;
            dataGridViewSaves.Columns["Id"].Visible = false;
            dataGridViewSaves.Columns["GameName"].HeaderCell.Value = "Название игры";
            dataGridViewSaves.Columns["GameName"].Width = 250;
            dataGridViewSaves.Columns["DifficultyType"].HeaderCell.Value = "Сложность";
            dataGridViewSaves.Columns["DifficultyType"].Width = 250;
            dataGridViewSaves.Refresh();
        }

        /// <summary>
        /// Обрабатывает изменение выпадающего списка типа сложности.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void comboBoxDifficulty_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateRecords();
        }

        /// <summary>
        /// Обрабатывает изменение выпадающего списка режима подсчета очков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void comboBoxScoreMode_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateRecords();
        }

        /// <summary>
        /// Обрабатывает нажатие на иконку справки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void PictureBoxRecordHelp_Click(object sender, EventArgs e)
        {
            AboutUser aboutUser = new AboutUser();
            aboutUser.Show();
        }

        /// <summary>
        /// Обрабатывает нажатие на иконку справки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void PictureBoxGameHelp_Click(object sender, EventArgs e)
        {
            AboutUser aboutUser = new AboutUser();
            aboutUser.Show();
        }

        private void DataGridViewSaves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRowCount = dataGridViewSaves.CurrentCell.RowIndex;
            if (selectedRowCount > -1)
            {
                var selectedSave = dataGridViewSaves.Rows[selectedRowCount].DataBoundItem as DataGridItemSave;
                _selectedSaveId = selectedSave.Id;
            }
        }

        /// <summary>
        /// Загружает игру из сохранения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonContinue_Click(object sender, EventArgs e)
        {
            if (_selectedSaveId == Guid.Empty)
            {
                ShowErrorMessageBox("Выберите сохранение из списка.");
                return;
            }
            //todo: исправить загрузку
            var save = await _saveHandler.GetSave(_selectedSaveId);
            var game = await _gameHandler.GetGame(save.GameId);
            var difficulty = await _difficultyHandler.GetDifficulty(game.DifficultyId);
            var imageName = await _imageHandler.GetImageName(game.ImageId);
            var imagePath = $"..\\images\\{imageName}.jpg";

            if (!File.Exists(imagePath))
            {
                var image = await _imageHandler.Download(imageName);

                using (var fileStream = File.Create(imagePath))
                {
                    image.Data.CopyTo(fileStream);
                }
            }

            var gameForm = new GameForm(
                difficulty.AssembleMode,
                difficulty.PieceForm,
                difficulty.HorizontalPieces,
                difficulty.VerticalPieces,
                "На очки",
                "Сохранение",
                JsonConvert.DeserializeObject<string[,]>(save.Data),
                _userId,
                _selectedGameId);

            gameForm.Tag = new Bitmap(imagePath);

            gameForm.Show();
            this.Hide();
        }



        /// <summary>
        /// Удаляет сохранение.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonDeleteSave_Click(object sender, EventArgs e)
        {
            if (_selectedSaveId == Guid.Empty)
            {
                ShowErrorMessageBox("Выберите сохранение из списка.");
                return;
            }

            try
            {
                await _saveHandler.DeleteGame(_selectedSaveId);
                ShowInfoMessageBox("Сохранение было успешно удалено.");
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
        }

        /// <summary>
        /// Показывает информационное сообщение.
        /// </summary>
        /// <param name="message">Текст информации.</param>
        private void ShowInfoMessageBox(string message)
        {
            TextValidator.IsValidString(message);
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public UserForm(Guid userId)
        {
            InitializeComponent();
            ConfigureDataGridView(dataGridViewGames);
            ConfigureDataGridView(dataGridViewRecord);
            ConfigureDataGridView(dataGridViewSaves);
            _imageHandler = new ImageHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _difficultyHandler = new DifficultyHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _gameHandler = new GameHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _recordHandler = new RecordHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _userHandler = new UserHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _saveHandler = new SaveHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _userId = userId;
            comboBoxDifficulty.SelectedIndex = 0;
            comboBoxScoreMode.SelectedIndex = 0;

            UpdateGames();
        }
        #endregion

        
    }
    #endregion
}
