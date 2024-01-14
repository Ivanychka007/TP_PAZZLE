using System.Drawing.Drawing2D;


namespace University.Puzzle.UI
{
    internal class CreatePath
    {
        private int w;
        private int h;
        public CreatePath(int width, int hieght)
        { 
            this.w = width;
            this.h = hieght;
        }
        //Левый верхний 1
        public GraphicsPath createLT()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w, 0); // Верхняя горизонтальная линия
            path.AddLine(w, 0, w, h / 3); // Правая вертикальная линия
            path.AddBezier(w, h / 3, w * 5 / 4, h * 4 / 10, w * 5 / 4, h * 6 / 10, w, h * 2 / 3);
            path.AddLine(w, h * 2 / 3, w, h);
            path.AddLine(w, h, w * 2 / 3, h); // Нижняя горизонтальная линия
            path.AddBezier(w * 2 / 3, h, w * 6 / 10, h * 5 / 4, w * 4 / 10, h * 5 / 4, w / 3, h);
            path.AddLine(w / 3, h, 0, h);
            path.AddLine(0, h, 0, 0); // Левая вертикальная линия

            return path;
        }
        //Верхний серединный 2
        public GraphicsPath createST()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w, 0); // Верхняя горизонтальная линия
            path.AddLine(w, 0, w, h / 3); // Правая вертикальная линия
            path.AddBezier(w, h / 3, w * 5 / 4, h * 4 / 10, w * 5 / 4, h * 6 / 10, w, h * 2 / 3);
            path.AddLine(w, h * 2 / 3, w, h);
            path.AddLine(w, h, w * 2 / 3, h); // Нижняя горизонтальная линия
            path.AddBezier(w * 2 / 3, h, w * 6 / 10, h * 5 / 4, w * 4 / 10, h * 5 / 4, w / 3, h);
            path.AddLine(w / 3, h, 0, h);
            path.AddLine(0, h, 0, h * 2 / 3); // Левая вертикальная линия
            path.AddBezier(0, h * 2 / 3, w / 4, h * 6 / 10, w / 4, h * 4 / 10, 0, h / 3);
            path.AddLine(0, h / 3, 0, 0);
            return path;
        }

        //Верхний правый 3
        public GraphicsPath createRT()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w, 0); // Верхняя горизонтальная линия
            path.AddLine(w, 0, w, h); // Правая вертикальная линия;
            path.AddLine(w, h, w * 2 / 3, h); // Нижняя горизонтальная линия
            path.AddBezier(w * 2 / 3, h, w * 6 / 10, h * 5 / 4, w * 4 / 10, h * 5 / 4, w / 3, h);
            path.AddLine(w / 3, h, 0, h);
            path.AddLine(0, h, 0, h * 2 / 3); // Левая вертикальная линия
            path.AddBezier(0, h * 2 / 3, w / 4, h * 6 / 10, w / 4, h * 4 / 10, 0, h / 3);
            path.AddLine(0, h / 3, 0, 0);
            return path;
        }

        //Срединный левый 4
        public GraphicsPath createLS()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w / 3, 0); // Верхняя горизонтальная линия
            path.AddBezier(w / 3, 0, w * 4 / 10, h / 4, w * 6 / 10, h / 4, w * 2 / 3, 0);
            path.AddLine(w * 2 / 3, 0, w, 0);
            path.AddLine(w, 0, w, h / 3); // Правая вертикальная линия
            path.AddBezier(w, h / 3, w * 5 / 4, h * 4 / 10, w * 5 / 4, h * 6 / 10, w, h * 2 / 3);
            path.AddLine(w, h * 2 / 3, w, h);
            path.AddLine(w, h, w * 2 / 3, h); // Нижняя горизонтальная линия
            path.AddBezier(w * 2 / 3, h, w * 6 / 10, h * 5 / 4, w * 4 / 10, h * 5 / 4, w / 3, h);
            path.AddLine(w / 3, h, 0, h);
            path.AddLine(0, h, 0, 0); // Левая вертикальная линия
            return path;
        }
        //Срединный срединный 5
        public GraphicsPath createSS()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w / 3, 0); // Верхняя горизонтальная линия
            path.AddBezier(w / 3, 0, w * 4 / 10, h / 4, w * 6 / 10, h / 4, w * 2 / 3, 0);
            path.AddLine(w * 2 / 3, 0, w, 0);
            path.AddLine(w, 0, w, h / 3); // Правая вертикальная линия
            path.AddBezier(w, h / 3, w * 5 / 4, h * 4 / 10, w * 5 / 4, h * 6 / 10, w, h * 2 / 3);
            path.AddLine(w, h * 2 / 3, w, h);
            path.AddLine(w, h, w * 2 / 3, h); // Нижняя горизонтальная линия
            path.AddBezier(w * 2 / 3, h, w * 6 / 10, h * 5 / 4, w * 4 / 10, h * 5 / 4, w / 3, h);
            path.AddLine(w / 3, h, 0, h);
            path.AddLine(0, h, 0, h * 2 / 3); // Левая вертикальная линия
            path.AddBezier(0, h * 2 / 3, w / 4, h * 6 / 10, w / 4, h * 4 / 10, 0, h / 3);
            path.AddLine(0, h / 3, 0, 0);
            return path;

        }
        //Срединный правый 6
        public GraphicsPath createRS()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w / 3, 0); // Верхняя горизонтальная линия
            path.AddBezier(w / 3, 0, w * 4 / 10, h / 4, w * 6 / 10, h / 4, w * 2 / 3, 0);
            path.AddLine(w * 2 / 3, 0, w, 0);
            path.AddLine(w, 0, w, h); // Правая вертикальная линия
            path.AddLine(w, h, w * 2 / 3, h); // Нижняя горизонтальная линия
            path.AddBezier(w * 2 / 3, h, w * 6 / 10, h * 5 / 4, w * 4 / 10, h * 5 / 4, w / 3, h);
            path.AddLine(w / 3, h, 0, h);
            path.AddLine(0, h, 0, h * 2 / 3); // Левая вертикальная линия
            path.AddBezier(0, h * 2 / 3, w / 4, h * 6 / 10, w / 4, h * 4 / 10, 0, h / 3);
            path.AddLine(0, h / 3, 0, 0);
            return path;

        }
        //Нижний правый 7
        public GraphicsPath createLB()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w / 3, 0); // Верхняя горизонтальная линия
            path.AddBezier(w / 3, 0, w * 4 / 10, h / 4, w * 6 / 10, h / 4, w * 2 / 3, 0);
            path.AddLine(w * 2 / 3, 0, w, 0);
            path.AddLine(w, 0, w, h / 3); // Правая вертикальная линия
            path.AddBezier(w, h / 3, w * 5 / 4, h * 4 / 10, w * 5 / 4, h * 6 / 10, w, h * 2 / 3);
            path.AddLine(w, h * 2 / 3, w, h);
            path.AddLine(w, h, 0, h); // Нижняя горизонтальная линия
            path.AddLine(0, h, 0, 0); // Левая вертикальная линия
            return path;

        }
        //Нижний срединный 8
        public GraphicsPath createSB()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w / 3, 0); // Верхняя горизонтальная линия
            path.AddBezier(w / 3, 0, w * 4 / 10, h / 4, w * 6 / 10, h / 4, w * 2 / 3, 0);
            path.AddLine(w * 2 / 3, 0, w, 0);
            path.AddLine(w, 0, w, h / 3); // Правая вертикальная линия
            path.AddBezier(w, h / 3, w * 5 / 4, h * 4 / 10, w * 5 / 4, h * 6 / 10, w, h * 2 / 3);
            path.AddLine(w, h * 2 / 3, w, h);
            path.AddLine(w, h, 0, h); // Нижняя горизонтальная линия
            path.AddLine(0, h, 0, h * 2 / 3); // Левая вертикальная линия
            path.AddBezier(0, h * 2 / 3, w / 4, h * 6 / 10, w / 4, h * 4 / 10, 0, h / 3);
            path.AddLine(0, h / 3, 0, 0);
            return path;

        }
        //Нижний правый 9
        public GraphicsPath createRB()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w / 3, 0); // Верхняя горизонтальная линия
            path.AddBezier(w / 3, 0, w * 4 / 10, h / 4, w * 6 / 10, h / 4, w * 2 / 3, 0);
            path.AddLine(w * 2 / 3, 0, w, 0);
            path.AddLine(w, 0, w, h); // Правая вертикальная линия
            path.AddLine(w, h, 0, h); // Нижняя горизонтальная линия
            path.AddLine(0, h, 0, h * 2 / 3); // Левая вертикальная линия
            path.AddBezier(0, h * 2 / 3, w / 4, h * 6 / 10, w / 4, h * 4 / 10, 0, h / 3);
            path.AddLine(0, h / 3, 0, 0);
            return path;

        }
        //Прямоугольник
        public GraphicsPath createRectangle()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w, 0); // Верхняя горизонтальная линия
            path.AddLine(w, 0, w, h);  // Правая вертикальная линия
            path.AddLine(w, h, 0, h); // Нижняя горизонтальная линия
            path.AddLine(0, h, 0, 0); // Левая вертикальная линия
            return path;

        }
        //Треугольник нижний
        public GraphicsPath createTriangleL()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w, h); // Диагональная линия с лево на право
            path.AddLine(w, h, 0, h); // Нижняя горизонтальная линия
            path.AddLine(0, h, 0, 0); // Левая вертикальная линия
            return path;

        }
        //Треугольник верхний
        public GraphicsPath createTriangleH()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, w, 0); // Верхняя горизонтальная линия
            path.AddLine(w, 0, w, h);  // Правая вертикальная линия
            path.AddLine(w, h, 0, 0); // Диагональная линия с право на лево     
            return path;

        }
    }
}
