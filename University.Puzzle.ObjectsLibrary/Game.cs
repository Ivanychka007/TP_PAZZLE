using LinqToDB.Mapping;
using System;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: Game
    /// <summary>
    /// Сущность "Игра".
    /// </summary>
    public class Game
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор изображения.
        /// </summary>
        [Column(Name = "ImageId")]
        public Guid ImageId { get; set; }

        /// <summary>
        /// Идентификатор сложности.
        /// </summary>
        [Column(Name = "DifficultyId")]
        public Guid DifficultyId { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Пресет для сборкина поле.
        /// </summary>
        [Column(Name = "Preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Изображение.
        /// </summary>
        [Association(ThisKey = "ImageId", OtherKey = "Id")]
        public Image Image { get; set; }

        /// <summary>
        /// Сложность.
        /// </summary>
        [Association(ThisKey = "DifficultyId", OtherKey = "Id")]
        public Difficulty Difficulty { get; set; }
        #endregion
    }
    #endregion
}
