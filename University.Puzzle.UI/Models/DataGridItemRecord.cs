using System;

namespace University.Puzzle.UI.Models
{
    #region Class: DataGridItemRecord
    /// <summary>
    /// Отображает запись рекорда в dataGridRecord.
    /// </summary>
    public class DataGridItemRecord
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Позиция в списке рекордов.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Результат.
        /// </summary>
        public string Score { get; set; }
        #endregion
    }
    #endregion
}
