using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace University.Puzzle.UI
{
    internal class CreateFigure
    {
        private PictureBox[] pbSegments;
        private Bitmap Picture;
        private int numX ;
        private int numY ;
        private Point[] setka;
        private int[] arr;
        private string modePole;
        private int size;
        private Random r;
        //Массив для проверки повторных перестановок
        private int[] arrTrue;
        Panel panel2;

        public CreateFigure(
           PictureBox[] pbSegments,
           Bitmap Picture,
           int numX,
           int numY,
           Point[] setka,
           int[] arr,
           string modePole,
           int size,
           int[] arrTrue,
           Panel panel2)
        {
            this.pbSegments = pbSegments;
            this.Picture = Picture;
            this.numX = numX;
            this.numY = numY;
            this.setka = setka;
            this.arr = arr;
            this.modePole = modePole;
            this.size = size;
            this.arrTrue = arrTrue;
            this.panel2 = panel2;
        }

        internal CreatePath CreatePath
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Создание треугольного пазла
        /// </summary>
        /// <param name="modePole"></param>
        /// <param name="r"></param>
        public PictureBox[] CreateTriangle(int width, int height, Panel mainpanel)
        {
            r = new Random(Environment.TickCount);
            pbSegments = new PictureBox[size];
            bool line = false;
            int countYpb = 0;
            int wp = Picture.Width / numX;
            int hp = Picture.Height / numY;
            if (modePole == "На линии" || modePole == "В куче")
            {
                //Создание панели
                panel2 = new Panel();
                panel2.Dock = DockStyle.Right;
                panel2.Width = 230;
                panel2.AutoScroll = true;
                panel2.BackColor = Color.FromArgb(100, 139, 159, 189);
                mainpanel.Controls.Add(panel2);
                //габаритные размеры
                width = (mainpanel.Width - panel2.Width) / numX;
                height = mainpanel.Height / numY;
                line = true;
            }
            int countX = 0;
            int countY = 0;
            int count = 0;
            GraphicsPath path = null;
            for (int i = 0; i < pbSegments.Length; i++)
            {
                // Размеры и координаты размещения созданного прямоугольника.
                pbSegments[i] = new PictureBox
                {
                    Width = width,
                    Height = height,
                    Left = countX * width,
                    Top = countY * height
                };
                // Запомним начальные координаты прямоугольника для
                // восстановления перемешанной картинки,
                // и определения полной сборки картинки.
                Point pt = new Point();
                pt.X = pbSegments[i].Left;
                pt.Y = pbSegments[i].Top;
                setka[i] = pt;
                pbSegments[i].TabIndex = i;
                if (line)
                {
                    arr[i] = -1;
                    arrTrue[i] = -1;
                    pbSegments[i].Parent = panel2;
                    Point ptpb = new Point();
                    if (modePole == "На линии")
                    {
                        ptpb.X = 25;
                        ptpb.Y = height * countYpb + 10 * countYpb;
                        pbSegments[i].Location = ptpb;
                        // Считаем прямоугольники по рядам и столбцам.
                        countYpb++;
                    }
                    else
                    {
                        double x = r.NextDouble() * 7 + 1;
                        double y = r.NextDouble() * 0.3 + 0.1;
                        ptpb.X = (int)Math.Round(5 * x);
                        ptpb.Y = (int)Math.Round(height * countYpb * y + 10 * y);
                        pbSegments[i].Location = ptpb;
                        countYpb++;

                    }
                }
                else
                {
                    pbSegments[i].Location = pt;
                    pbSegments[i].Parent = mainpanel;
                }
                pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp, hp), Picture.PixelFormat);
                count++;
                CreatePath createPath = new CreatePath(width, height);
                if (count == 1)
                {
                    pbSegments[i].Tag = 1;
                    path = createPath.createTriangleL();
                }
                if (count == 2)
                {
                    pbSegments[i].Tag = 2;
                    path = createPath.createTriangleH();
                    count = 0;
                    countX++;
                }

                Region region = new Region(path);
                pbSegments[i].Region = region;
                if (countX == numX)
                {
                    countX = 0;
                    countY++;
                }
                pbSegments[i].BorderStyle = BorderStyle.FixedSingle;
                pbSegments[i].SizeMode = PictureBoxSizeMode.StretchImage;

            }
            return pbSegments;
        }
        /// <summary>
        /// Создание прямоугольного пазла
        /// </summary>
        /// <param name="modePole"></param>
        /// <param name="r"></param>
        public PictureBox[] CreateRectangle(int width, int height, Panel mainpanel)
        {
            r = new Random(Environment.TickCount);
            pbSegments = new PictureBox[size];
            bool line = false;
            int countYpb = 0;
            int wp = Picture.Width / numX;
            int hp = Picture.Height / numY;
            if (modePole == "На линии" || modePole == "В куче")
            {
                //Создание панели
                panel2 = new Panel();
                panel2.Dock = DockStyle.Right;
                panel2.Width = 230;
                panel2.AutoScroll = true;
                panel2.BackColor = Color.FromArgb(100, 139, 159, 189);
                mainpanel.Controls.Add(panel2);
                //габаритные размеры
                width = (mainpanel.Width - panel2.Width) / numX;
                height = mainpanel.Height / numY;
                line = true;
            }
            int countX = 0;
            int countY = 0;
            GraphicsPath path;
            for (int i = 0; i < pbSegments.Length; i++)
            {
                // Размеры и координаты размещения созданного прямоугольника.
                pbSegments[i] = new PictureBox
                {
                    Width = width,
                    Height = height,
                    Left = countX * width,
                    Top = countY * height
                };
                // Запомним начальные координаты прямоугольника для
                // восстановления перемешанной картинки,
                // и определения полной сборки картинки.
                Point pt = new Point();
                pt.X = pbSegments[i].Left;
                pt.Y = pbSegments[i].Top;
                pbSegments[i].TabIndex = i;
                setka[i] = pt;
                if (line)
                {
                    arr[i] = -1;
                    arrTrue[i] = -1;
                    pbSegments[i].Parent = panel2;
                    Point ptpb = new Point();

                    if (modePole == "На линии")
                    {
                        ptpb.X = 25;
                        ptpb.Y = height * countYpb + 10 * countYpb;
                        pbSegments[i].Location = ptpb;
                        // Считаем прямоугольники по рядам и столбцам.
                        countYpb++;
                    }
                    else
                    {
                        double x = r.NextDouble() * 7 + 1;
                        double y = r.NextDouble() * 0.3 + 0.1;
                        ptpb.X = (int)Math.Round(5 * x);
                        ptpb.Y = (int)Math.Round(height * countYpb * y + 10 * y);
                        pbSegments[i].Location = ptpb;
                        countYpb++;

                    }
                }
                else
                {
                    pbSegments[i].Location = pt;
                    pbSegments[i].Parent = mainpanel;
                }
                pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp, hp), Picture.PixelFormat);
                countX++;
                pbSegments[i].Tag = 0;
                CreatePath createPath = new CreatePath(width, height);
                path = createPath.createRectangle();
                Region region = new Region(path);
                pbSegments[i].Region = region;
                if (countX == numX)
                {
                    countX = 0;
                    countY++;
                }
                pbSegments[i].BorderStyle = BorderStyle.FixedSingle;
                pbSegments[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            return pbSegments;
        }
        /// <summary>
        /// Создание сложного пазла 
        /// </summary>
        /// <param name="modePole"></param>
        /// <param name="r"></param>
        public PictureBox[] CreateHard(int width, int height, Panel mainpanel)
        {
            r = new Random(Environment.TickCount);
            pbSegments = new PictureBox[size];
            bool line = false;
            int countYpb = 0;
            int wp = Picture.Width / numX;
            int hp = Picture.Height / numY;
            if (modePole == "На линии" || modePole == "В куче")
            {
                //Создание панели
                panel2 = new Panel();
                panel2.Dock = DockStyle.Right;
                panel2.Width = 230;
                panel2.AutoScroll = true;
                panel2.BackColor = Color.FromArgb(100, 139, 159, 189);
                mainpanel.Controls.Add(panel2);
                //габаритные размеры
                width = (mainpanel.Width - panel2.Width) / numX;
                height = mainpanel.Height / numY;
                line = true;
            }
            int countX = 0;
            int countY = 0;
            GraphicsPath path;
            for (int i = 0; i < pbSegments.Length; i++)
            {
                // Размеры и координаты размещения созданного прямоугольника.
                pbSegments[i] = new PictureBox
                {
                    Width = width,
                    Height = height,
                    Left = countX * width,
                    Top = countY * height
                };
                // Запомним начальные координаты прямоугольника для
                // восстановления перемешанной картинки,
                // и определения полной сборки картинки.
                Point pt = new Point();
                pt.X = pbSegments[i].Left;
                pt.Y = pbSegments[i].Top;
                setka[i] = pt;
                pbSegments[i].Location = pt;
                pbSegments[i].Parent = mainpanel;
                pbSegments[i].Tag = 0;
                CreatePath createPath = new CreatePath(width, height);
                if (pbSegments[i].Top == 0)
                {
                    if (pbSegments[i].Left == 0)
                    {
                        pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp * 5 / 4, hp * 5 / 4), Picture.PixelFormat);
                        path = createPath.createLT();
                        Region region = new Region(path); //1
                        pbSegments[i].Region = region;
                        pbSegments[i].Width = width * 5 / 4;
                        pbSegments[i].Height = height * 5 / 4;
                    }
                    else
                    {
                        if (pbSegments[i].Left == (numX - 1) * width)
                        {
                            pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp, hp * 5 / 4), Picture.PixelFormat);
                            path = createPath.createRT();
                            Region region = new Region(path); //3
                            pbSegments[i].Region = region;
                            pbSegments[i].Height = height * 5 / 4;
                        }
                        else
                        {
                            pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp * 5 / 4, hp * 5 / 4), Picture.PixelFormat);
                            path = createPath.createST();
                            Region region = new Region(path); //2
                            pbSegments[i].Region = region;
                            pbSegments[i].Width = width * 5 / 4;
                            pbSegments[i].Height = height * 5 / 4;
                        }
                    }
                }
                else
                {
                    if (pbSegments[i].Top == (numY - 1) * height)
                    {
                        if (pbSegments[i].Left == 0)
                        {
                            pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp * 5 / 4, hp), Picture.PixelFormat);
                            path = createPath.createLB();
                            Region region = new Region(path); //7
                            pbSegments[i].Region = region;
                            pbSegments[i].Width = width * 5 / 4;

                        }

                        else
                        {
                            if (pbSegments[i].Left == (numX - 1) * width)
                            {
                                pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp, hp), Picture.PixelFormat);
                                path = createPath.createRB();
                                Region region = new Region(path); //9
                                pbSegments[i].Region = region;
                            }
                            else
                            {
                                pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp * 5 / 4, hp), Picture.PixelFormat);
                                path = createPath.createSB();
                                Region region = new Region(path); //8
                                pbSegments[i].Region = region;
                                pbSegments[i].Width = width * 5 / 4;
                            }
                        }
                    }
                    else
                    {
                        if (pbSegments[i].Left == 0)
                        {
                            pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp * 5 / 4, hp * 5 / 4), Picture.PixelFormat);
                            path = createPath.createLS();
                            Region region = new Region(path); //4
                            pbSegments[i].Region = region;
                            pbSegments[i].Width = width * 5 / 4;
                            pbSegments[i].Height = height * 5 / 4;
                        }
                        else
                        {
                            if (pbSegments[i].Left == (numX - 1) * width)
                            {
                                pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp, hp * 5 / 4), Picture.PixelFormat);
                                path = createPath.createRS();
                                Region region = new Region(path); //6
                                pbSegments[i].Region = region;
                                pbSegments[i].Height = height * 5 / 4;
                            }
                            else
                            {
                                pbSegments[i].Image = Picture.Clone(new RectangleF(countX * wp, countY * hp, wp * 5 / 4, hp * 5 / 4), Picture.PixelFormat);
                                path = createPath.createSS();
                                Region region = new Region(path); //5
                                pbSegments[i].Region = region;
                                pbSegments[i].Width = width * 5 / 4;
                                pbSegments[i].Height = height * 5 / 4;
                            }
                        }
                    }
                }
                pbSegments[i].TabIndex = i;
                if (line)
                {
                    arr[i] = -1;
                    arrTrue[i] = -1;
                    pbSegments[i].Parent = panel2;
                    Point ptpb = new Point();
                    if (modePole == "На линии")
                    {
                        ptpb.X = 25;
                        ptpb.Y = height * countYpb + 10 * countYpb;
                        pbSegments[i].Location = ptpb;
                        // Считаем прямоугольники по рядам и столбцам.
                        countYpb++;
                    }
                    else
                    {
                        double x = r.NextDouble() * 7 + 1;
                        double y = r.NextDouble() * 0.3 + 0.1;
                        ptpb.X = (int)Math.Round(5 * x);
                        ptpb.Y = (int)Math.Round(height * countYpb * y + 10 * y);
                        pbSegments[i].Location = ptpb;
                        countYpb++;

                    }
                }

                countX++;
                if (countX == numX)
                {
                    countX = 0;
                    countY++;
                }

                pbSegments[i].BorderStyle = BorderStyle.FixedSingle;
                pbSegments[i].SizeMode = PictureBoxSizeMode.StretchImage;

            }
            return pbSegments;
        }
    }
}
