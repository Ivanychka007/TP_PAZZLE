using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.DbLibrary
{
    #region Class: RatingManager
    /// <summary>
    /// Взаимодействует с таблицей рейтинга.
    /// </summary>
    public class RecordManager
    {

        #region Fields: Private
        private readonly int _notScore = -404;

        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Количество человек, хранящихся в рекорде.
        /// </summary>
        private int _topAmount = 10;

        /// <summary>
        /// Взаимодействует с таблицей сложности.
        /// </summary>
        private DifficultyManager _difficultyManager;

        /// <summary>
        /// Взаимодействует с таблицей игры.
        /// </summary>
        private GameManager _gameManager;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Возвращает тип сложности по записи рекорда.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int GetDifficultyTypeByRecord(Record record)
        {
            ObjectValidator.CheckNullReference(record);
            
            using (var database = new PuzzleDatabase(_connectionString))
            {
                var game = _gameManager.GetGame(record.GameId);
                var difficulty = _difficultyManager.GetDifficulty(game.DifficultyId) ;

                return difficulty.DifficultyType;
            }
        }

        /// <summary>
        /// Возвращает список рекордов по сложности.
        /// </summary>
        /// <returns>Список рекордов по сложности.</returns>
        public List<Record> GetScoreRecordsByDifficulty(int difficultyType)
        {
            
            using (var database = new PuzzleDatabase(_connectionString))
            {
                var games = _gameManager.GetGames();
                var difficulties = _difficultyManager.GetDifficulties();

                var difficultiesId = difficulties
                    .Where(x => x.DifficultyType == difficultyType)
                    .Select(x => x.Id);

                var gamesId = games
                    .Where(x => difficultiesId.Contains(x.DifficultyId))
                    .Select(x => x.Id);

                return database
                    .Record
                    .Where(x => x.Score != _notScore && gamesId.Contains(x.GameId))
                    .OrderByDescending(x => x.Score)
                    .ToList();
            }
        }

        /// <summary>
        /// Возвращает список рекордов по времени по сложности.
        /// </summary>
        /// <param name="difficultyType">Тип сложности.</param>
        /// <returns>Список рекордов по времени.</returns>
        public List<Record> GetTimeRecordsByDifficulty(int difficultyType)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                var games = _gameManager.GetGames();
                var difficulties = _difficultyManager.GetDifficulties();

                var difficultiesId = difficulties
                    .Where(x => x.DifficultyType == difficultyType)
                    .Select(x => x.Id);

                var gamesId = games
                    .Where(x => difficultiesId.Contains(x.DifficultyId))
                    .Select(x => x.Id);

                return database
                    .Record
                    .Where(x => x.Score == _notScore && gamesId.Contains(x.GameId))
                    .OrderBy(x => x.Time)
                    .ToList();
            }
        }

        /// <summary>
        /// Добавляет новый рекорд.
        /// </summary>
        /// <param name="record">Рекорд.</param>
        public void AddRecord(Record record)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                database
                    .Insert(record);
            }
        }

        /// <summary>
        /// Удаляет запись рекорда по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void DeleteRecord(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                database
                    .Record
                    .Where(x => x.Id == id)
                    .Delete();
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public RecordManager(string connectionString)
        {
            TextValidator.IsValidString(connectionString);

            _connectionString = connectionString;
            _difficultyManager = new DifficultyManager(_connectionString);
            _gameManager = new GameManager(_connectionString);
        }
        #endregion
    }
    #endregion
}
