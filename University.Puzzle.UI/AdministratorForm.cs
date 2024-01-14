using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using University.Puzzle.Client;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ObjectsLibrary.Enum;
using University.Puzzle.UI.Models;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.UI
{
    #region Class: AdministratorForm
    /// <summary>
    /// Форма администратора.
    /// </summary>
    public partial class AdministratorForm : Form
    {
        #region Fields: Private
        /// <summary>
        /// Для перемещивания
        /// </summary>
        private GameForm game;
        /// <summary>
        /// Элемент изображения
        /// </summary>
        private PictureBox[] pbSegments;
        /// <summary>
        /// Путь до директория с картки
        /// </summary>
        private readonly string _imagesDirectoryPath = "..\\images";

        /// <summary>
        /// Отображает диалоговое окно.
        /// </summary>
        private OpenFileDialog _openFileDialog;

        /// <summary>
        /// Выполняет операции с записями изображений.
        /// </summary>
        private ImageHandler _imageHandler;

        /// <summary>
        /// Выполняет операции с записями сложностей.
        /// </summary>
        private DifficultyHandler _difficultyHandler;

        /// <summary>
        /// Выполняет операции с записями игр.
        /// </summary>
        private GameHandler _gameHandler;

        /// <summary>
        /// Фильтр для выбора изображений формата JPEG.
        /// </summary>
        private string _openFileDialogJpegFilter = "Изображения JPEG (*.jpeg;*.jpg)|*.jpeg;*.jpg";

        /// <summary>
        /// Выбранная для создания игры сложность.
        /// </summary>
        private Guid _selectedDifficultyId;

        /// <summary>
        /// Выбранная игра.
        /// </summary>
        private Guid _selectedGameId;

        /// <summary>
        /// Идентификатор выбранного изображение.
        /// </summary>
        private Guid _selectedImageId;

        /// <summary>
        /// Список игр.
        /// </summary>
        private List<DataGridItemGame> dataGridGames;
        #endregion

        #region Methods: Private
        #region Tab Functionality: Gallery
        /// <summary>
        /// Создает директорий по пути, если его нет.
        /// </summary>
        /// <param name="directoryPath">Путь к директорию.</param>
        private void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Добавить картинку".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonAddImage_Click(object sender, EventArgs e)
        {
            _openFileDialog.Filter = _openFileDialogJpegFilter;

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedFilePath = _openFileDialog.FileName;

                try
                {
                    var imageName = textBoxImageName.Text;
                    TextValidator.IsValidString(imageName);
                    await _imageHandler.Upload(selectedFilePath, imageName);
                    var targetFilePath = Path.Combine(_imagesDirectoryPath, $"{imageName}.jpg");
                    File.Copy(selectedFilePath, targetFilePath, true);
                    UpdateListBoxImages();
                    ShowInfoMessageBox("Изображение было успешно добавлено.");
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }
            }
        }

        /// <summary>
        /// Отображает изображение в окне.
        /// </summary>
        /// <param name="imagePath">Путь до изображения.</param>
        private void DisplayImage(string imagePath)
        {
            try
            {
                FileValidator.CheckFileExists(imagePath);
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
            using (Bitmap image = new Bitmap(imagePath))
            {
                if (image.Width > PictureBoxDisplayImage.Width || image.Height > PictureBoxDisplayImage.Height)
                {
                    PictureBoxDisplayImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    PictureBoxDisplayImage.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                PictureBoxDisplayImage.Image = new Bitmap(image);
            }
        }

        /// <summary>
        /// Обновляет список изображений в галлереи.
        /// </summary>
        private async void UpdateListBoxImages()
        {
            listBoxImages.Items.Clear();
            var imagesNameList = await _imageHandler.GetImagesNameList();

            foreach (var imageName in imagesNameList)
            {
                listBoxImages.Items.Add(imageName);
            }
        }

        /// <summary>
        /// Обрабатывает изменение текущего изображения в галлереи.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void ListBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxImages.SelectedIndex != -1)
            {
                try
                {
                    var selectedImageName = listBoxImages.SelectedItem.ToString();
                    var imagePath = _imagesDirectoryPath + $"\\{selectedImageName}.jpg";

                    if (!File.Exists(imagePath))
                    {
                        DownloadImage(selectedImageName);
                    }
                    else
                    {
                        DisplayImage(imagePath);
                    }
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }
                catch (SecurityException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }
            }
        }
      
        /// <summary>
        /// Загружает изображение по названию с сервера.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        private async void DownloadImage(string imageName)
        {
            var image = await _imageHandler.Download(imageName);
            var imagePath = _imagesDirectoryPath + $"\\{imageName}.jpg";

            using (var fileStream = File.Create(imagePath))
            {
                image.Data.CopyTo(fileStream);
            }

            DisplayImage(imagePath);
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Удалить картинку".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonDeleteImage_Click(object sender, EventArgs e)
        {
            if (listBoxImages.SelectedIndex != -1)
            {
                try
                {
                    var selectedImageName = listBoxImages.SelectedItem.ToString();
                    var imagePath = _imagesDirectoryPath + $"\\{selectedImageName}.jpg";
                    FileValidator.CheckFileExists(imagePath);
                    await _imageHandler.Delete(selectedImageName);
                    PictureBoxDisplayImage.Image = null;
                    File.Delete(imagePath);
                    ShowInfoMessageBox("Изображение было успешно удалено.");
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }

                UpdateListBoxImages();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Выбор изображения".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void ButtonSelectImage_Click(object sender, EventArgs e)
        {
            tabControlNavigation.SelectedIndex = (int)AdministratorTabCode.GalleryTab;
            ShowInfoMessageBox("Двойным нажатием на левую кнопку мыши выберите изображение из списка.");
        }

        /// <summary>
        /// Перемешивает изображение в Bitmap во вкладке создания игры.
        /// </summary>
        /// <returns></returns>
        private async Task ShuffleImage()
        {
            try
            {
                CheckImageSelected();
                CheckDifficultySelected();
                var difficulty = await _difficultyHandler.GetDifficulty(_selectedDifficultyId);
                var selectedImageName = textBoxSelectedImage.Text;
                var imagePath = _imagesDirectoryPath + $"\\{selectedImageName}.jpg";

                if (!File.Exists(imagePath))
                {
                    var image = await _imageHandler.Download(selectedImageName);

                    using (var fileStream = File.Create(imagePath))
                    {
                        image.Data.CopyTo(fileStream);
                    }
                }
                CreateFigure createFigure = new CreateFigure(pbSegments, new Bitmap(imagePath),difficulty.HorizontalPieces, difficulty.VerticalPieces, setka, arr, modePole, size, arrTrue, panel2);
                game = new GameForm(
                difficulty.AssembleMode,
                difficulty.PieceForm,
                difficulty.HorizontalPieces,
                difficulty.VerticalPieces,
                new Bitmap(imagePath));
                string modePole = game.GetModePole(difficulty.AssembleMode);
                buttonMixImage.Visible = false;

                if (modePole == "На поле")
                {
                    string modeFigure = game.GetModeFigure(difficulty.PieceForm);
                    // Создаем массив сегментов установленного размера.
                    int size = difficulty.HorizontalPieces * difficulty.VerticalPieces;
                    pbSegments = new PictureBox[size];
                    int w = panel1.Width / difficulty.HorizontalPieces;
                    int h = panel1.Height / difficulty.VerticalPieces;
                    game.Tag = new Bitmap(imagePath);

                    switch (modeFigure)
                    {
                        case "Прямоугольник":
                            {
                                pbSegments = game.CreateRectangle(w, h, panel1);
                                buttonMixImage.Visible = true;
                            }
                            break;
                        case "Сложная фигура":
                            {
                                pbSegments = game.CreateHard(w, h, panel1);
                                buttonMixImage.Visible = true;
                            }
                            break;
                        case "Треугольник":
                            {
                                pbSegments = new PictureBox[size * 2];
                                pbSegments = game.CreateTriangle(w, h, panel1);
                                buttonMixImage.Visible = true;
                            }
                            break;
                    }
                }
                else
                {
                    panel1.BackgroundImage = new Bitmap(imagePath);
                }
            }
            catch (ArgumentException ex)
            {

            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку перемешать изображение.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void ButtonMixImage_Click(object sender, EventArgs e)
        {
           MixedSegments();
        }
        
        /// <summary>
        /// Перемешивает сегменты изображения.
        /// </summary>
        private void MixedSegments()
        {
            Random rand = new Random(Environment.TickCount);
            for (int i = 0; i < pbSegments.Length; i++)
            {
                pbSegments[i].Visible = true;
                int temp = rand.Next(0, pbSegments.Length);
                Point ptR = pbSegments[temp].Location;
                Point ptI = pbSegments[i].Location;
                pbSegments[i].Location = ptR;
                pbSegments[temp].Location = ptI;
                pbSegments[i].BorderStyle = BorderStyle.FixedSingle;
            }
        }
        /// <summary>
        /// Обрабатывает двойное нажатие на элемент из списка изображений.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ListBoxImages_DoubleClick(object sender, EventArgs e)
        {
            textBoxSelectedImage.Text = listBoxImages.SelectedItem.ToString();
            tabControlNavigation.SelectedIndex = (int)AdministratorTabCode.CreateGameTab;
            _selectedImageId = await _imageHandler.GetId(listBoxImages.SelectedItem.ToString()); 
        }
        #endregion

        #region Tab Functionality: Difficulty
        /// <summary>
        /// Удаляет выбранную запись сложности.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonDeleteDifficulty_Click(object sender, EventArgs e)
        {
            var selectedRowCount = dataGridViewDifficulty.CurrentCell.RowIndex;
            if (selectedRowCount > -1)
            {
                try
                {
                    var selectedDifficulty = dataGridViewDifficulty.Rows[selectedRowCount].DataBoundItem as DataGridItemDifficulty;
                    await _difficultyHandler.DeleteDifficulty(selectedDifficulty.Id);
                    ShowInfoMessageBox("Запись была успешно удалена.");
                    UpdateDataGridDifficulties();
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }
            }
            else
            {
                ShowErrorMessageBox("Выберите запись из списка для удаления.");
            }
        }

        /// <summary>
        /// Обрабатывает кнопку нажатия добавления сложности.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonAddDifficulty_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedAssembleMode = GetSelectedCheckBoxIndex(GetAssembleModeCheckBoxes(), "Выберите режим сборки.");
                var selectedPieceForm = GetSelectedCheckBoxIndex(GetPieceFormCheckBoxes(), "Выберите форму пазла.");
                var horizontalPieces = (int)numericUpDownHorizontalPieces.Value;
                var verticalPieces = (int)numericUpDownVerticalPieces.Value;
                var maxScore = Difficulty.GetScore(
                    selectedAssembleMode, 
                    selectedPieceForm, 
                    verticalPieces, 
                    horizontalPieces);
                var difficultyType = Difficulty.GetDifficultyTypeByScore(maxScore);
                var difficulty = new Difficulty(
                    Guid.NewGuid(),
                    horizontalPieces,
                    verticalPieces,
                    selectedAssembleMode,
                    selectedPieceForm,
                    difficultyType);
                await _difficultyHandler.AddDifficulty(difficulty);
                ShowInfoMessageBox("Сложность была успешно добавлена.");
                UpdateDataGridDifficulties();
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
        }

        /// <summary>
        /// Обновляет список записей сложностей.
        /// </summary>
        private async void UpdateDataGridDifficulties()
        {
            var difficulties = await _difficultyHandler.GetDifficulties();
            var dataGridItemDifficulties = new List<DataGridItemDifficulty>();
            
            foreach(var difficulty in difficulties)
            {
                dataGridItemDifficulties.Add(new DataGridItemDifficulty()
                {
                    Id = difficulty.Id,
                    DifficultyType = difficulty.GetDifficultyType(),
                    AssembleMode = difficulty.GetAssembleMode(),
                    PieceForm = difficulty.GetPieceForm(),
                    Size = $"{difficulty.HorizontalPieces}x{difficulty.VerticalPieces}",
                });
            }

            dataGridViewDifficulty.DataSource = dataGridItemDifficulties;
            dataGridViewDifficulty.Columns["Id"].Visible = false;
            dataGridViewDifficulty.Columns["DifficultyType"].HeaderCell.Value = "Сложность";
            dataGridViewDifficulty.Columns["DifficultyType"].Width = 180;
            dataGridViewDifficulty.Columns["AssembleMode"].HeaderCell.Value = "Тип сборки";
            dataGridViewDifficulty.Columns["AssembleMode"].Width = 180;
            dataGridViewDifficulty.Columns["PieceForm"].HeaderCell.Value = "Форма пазла";
            dataGridViewDifficulty.Columns["PieceForm"].Width = 150;
            dataGridViewDifficulty.Columns["Size"].HeaderCell.Value = "Размер";
            dataGridViewDifficulty.Columns["Size"].Width = 140;

            dataGridViewDifficulty.Refresh();
        }

        /// <summary>
        /// Меняет параметры сложности на выбранную из списка.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateDifficultyParameters(Difficulty difficulty)
        {
            ObjectValidator.CheckNullReference(difficulty);

            numericUpDownVerticalPieces.Value = difficulty.VerticalPieces;
            numericUpDownHorizontalPieces.Value = difficulty.HorizontalPieces;
            SetCheckBox(GetPieceFormCheckBoxes(), difficulty.PieceForm);
            SetCheckBox(GetAssembleModeCheckBoxes(), difficulty.AssembleMode);
        }

        /// <summary>
        /// Устанавливает CheckBox по индексу значение true, остальным false.
        /// </summary>
        /// <param name="checkBoxes">Массив CheckBox.</param>
        /// <param name="index">Выбранный CheckBox.</param>
        private void SetCheckBox(CheckBox[] checkBoxes, int index)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Checked = index == i;
            }
        }

        /// <summary>
        /// Возвращает индекс выбранного CheckBox из массива.
        /// </summary>
        /// <param name="checkBoxes">Массив CheckBox.</param>
        /// <param name="errorMessage">Сообщение об ошибке, если ни один не выбран.</param>
        /// <returns>Индекс выбранного CheckBox из массива.</returns>
        /// <exception cref="ArgumentException">Ни один CheckBox не выбран.</exception>
        private int GetSelectedCheckBoxIndex(CheckBox[] checkBoxes, string errorMessage)
        {
            var i = 0;

            while (i < checkBoxes.Length && !checkBoxes[i].Checked)
            {

                i++;
            }

            if (i == checkBoxes.Length)
            {
                throw new ArgumentException(errorMessage);
            }

            return i;
        }

        /// <summary>
        /// Обрабатывает нажатие чекбокса "На ленте".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBoxOnLine_Click(object sender, EventArgs e)
        {
            UncheckCheckBoxes((int)AssembleModeType.OnLine, GetAssembleModeCheckBoxes());
        }

        /// <summary>
        /// Обрабатывает нажатие чекбокса "На поле".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBoxOnField_Click(object sender, EventArgs e)
        {
            UncheckCheckBoxes((int)AssembleModeType.OnField, GetAssembleModeCheckBoxes());
        }

        /// <summary>
        /// Обрабатывает нажатие чекбокса "В куче".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBoxOnHeap_Click(object sender, EventArgs e)
        {
            UncheckCheckBoxes((int)AssembleModeType.OnHeap, GetAssembleModeCheckBoxes());
        }

        /// <summary>
        /// Возвращает массив CheckBox отвечающих за режим сборки.
        /// </summary>
        /// <returns>Массив CheckBox</returns>
        private CheckBox[] GetAssembleModeCheckBoxes()
        {
            return new CheckBox[] {
                checkBoxOnField,
                checkBoxOnLine,
                checkBoxOnHeap};
        }

        /// <summary>
        /// Снимает галочку со всех CheckBox, кроме последнего выбранного.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        /// <param name="checkBoxes"></param>
        private void UncheckCheckBoxes(int selectedIndex, CheckBox[] checkBoxes)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Checked = i == selectedIndex;
            }
        }

        /// <summary>
        /// Возвращает массив CheckBox отвечающих за форму пазла.
        /// </summary>
        /// <returns>Массив CheckBox</returns>
        private CheckBox[] GetPieceFormCheckBoxes()
        {
            return new CheckBox[]
            {
                checkBoxSquare,
                checkBoxTriangle,
                checkBoxFigure
            };
        }

        /// <summary>
        /// Обрабатывает нажатие на "Треугольник".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBoxSquare_Click(object sender, EventArgs e)
        {
            UncheckCheckBoxes((int)PieceFormType.Square, GetPieceFormCheckBoxes());
        }

        /// <summary>
        /// Обрабатывает нажатие на "Треугольник".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBoxFigure_Click(object sender, EventArgs e)
        {
            UncheckCheckBoxes((int)PieceFormType.Figure, GetPieceFormCheckBoxes());
        }

        /// <summary>
        /// Обрабатывает нажатие на "Треугольник".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CheckBoxTriangle_Click(object sender, EventArgs e)
        {
            UncheckCheckBoxes((int)PieceFormType.Triangle, GetPieceFormCheckBoxes());
        }
        #endregion

        #region Tab Functionality: Game Creation
        /// <summary>
        /// Обрабатывает нажатие на кнопку выбора сложности.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void ButtonSelectDifficulty_Click(object sender, EventArgs e)
        {
            tabControlNavigation.SelectedIndex = (int)AdministratorTabCode.DifficultyTab;
            ShowInfoMessageBox("Двойным нажатием на левую кнопку мыши выберите сложность из списка.");
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку создания игры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonCreateGame_Click(object sender, EventArgs e)
        {
            try
            {
                CheckImageSelected();
                CheckDifficultySelected();
                TextValidator.IsValidString(textBoxGameName.Text);
                var gameName = textBoxGameName.Text;
                var imageName = textBoxSelectedImage.Text;
                var imageId = await _imageHandler.GetId(imageName);
                var game = new Game()
                {
                    Id = Guid.NewGuid(),
                    DifficultyId = _selectedDifficultyId,
                    ImageId = imageId,
                    Name = gameName,
                    Preset = JsonConvert.SerializeObject(GetPole(await _difficultyHandler.GetDifficulty(_selectedDifficultyId))),
                };
                //Комменты вани
                //Если сборка на поле то дополнительно сохраняй координаты pbsegments
               //if (modeFigure == "На поле")
               //{
               //    for (int i = 0; i < pbSegments.Length; i++)
               //    { 
               //        какое - то поле = pbSegments[1].Location;
               //    }      
               //}
                await _gameHandler.AddGame(game);
                ShowInfoMessageBox("Игра была успешно добавлена.");
                tabControlNavigation.SelectTab((int)AdministratorTabCode.GamesTab);
                UpdateDataGridGames();
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
        }

        private string[,] GetPole(Difficulty difficulty)
        {
            if (difficulty.GetAssembleMode() == "На поле")
            {
                string[,] poleSave = new string[,] { };
                int length = difficulty.HorizontalPieces * difficulty.VerticalPieces;
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                poleSave[i, j] = pbSegments[i].Location.ToString();
                                break;
                        }
                    }
                }
                return poleSave;
            }

            return null;
        }

        /// <summary>
        /// Обновляет список игр в DataGrid.
        /// </summary>
        private async void UpdateDataGridGames()
        {
            dataGridGames = new List<DataGridItemGame>();
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
        /// Проверяет, что сложность для создания игры выбрана.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CheckDifficultySelected()
        {
            if (_selectedDifficultyId == Guid.Empty)
            {
                throw new ArgumentException("Выберите сложность.");
            }
        }

        private void DataGridViewDifficulty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRowCount = dataGridViewDifficulty.CurrentCell.RowIndex;
            if (selectedRowCount > -1)
            {
                var selectedDifficulty = dataGridViewDifficulty.Rows[selectedRowCount].DataBoundItem as DataGridItemDifficulty;
                _selectedDifficultyId = selectedDifficulty.Id;
            }
        }

        /// <summary>
        /// Обрабаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DataGridViewDifficulty_DoubleClick(object sender, EventArgs e)
        {
            var selectedRowCount = dataGridViewDifficulty.CurrentCell.RowIndex;
            if (selectedRowCount > -1)
            {
                var selectedDifficulty = dataGridViewDifficulty.Rows[selectedRowCount].DataBoundItem as DataGridItemDifficulty;
                _selectedDifficultyId = selectedDifficulty.Id;
                try
                {
                    var difficulty = await _difficultyHandler.GetDifficulty(selectedDifficulty.Id);
                    textBoxDifficulty.Text = difficulty.ToString();
                    tabControlNavigation.SelectTab((int)AdministratorTabCode.CreateGameTab);
                    ShowInfoMessageBox("Сложность была успешно выбрана");
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }
            }
        }
        #endregion

        #region Tab Functionality: Games
        /// <summary>
        /// Обрабатывает нажатие на кнопку удаления игры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void DeleteGame_Click(object sender, EventArgs e)
        {
            if (_selectedGameId == Guid.Empty)
            {
                ShowErrorMessageBox("Выберите игру из списка");
            }

            try
            {
                await _gameHandler.DeleteGame(_selectedGameId);
                ShowInfoMessageBox("Запись была успешно удалена.");
                UpdateDataGridGames();
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку создания игры в списке игр.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void ButtonToGameCreationTab_Click(object sender, EventArgs e)
        {
            ShowInfoMessageBox("Выберите указанные параметры для создания игры");
            tabControlNavigation.SelectTab(tabControlNavigation.SelectedIndex = (int)AdministratorTabCode.CreateGameTab);
        }

        /// <summary>
        /// Обрабатывает нажатие на ячейку в dataGridViewGames.
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
        #endregion

        #region Tab Functionality: Common
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
        /// Проверяет что в создании игры выбрано изображение.
        /// </summary>
        /// <exception cref="ArgumentException">Изображение не выбрано.</exception>
        private void CheckImageSelected()
        {
            var selectedImageName = textBoxSelectedImage.Text;

            if (selectedImageName.Equals("Изображение не выбрано"))
            {
                throw new ArgumentException("Изображение не выбрано");
            }
        }

        /// <summary>
        /// Обрабатывает изменение вкладки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void TabControlNavigation_Selected(object sender, TabControlEventArgs e)
        {
            switch ((AdministratorTabCode)tabControlNavigation.SelectedIndex)
            {
                case AdministratorTabCode.GamesTab:
                    UpdateDataGridGames();
                    break;
                case AdministratorTabCode.CreateGameTab:
                    ShuffleImage();
                    break;
                case AdministratorTabCode.DifficultyTab:
                    UpdateDataGridDifficulties();
                    break;
                case AdministratorTabCode.GalleryTab:
                    UpdateListBoxImages();
                    break;
            }
        }

        /// <summary>
        /// Открывает форму авторизации перед закрытием.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void AdministratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new AuthorizationRegistrationForm().Show();
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

        /// <summary>
        /// Показывает сообщение об ошибке.
        /// </summary>
        /// <param name="message">Текст ошибки.</param>
        private void ShowErrorMessageBox(string message)
        {
            TextValidator.IsValidString(message);
            MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземлпяр класса.
        /// </summary>
        public AdministratorForm()
        {
            InitializeComponent();
            CreateDirectory(_imagesDirectoryPath);
            ConfigureDataGridView(dataGridViewGames);
            ConfigureDataGridView(dataGridViewDifficulty);
            _openFileDialog = new OpenFileDialog();
            _imageHandler = new ImageHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _difficultyHandler = new DifficultyHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _gameHandler = new GameHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            UpdateDataGridGames();
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AboutUser aboutUser = new AboutUser();
            aboutUser.Show();
        }

        public AboutUser AboutUser
        {
            get => default;
            set
            {
            }
        }
    }
    #endregion
}
