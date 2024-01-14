using System;
using System.IO;
using System.Linq;

namespace University.Puzzle.ValidationLibrary
{
    #region Class: FileValidator
    /// <summary>
    /// Содержит методы для валидации файлов.
    /// </summary>
    public static class FileValidator
    {
        #region Fields: Private
        /// <summary>
        /// Разрешенные форматы изображений.
        /// </summary>
        private static readonly string[] _allowedExtension = new string[] { ".jpeg", ".jpg" };
        #endregion

        #region Methods: Public
        /// <summary>
        /// Проверяет по названию файла его расширение.
        /// </summary>
        /// <param name="fileName">Название файла.</param>
        public static void CheckJpegExtension(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName);

            if (!_allowedExtension.Contains(fileExtension))
            {
                throw new ArgumentException("Файл должен быть расширения *.jpeg, *.jpg ", nameof(fileName));
            }
        }

        /// <summary>
        /// Проверяет наличие файла по пути.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <exception cref="ArgumentException">Файл не существует.</exception>
        public static void CheckFileExists(string filePath)
        {
            TextValidator.IsValidString(filePath);

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("Файл не существует", nameof(filePath));
            }
        }
        #endregion
    }
    #endregion
}
