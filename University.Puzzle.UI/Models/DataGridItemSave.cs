using System;

namespace University.Puzzle.UI.Models
{
    #region Class: DataGridItemSave
    /// <summary>
    /// Отображает сохранение в DataGridView.
    /// </summary>
    public class DataGridItemSave
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Тип сложности.
        /// </summary>
        public string DifficultyType { get; set; }
        #endregion
    }
    #endregion
}
