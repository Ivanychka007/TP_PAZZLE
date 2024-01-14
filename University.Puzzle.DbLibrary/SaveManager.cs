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
    #region Class: SaveManager
    /// <summary>
    /// Взаимодействует с сущностью "Сохранения" базы данных.
    /// </summary>
    public class SaveManager
    {
        #region Fields: Private
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private string _connectionString;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Добавляет сохранение в базу данных.
        /// </summary>
        /// <param name="save">Сохранение.</param>
        public void AddSave(Save save)
        {
            ObjectValidator.CheckNullReference(save);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                database.Insert(save);
            }
        }

        /// <summary>
        /// Возвращает запись сохранения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сохранение.</returns>
        public Save GetSave(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Save
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Возвращает список сохранений по идентификатору пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Список идентификаторов сохранений.</returns>
        public List<Guid> GetSavesId(Guid userId)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Save
                    .Where(x => x.UserId == userId)
                    .Select(x => x.Id)
                    .ToList();
            }
        }

        /// <summary>
        /// Удаляет сохранение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сохранения.</param>
        /// <returns>Количество удаленных записей.</returns>
        public int DeleteSave(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .Image
                    .Where(x => x.Id == id)
                    .Delete();
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public SaveManager(string connectionString)
        {
            TextValidator.IsValidString(connectionString);

            _connectionString = connectionString;
        }
        #endregion
    }
    #endregion
}
