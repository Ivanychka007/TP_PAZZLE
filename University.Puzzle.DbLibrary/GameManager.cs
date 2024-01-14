using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.DbLibrary
{
    #region Class: GameManager
    /// <summary>
    /// Взаимодействует с таблицей игры базы данных.
    /// </summary>
    public class GameManager
    {
        #region Fields: Private
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private string _connectionString;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Удаляет игру по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор игры.</param>
        /// <returns>Количество удаленных игр.</returns>
        public int DeleteGame(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Game
                    .Where(x => x.Id == id)
                    .Delete();
            }
        }

        /// <summary>
        /// Добавляет запись игры.
        /// </summary>
        /// <param name="game">Игра.</param>
        public void AddGame(Game game)
        {
            ObjectValidator.CheckNullReference(game);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                if (database.Game.Where(x => x.Name.Equals(game.Name)).Any())
                {
                    throw new ArgumentException("Игра с данным названием уже существует");
                }

                database.Insert(game);
            }
        }

        /// <summary>
        /// Возвращает игру по идентификатору..
        /// </summary>
        /// <param name="id">Название.</param>
        public Game GetGame(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Game
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Возвращает список игр.
        /// </summary>
        /// <returns></returns>
        public List<Game> GetGames()
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Game
                    .ToList();
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public GameManager(string connectionString)
        {
            TextValidator.IsValidString(connectionString);

            _connectionString = connectionString;
        }
        #endregion
    }
    #endregion
}
