using LinqToDB.Mapping;
using System;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: User
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Table(Name = "User")]
    public class User
    {
        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }


        /// <summary>
        /// Логин.
        /// </summary>
        [Column(Name = "Login"), NotNull]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Column(Name = "Password"), NotNull]
        public string Password { get; set; }

        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        [Column(Name = "IsAdmin"), NotNull]
        public int IsAdmin { get; set; }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public User()
        {
            Id = Guid.NewGuid();
            IsAdmin = 0;
        }

        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        public User(string login, string password) 
            : this()
        {
            TextValidator.IsValidLogin(login);
            TextValidator.IsValidPassword(password);

            Login = login;
            Password = password;
        }
        #endregion
    }
    #endregion
}
