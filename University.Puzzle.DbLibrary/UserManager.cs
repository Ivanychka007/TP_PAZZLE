using LinqToDB;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.DbLibrary
{
    #region Class: UserManager
    /// <summary>
    /// Содержит операции для работы с таблицей пользователей.
    /// </summary>
    public class UserManager
    {
        #region Fields: Private
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private string _connectionString;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Возвращает идентификатор по логину пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Идентификатор пользователя.</returns>
        public Guid GetId(string login)
        {
            TextValidator.IsValidCharacters(login);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .User
                    .Where(x => x.Login == login)
                    .Select(x => x.Id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Проверяет наличие введенных личных данных в базе данных.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <exception cref="ArgumentException">Указан неверный логин или пароль.</exception>
        public void CheckCredentials(string login, string password)
        {
            TextValidator.IsValidLogin(login);
            TextValidator.IsValidPassword(password);

            if (!MatchesPassword(login, password))
            {
                throw new ArgumentException("Указан неверный логин или пароль.");
            }
        }

        /// <summary>
        /// Добавляет нового пользователя.
        /// </summary>
        /// <param name="user">Новый пользователь.</param>
        public void AddUser(User user)
        {
            TextValidator.IsValidPassword(user.Password);
            TextValidator.IsValidLogin(user.Login);

            CheckLogin(user.Login);

            using (var database = new PuzzleDatabase(_connectionString))
            {
                database
                    .Insert(user);
            }
        }

        /// <summary>
        /// Проверяет является ли пользователь администратором.
        /// </summary>
        /// <param name="login">Логин.</param>
        public bool CheckIsAdmin(string login)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .User
                    .Any(u => u.Login == login && u.IsAdmin == 1);
            }
        }
        #endregion

        #region Methods: Private
        /// <summary>
        /// Проверяет, существует ли пользователь с введенным логином.
        /// </summary>
        /// <param name="email">Логин.</param>
        /// <returns>True, если найден пользователь с данным логином, иначе false.</returns>
        private void CheckLogin(string login)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                var loginExists = database
                    .User
                    .Any(x => x.Login == login);

                if (loginExists)
                {
                    throw new ArgumentException("Пользователь с введенным логином уже существует.");
                }
            }
        }

        /// <summary>
        /// Проверяет, совпадает ли логин и пароль.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>True, если авторизация прошла успешно, иначе false.</returns>
        private bool MatchesPassword(string login, string password)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .User
                    .Any(user => user.Password == password && user.Login == login);
            }
        }

        /// <summary>
        /// Возвращает логин пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Логин пользователя.</returns>
        public string GetLogin(Guid id)
        {
            using (var database = new PuzzleDatabase(_connectionString))
            {
                return database
                    .User
                    .Where(x => x.Id == id)
                    .Select(x => x.Login)
                    .FirstOrDefault();
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public UserManager(string connectionString)
        {
            TextValidator.IsValidString(connectionString);

            _connectionString = connectionString;
        }
        #endregion
    }
    #endregion
}
