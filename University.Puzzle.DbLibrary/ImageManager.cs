using LinqToDB;
using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.DbLibrary
{
    #region Class: ImageManager
    /// <summary>
    /// Взаимодействует с таблицей изображений в базе данных.
    /// </summary>
    public class ImageManager
    {
        #region Fields: Private
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Максимальное количество изображений в галереи.
        /// </summary>
        private readonly int _imagesAmountLimit = 100;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Добавляет изображение в таблицу "Image".
        /// </summary>
        /// <param name="image">Изображение.</param>
        public void AddImage(Image image)
        {
            ObjectValidator.CheckNullReference(image);
            CheckImageNameExists(image.Name);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                if (database.Image.Count() == _imagesAmountLimit)
                {
                    throw new ArgumentException($"Достигнут лимит изображений в {_imagesAmountLimit} картинок в галереи.");
                }

                database.Insert(image);
            }
        }

        /// <summary>
        /// Возвращает изображение по названию.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>Изображение.</returns>
        public Image GetImage(string imageName)
        {
            Image image = null;
            var getImageDataQuery = $"SELECT [Data] FROM [Image] WHERE [Name] = '{imageName}'";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(getImageDataQuery, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        image = new Image(imageName, new MemoryStream((byte[])reader[0]));
                    }

                    reader.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }

            return image;
        }

        /// <summary>
        /// Возвращает название изображения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор изображения.</param>
        /// <returns>Название изображения.</returns>
        public string GetImageName(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Image.Where(x => x.Id == id)
                    .Select(x => x.Name)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Возвращает список названий изображений.
        /// </summary>
        /// <returns>Список идентификаторов изображений.</returns>
        public string[] GetImagesNameList()
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Image
                    .Select(x => x.Name)
                    .ToArray();
            }
        }

        /// <summary>
        /// Удаляет изображение по названию из таблицы "Image".
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>Количество удаленных записей./returns>
        public int DeleteImage(string imageName)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Image
                    .Where(x => x.Name.Equals(imageName))
                    .Delete();
            }
        }

        /// <summary>
        /// Возвращает идентификатор изображения по названию.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>Идентификатор.</returns>
        public Guid GetImageId(string imageName)
        {
            TextValidator.IsValidString(imageName);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Image
                    .Where(x => x.Name.Equals(imageName))
                    .Select(x => x.Id)
                    .FirstOrDefault();
            }
        }
        #endregion

        #region Methods: Private
        /// <summary>
        /// Проверяет наличие названия изображения в таблице "Image".
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <exception cref="ArgumentException">Изображение с заданным названием уже существует.</exception>
        private void CheckImageNameExists(string imageName)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                var loginExists = database
                    .Image
                    .Any(x => x.Name == imageName);

                if (loginExists)
                {
                    throw new ArgumentException("Изображение с заданным названием уже существует.");
                }
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public ImageManager(string connectionString)
        {
            TextValidator.IsValidString(connectionString);

            _connectionString = connectionString;
        }
        #endregion
    }
    #endregion
}
