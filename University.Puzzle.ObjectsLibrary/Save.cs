using LinqToDB.Mapping;
using System;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: Save
    /// <summary>
    /// Сохранение.
    /// </summary>
    [Table(Name = "Save")]
    public class Save
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [Column(Name = "UserId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор игры.
        /// </summary>
        [Column(Name = "GameId")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        [Column(Name = "Data")]
        public string Data { get; set; }
        #endregion
    }
    #endregion
}
