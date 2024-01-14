using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.DbLibrary
{
    #region Class: DifficultyManager
    /// <summary>
    /// Взаимодействует с таблицей "Сложность" базы данных.
    /// </summary>
    public class DifficultyManager
    {
        #region Fields: Private
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private string _connectionString;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Добавляет запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        public void AddDifficulty(Difficulty difficulty)
        {
            ObjectValidator.CheckNullReference(difficulty);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                database.Insert(difficulty);
            }
        }

        /// <summary>
        /// Удаляет запись сложности.
        /// </summary>
        /// <param name="difficultyId">Идентификатор сложности.</param>
        /// <returns>Количество удаленных записей.</returns>
        public int DeleteDifficulty(Guid difficultyId)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Difficulty
                    .Where(x => x.Id.Equals(difficultyId))
                    .Delete();
            }
        }

        /// <summary>
        /// Редактирует запись сложности.
        /// </summary>
        /// <param name="newDifficulty">Новая сложность.</param>
        public void EditDifficulty(Difficulty newDifficulty)
        {
            ObjectValidator.CheckNullReference(newDifficulty);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                database
                    .Difficulty
                    .Where(x => x.Id.Equals(newDifficulty.Id))
                    .Set(x => x.VerticalPieces, newDifficulty.VerticalPieces)
                    .Set(x => x.HorizontalPieces, newDifficulty.HorizontalPieces)
                    .Set(x => x.AssembleMode, newDifficulty.AssembleMode)
                    .Set(x => x.PieceForm, newDifficulty.PieceForm)
                    .Set(x => x.DifficultyType, newDifficulty.DifficultyType)
                    .Update();
            }
        }

        /// <summary>
        /// Возвращает список сложностей.
        /// </summary>
        /// <returns></returns>
        public List<Difficulty> GetDifficulties()
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Difficulty
                    .ToList();
            }
        }

        /// <summary>
        /// Возвращает сложность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Искомая сложность.</returns>
        public Difficulty GetDifficulty(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Difficulty
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public DifficultyManager(string connectionString)
        {
            TextValidator.IsValidString(connectionString);

            _connectionString = connectionString;
        }
        #endregion
    }
    #endregion
}
