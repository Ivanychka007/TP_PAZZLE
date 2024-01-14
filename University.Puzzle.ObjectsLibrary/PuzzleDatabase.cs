using LinqToDB;
using LinqToDB.Data;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: PuzzlleDatabase
    /// <summary>
    /// База данных приложения.
    /// </summary>
    public class PuzzleDatabase : DataConnection
    {
        #region Properties: Public
        /// <summary>
        /// Возвращает таблицу "Пользователь".
        /// </summary>
        public ITable<User> User => this.GetTable<User>();

        /// <summary>
        /// Возвращает таблицу "Сохранение".
        /// </summary>
        public ITable<Save> Save => this.GetTable<Save>();

        /// <summary>
        /// Возвращает таблицу "Изображение".
        /// </summary>
        public ITable<Image> Image => this.GetTable<Image>();

        /// <summary>
        /// Возвращает таблицу "Рекорд".
        /// </summary>
        public ITable<Record> Record => this.GetTable<Record>();

        /// <summary>
        /// Возвращает таблицу "Игра".
        /// </summary>
        public ITable<Game> Game => this.GetTable<Game>();

        /// <summary>
        /// Возвращает таблицу "Сложность".
        /// </summary>
        public ITable<Difficulty> Difficulty => this.GetTable<Difficulty>();
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public PuzzleDatabase(string connectionString)
            : base(ProviderName.SqlServer2019, connectionString)
        {
        }
        #endregion
    }
    #endregion
}
