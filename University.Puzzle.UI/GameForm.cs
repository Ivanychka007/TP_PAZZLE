using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;
using University.Puzzle.Client;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ObjectsLibrary.Enum;

namespace University.Puzzle.UI
{
    public partial class GameForm : Form
    {
        private readonly int _notScore = -404;
        private PictureBox[] pbSegments;
        private Bitmap Picture;
        private int w;
        private int h;
        private int numX;
        private int numY;
        private Point startCordImage;
        private Point mousePos;
        private Point[] setka;
        private int[] arr;
        private bool move = false;
        private string modePole;
        private string modeStatus;
        private string modeFigure;
        private int size;
        private SoundPlayer player;
        private Guid _gameId;
        private Guid _userId;
        string[,] pole;
        //Количестов очков = пока 0 , но его значение нужно передавать из БД 
        private int scoring = 0;
        //Модификатор добавления очков эталон = 100
        private int modeCount = 100;
        //Массив для проверки повторных перестановок
        private int[] arrTrue;
        private string scoreMode;
        Panel panel2;

        /// <summary>
        /// Взаимодействует с Web API.
        /// </summary>
        private SaveHandler _saveHandler;

        System.Diagnostics.Stopwatch StopWatch = new System.Diagnostics.Stopwatch();


        public void Srart()
        {
            timer1.Start();
            this.StopWatch.Start();
        }

        //Метод подсчёта очков
        public void ScoringPoints(PictureBox pbSP, PictureBox pbSegmentsSp)
        {
            bool flag = true;
            for (int j = 0; j < pbSegments.Length; j++)
            {
                Point point = setka[j];
                if (pbSP.Location == point && pbSP.TabIndex == j && arrTrue[j] != j)
                {
                    arrTrue[j] = j;
                    flag = false;
                    scoring = scoring + modeCount;
                    label1.Text = scoring.ToString(); ;

                }
                else
                {
                    if (pbSegmentsSp.Location == point && pbSegmentsSp.TabIndex == j && arrTrue[j] != j)
                    {
                        arrTrue[j] = j;
                        flag = false;
                        scoring = scoring + modeCount;
                        label1.Text = scoring.ToString(); ;
                    }
                }
            }
            if (flag && modeCount > 10)
            {
                modeCount = modeCount - 10;
            }
        }

        public string GetModePole(int modePole)
        {
            switch (modePole)
            {
                case (int)AssembleModeType.OnField:
                    return "На поле";
                case (int)AssembleModeType.OnLine:
                    return "На линии";
                case (int)AssembleModeType.OnHeap:
                    return "В куче";
                default:
                    throw new ArgumentException("Неверный параметр режима сборки");
            }
        }

        public string GetModeFigure(int modeFigure)
        {
            switch (modeFigure)
            {
                case (int)PieceFormType.Square:
                    return "Прямоугольник";
                case (int)PieceFormType.Triangle:
                    return "Треугольник";
                case (int)PieceFormType.Figure:
                    return "Сложная фигура";
                default:
                    throw new ArgumentException("Неверный параметр формы пазла.");
            }
        }

        public void Stop()
        {
            timer1.Stop();
            this.StopWatch.Stop();
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
            player.Stream = Properties.Resources.фон;
            // Получаем изображение из свойства Tag второго окна

            Bitmap image = this.Tag as Bitmap;
            if (image != null)
            {

                Picture = image;
                pictureBox1.Image = ResizeOrigImg(image, pictureBox1.Width, pictureBox1.Height);
                //Сохранённая игра
                //modeStatus = "Сохранение";
                //Новая игра
                //modeStatus = "Новая";
                //На поле 
                //modePole = "На поле";
                //На линии
                //modePole = "На линии";
                //В куче
                //modePole ="В куче";
                //Значение формы фигуры передаёться из бд
                //modeFigure = "Прямоугольник";
                //modeFigure = "Сложная фигура";
                //modeFigure = "Треугольник";
                CreatePole(modeStatus);
                //CreatePole(modePole);
            }

        }
        public System.Drawing.Image ResizeOrigImg(System.Drawing.Image image, int nWidth, int nHeight)
        {
            int newWidth, newHeight;
            var coefH = (double)nHeight / (double)image.Height;
            var coefW = (double)nWidth / (double)image.Width;
            if (coefW >= coefH)
            {
                newHeight = (int)(image.Height * coefH);
                newWidth = (int)(image.Width * coefH);
            }
            else
            {
                newHeight = (int)(image.Height * coefW);
                newWidth = (int)(image.Width * coefW);
            }

            System.Drawing.Image result = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(image, 0, 0, newWidth, newHeight);
                g.Dispose();
            }
            return result;
        }
        //Создание поля игры
        private void CreatePole(string modeStatus)
        {
            // Создаем массив сегментов установленного размера.
            size = numX * numY;
            setka = new Point[size];
            arr = new int[size];
            arrTrue = new int[size];
            w = panel1.Width / numX;
            h = panel1.Height / numY;
            CreateFigure createFigure = new CreateFigure(pbSegments,Picture,numX,numY,setka,arr,modePole,size,arrTrue,panel2);
            switch (modeFigure)
            {
                case "Прямоугольник":
                    {
                        /*Когда будешь связывать с бд , то всё ,что ниже можешь удалить,
                        т.к. pbSegments для поля создаются и перемешиваются на стороне админа
                        так что просто присвой
                        pbSegments = значение и бд
                        естественно учитывая сохранение это или новая игра*/
                        pbSegments = createFigure.CreateRectangle(w, h, panel1);
                        if (modeStatus == "Сохранение")
                        {
                            //Комменты вани
                            //наверн передаём туда поле из бд
                            OpenGame();
                        }
                    }
                    break;
                case "Сложная фигура":
                    {
                       
                        pbSegments = createFigure.CreateHard(w, h, panel1);
                        if (modeStatus == "Сохранение")
                        {
                            //Комменты вани
                            //наверн передаём туда поле из бд
                            OpenGame();
                        }
                    }
                    break;
                case "Треугольник":
                    {
                        pbSegments = createFigure.CreateTriangle(w, h, panel1);
                        if (modeStatus == "Сохранение")
                        {
                            //Комменты вани
                            //наверн передаём туда поле из бд
                            OpenGame();
                        }
                    }
                    break;
            }
            if (modePole != "На поле" && modeStatus != "Сохранение")
            {
                MixedSegments();
            }
            if (modePole == "На поле" && modeStatus == "Новая игра")
            {
                string[,] poleSave = new string[,] { };
                int length = size;
                PointConverter pointConverter = new PointConverter();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                //я не уверен в этом преобразовании
                                pbSegments[i].Location = (Point)pointConverter.ConvertFromString(poleSave[i, j]);
                                break;
                        }
                    }
                }
            }
            Event();
        }
        /// <summary>
        /// Перемешивание сегментов
        /// </summary>
        private void MixedSegments()
        {
            if (Picture == null) return;

            // Создаем объект генерирования псевдослучайных чисел,
            // для различного набора случайных чисел инициализацию
            // объекта Random производим от счетчика количества
            // миллисекунд прошедших со времени запуска операционной системы.
            Random rand = new Random(Environment.TickCount);
            for (int i = 0; i < pbSegments.Length; i++)
            {
                pbSegments[i].Visible = true;
                int temp = rand.Next(0, pbSegments.Length);
                Point ptR = pbSegments[temp].Location;
                Point ptI = pbSegments[i].Location;
                pbSegments[i].Location = ptR;
                pbSegments[temp].Location = ptI;
                // Бордюр чтобы видно сегменты
                pbSegments[i].BorderStyle = BorderStyle.FixedSingle;

            }
        }
        //События
        private void Event()
        {
            if (Picture == null) return;


            for (int i = 0; i < pbSegments.Length; i++)
            {

                pbSegments[i].MouseDown += pictureBox_MouseDown;
                pbSegments[i].MouseMove += pictureBox_MouseMove;
                pbSegments[i].MouseUp += pictureBox_MouseUp;
            }
            switch (scoreMode)
            {
                case "На время":
                    Srart();
                    break;
                case "На очки":
                    label1.Text = scoring.ToString(); ;
                    break;
            }

        }
        //Нажатие кнопки
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = sender as PictureBox;
                mousePos = e.Location;
                move = true;
                //смена родителя
                startCordImage = pb.Location;
                if (pb.Parent == panel2)
                {
                    //pb.Parent.Controls.Remove(pb);
                    pb.Parent = panel1;
                    startCordImage.X = +(w * numX + 25);
                }
            }
        }
        //Перемещение мыши
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (move)
            {
                pb.BringToFront();
                int dx = e.X - mousePos.X;
                int dy = e.Y - mousePos.Y;
                pb.Location = new Point(pb.Left + dx, pb.Top + dy);

            }
        }
        //Отпускание мыши
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (move)
            {
                move = false;
                switch (modePole)
                {
                    case "На поле":
                        TranslationSegment(sender as PictureBox);
                        break;
                    case "На линии":
                        TranslationSegmentLine(sender as PictureBox);
                        break;
                    case "В куче":
                        TranslationSegmentLine(sender as PictureBox);
                        break;
                }
            }
        }
        /// <summary>
        /// Перемещение сегмента на поле
        /// </summary>
        /// <param name="pb">активный сегмент</param>
        private void TranslationSegment(PictureBox pb)
        {
            for (int i = 0; i < pbSegments.Length; i++)
            {
                if (((pb.Location.X >= pbSegments[i].Location.X - w / 2 && pb.Location.X <= pbSegments[i].Location.X + w / 2) &&
                     (pb.Location.Y >= pbSegments[i].Location.Y - h / 2 && pb.Location.Y <= pbSegments[i].Location.Y + h / 2) && (int)pb.Tag == (int)pbSegments[i].Tag))
                {

                    if (((pb.Location.X >= startCordImage.X - w / 2 && pb.Location.X <= startCordImage.X + w / 2) &&
                     (pb.Location.Y >= startCordImage.Y - h / 2 && pb.Location.Y <= startCordImage.Y + h / 2)) || ((pb.Location.X + w / 2 > panel1.Width || pb.Location.X + w / 2 < 0) || (pb.Location.Y + h / 2 > panel1.Height || pb.Location.Y + h / 2 < 0) || pb.Location.X + w / 2 > w * numX))
                    {
                        pb.Location = startCordImage;
                    }
                    else
                    {
                        Point ptemp = pbSegments[i].Location;
                        pbSegments[i].Location = startCordImage;
                        pb.Location = ptemp;
                        if (scoreMode == "На очки")
                        {
                            ScoringPoints(pb, pbSegments[i]);
                        }
                    }
                }

            }

            CheckingTheBuild();
        }


        /// <summary>
        /// Перемещение сегмента с линией выдачи
        /// </summary>
        /// <param name="pb">активный сегмент</param>
        private void TranslationSegmentLine(PictureBox pb)
        {
            for (int i = 0; i < pbSegments.Length; i++)
            {
                if ((int)pb.Tag == (int)pbSegments[i].Tag)
                {
                    if ((pb.Location.X + w / 2 > panel1.Width || pb.Location.X + w / 2 < 0) || (pb.Location.Y + h / 2 > panel1.Height || pb.Location.Y + h / 2 < 0) || pb.Location.X + w / 2 > w * numX)
                    {
                        if (startCordImage.X >= w * numX)
                        {
                            pb.Parent = panel2;
                            startCordImage.X = startCordImage.X - (w * numX);
                            pb.Location = startCordImage;
                        }
                        else
                        {
                            pb.Location = startCordImage;
                        }
                    }
                    else
                    {
                        if (((pb.Location.X >= setka[i].X - w / 2 && pb.Location.X < setka[i].X + w / 2) &&
                             (pb.Location.Y >= setka[i].Y - h / 2 && pb.Location.Y <= setka[i].Y + h / 2)))

                        {
                            if (((pb.Location.X >= startCordImage.X - w / 2 && pb.Location.X <= startCordImage.X + w / 2) &&
                             (pb.Location.Y >= startCordImage.Y - h / 2 && pb.Location.Y <= startCordImage.Y + h / 2)))
                            {

                                pb.Location = startCordImage;

                            }
                            else
                            {
                                int index = Array.IndexOf(arr, pb.TabIndex);
                                if (arr[i] == -1 && index == -1)
                                {
                                    pb.Location = setka[i];
                                    arr[i] = pb.TabIndex;
                                }
                                else
                                {
                                    if (startCordImage.X >= w * numX)
                                    {

                                        pbSegments[arr[i]].Parent = panel2;
                                        startCordImage.X = startCordImage.X - (w * numX);
                                        pbSegments[arr[i]].Location = startCordImage;
                                        pb.Location = setka[i];
                                        arr[i] = pb.TabIndex;
                                    }
                                    else
                                    {
                                        pb.Location = setka[i];
                                        if (arr[i] != -1)
                                        {
                                            pbSegments[arr[i]].Location = startCordImage;

                                        }
                                        int elem = arr[i];
                                        //int index = Array.IndexOf(arr, pb.TabIndex);
                                        arr[index] = elem;
                                        arr[i] = pb.TabIndex;
                                    }
                                }
                                if (scoreMode == "На очки")
                                {
                                    ScoringPoints(pb, pbSegments[i]);
                                }
                            }
                        }
                    }

                }
            }
            CheckingTheBuild();
        }
        //метод проверки сборки
        private void CheckingTheBuild()
        {
            for (int j = 0; j < pbSegments.Length; j++)
            {
                Point point = setka[j];
                if (pbSegments[j].Location != point)
                {
                    return;
                }
            }

            PuzzleSolved();
        }

        private void PuzzleSolved()
        {
            Stop();
            player = new SoundPlayer();
            player.Stream = Properties.Resources.победа;
            player.Play();

            for (int m = 0; m < pbSegments.Length; m++)
            {
                pbSegments[m].BorderStyle = BorderStyle.None;
            }

            BeginProcessRecord();

            MessageBox.Show("Вы собрали пазл!");
            new UserForm(_userId).Show();
            this.Dispose();
        }

        private async void BeginProcessRecord()
        {
            var record = new Record()
            {
                Id = Guid.NewGuid(),
                GameId = _gameId,
                UserId = _userId,
                Score = scoreMode == "На очки"
                    ? scoring
                    : _notScore,
                Time = scoreMode == "На время"
                    ? DateTime.Today.Add(this.StopWatch.Elapsed)
                    : DateTime.MinValue
            };

            try
            {
                var recordHandler = new RecordHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
                await recordHandler.ProcessRecord(record);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = ResizeOrigImg(Picture, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.BringToFront();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            if (pictureBox2.Visible == false)
            {
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

      

        private async void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
            var dialogResult = MessageBox.Show(
                "Вы хотите сохранить текущий прогресс?",
                "Закрытие игры",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {

                var save = new Save()
                {
                    Id = Guid.NewGuid(),
                    GameId = _gameId,
                    UserId = _userId,
                    Data = JsonConvert.SerializeObject(SaveGame())
                };

                try
                {
                    await _saveHandler.AddSave(save);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Не удалось сохранить игру.");
                }
            }

            new UserForm(_userId).Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.AccessibleName == "вкл")
            {
                pictureBox3.Image = Properties.Resources.выкл;
                pictureBox3.AccessibleName = "выкл";
                player.Stop();
            }
            else
            {
                player.PlayLooping();
                pictureBox3.Image = Properties.Resources.вкл;
                pictureBox3.AccessibleName = "вкл";
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.AccessibleName == "пауза")
            {
                pictureBox4.Image = Properties.Resources.пуск;
                pictureBox4.AccessibleName = "пуск";
                Stop();
                DialogResult result = MessageBox.Show(
                            "Сохранить игру?",
                            "Сообщение",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    SaveGame();
                }
            }
            else
            {
                pictureBox4.Image = Properties.Resources.пауза;
                pictureBox4.AccessibleName = "пауза";
                Srart();
            }
        }

        public string[,] SaveGame()
        {
            int length = size;
            string[,] poleSave = new string[50, 5];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (j)
                    {
                        case 0:
                            poleSave[i, j] = pbSegments[i].Location.ToString();
                            break;
                        case 1:
                            poleSave[i, j] = pbSegments[i].Parent.ToString();
                            break;
                        case 2:
                            poleSave[i, j] = pbSegments[i].TabIndex.ToString();
                            break;
                        case 3:
                            poleSave[i, j] = pbSegments[i].Tag.ToString();
                            break;
                        case 4:
                            poleSave[i, j] = setka[i].ToString();
                            break;
                    }
                }
            }
            return poleSave;

        }

        private int GetValueX(string str)
        {
            var leftBorderIndex = str.IndexOf("=") + 1;
            var rightBorderIndex = str.IndexOf(",");
            return int.Parse(str.Substring(leftBorderIndex, rightBorderIndex - leftBorderIndex));
        }

        private int GetValueY(string str)
        {
            var leftBorderIndex = str.LastIndexOf("=") + 1;
            var rightBorderIndex = str.IndexOf('}');

            return int.Parse(str.Substring(leftBorderIndex, rightBorderIndex - leftBorderIndex));
        }

        public void OpenGame()
        {
            //Комменты вани
            //Здесь наоборот присвой poleSave значениеие из бд
            int length = size;
            PointConverter pointConverter = new PointConverter();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (j)
                    {
                        case 0:
                            {
                                pbSegments[i].Location = new Point(GetValueX(pole[i, j]), GetValueY(pole[i, j]));
                            }
                            //я не уверен в этом преобразовании
                            break;
                        case 1:
                            {
                                //Проверь ,что содержиться в poleSave[i, j]
                                //Возможно там будет боле длинное значение
                                if (pole[i, j] == "System.Windows.Forms.Panel, BorderStyle: System.Windows.Forms.BorderStyle.None")
                                {
                                    pbSegments[i].Parent = panel1;
                                }
                                else
                                {
                                    pbSegments[i].Parent = panel2;
                                }
                            }
                            break;
                        case 2:
                            pbSegments[i].TabIndex = int.Parse(pole[i, j]);
                            break;
                        case 3:
                            pbSegments[i].Tag = int.Parse(pole[i, j]);
                            break;
                        case 4:
                            {
                                Point point = new Point(GetValueX(pole[i, j]), GetValueY(pole[i, j]));
                                setka[i] = point;
                            }
                            break;
                    }
                }
            }
        }
        public GameForm(
            int assembleMode,
            int pieceForm,
            int horizontalPiece,
            int verticalPiece,
            string scoreMode,
            string modeStatus,
            string[,] pole,
            Guid userId,
            Guid gameId)
        {
            InitializeComponent();
            //комменты вани
            //поле говорящие сохранение это или нет
            // modeStatus
            this.modePole = GetModePole(assembleMode);
            this.modeFigure = GetModeFigure(pieceForm);
            numX = horizontalPiece;
            numY = verticalPiece;
            this.pole = pole;
            this.scoreMode = scoreMode;
            this.modeStatus = modeStatus;
            _saveHandler = new SaveHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
            _userId = userId;
            _gameId = gameId;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan elapsed = this.StopWatch.Elapsed;
            label1.Text = string.Format("{0:00}:{1:00}:{2:00}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
        }

        internal CreateFigure CreateFigure
        {
            get => default;
            set
            {
            }
        }

        public AboutUser AboutUser
        {
            get => default;
            set
            {
            }
        }
    }
}
