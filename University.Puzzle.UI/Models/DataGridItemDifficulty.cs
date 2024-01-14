using System;

namespace University.Puzzle.UI.Models
{
    #region Class: DataGridItemDifficulty
    /// <summary>
    /// Отображает сложность в DataGridDifficulty.
    /// </summary>
    public class DataGridItemDifficulty
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип сложности.
        /// </summary>
        public string DifficultyType { get; set; }

        /// <summary>
        /// Режим сборки.
        /// </summary>
        public string AssembleMode { get; set; }

        /// <summary>
        /// Форма пазла.
        /// </summary>
        public string PieceForm { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public string Size { get; set; }
        #endregion
    }
    #endregion
}
