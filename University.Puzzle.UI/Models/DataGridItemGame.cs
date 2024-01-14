using System;

namespace University.Puzzle.UI.Models
{
    #region Class: DataGridItemGame
    /// <summary>
    /// Элемент игры для вывода в DataGridView.
    /// </summary>
    public class DataGridItemGame
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id {  get; set; } 

        /// <summary>
        /// Название игры.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название изображения.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Размер поля.
        /// </summary>
        public string FieldSize { get; set; }

        /// <summary>
        /// Режим сборки.
        /// </summary>
        public string AssembleMode { get; set; }
        
        /// <summary>
        /// Форма пазла.
        /// </summary>
        public string PieceForm { get; set; }

        /// <summary>
        /// Сложность.
        /// </summary>
        public string Difficulty { get; set; }
        #endregion
    }
    #endregion
}
