using LinqToDB.Mapping;
using System;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: Record
    /// <summary>
    /// Сущность "Record".
    /// </summary>
    public class Record
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор уровня.
        /// </summary>
        [Column(Name ="GameId")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [Column(Name = "UserId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Счет.
        /// </summary>
        [Column(Name ="Score")]
        public int Score { get; set; }

        /// <summary>
        /// Время.
        /// </summary>
        [Column(Name = "Time")]
        public DateTime Time {  get; set; }
        #endregion
    }
    #endregion
}
