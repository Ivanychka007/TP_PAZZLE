using LinqToDB.Mapping;
using System;
using System.IO;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: Image
    /// <summary>
    /// Изображение.
    /// </summary>
    [Table(Name = "Image")]
    public class Image
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Бинарное представление изображения.
        /// </summary>
        [Column(Name = "Data")]
        public Stream Data { get; set; }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="name">Имя изображения.</param>
        /// <param name="data">Файловый поток.</param>
        public Image(string name, Stream data)
        {
            ObjectValidator.CheckNullReference(data);
            TextValidator.IsValidString(name);

            Id = Guid.NewGuid();
            Name = name;
            Data = data;
        }
        #endregion
    }
    #endregion
}
