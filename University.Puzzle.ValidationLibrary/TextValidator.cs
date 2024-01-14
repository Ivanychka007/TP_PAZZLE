using System;
using System.Text.RegularExpressions;

namespace University.Puzzle.ValidationLibrary
{
    #region Class: TextValidator
    /// <summary>
    /// Валидация текста.
    /// </summary>
    public static class TextValidator
    {
        #region Fields: Private
        /// <summary>
        /// Шаблон символов логина и пароля.
        /// </summary>
        private static readonly string CharactersPattern = "^[a-zA-Z0-9]*$";

        /// <summary>
        /// Минимальная длина логина.
        /// </summary>
        private static readonly int MinLoginLength = 4;

        /// <summary>
        /// Максимальная длина логина.
        /// </summary>
        private static readonly int MaxLoginlength = 8;

        /// <summary>
        /// Минимальная длина пароля.
        /// </summary>
        private static readonly int MinPasswordLength = 4;

        /// <summary>
        /// Максимальная длина пароля.
        /// </summary>
        private static readonly int MaxPasswordLength = 12;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Валидирует строку.
        /// </summary>
        /// <param name="str">Проверяемая строка.</param>
        /// <exception cref="ArgumentException">Строка не может быть пустой.</exception>
        public static void IsValidString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("Строка не может быть пустой.");
            }
        }

        /// <summary>
        /// Валидирует логин.
        /// </summary>
        /// <param name="login">Проверяемый логин.</param>
        /// <exception cref="ArgumentException">Длина пароля должна быть в интервале. По умолчанию = [<see cref="MinLoginLength"/>, <see cref="MaxLoginLength"/>].</exception>
        public static void IsValidLogin(string login)
        {
            IsValidString(login);
            IsValidCharacters(login);

            if (login.Length < MinLoginLength)
            {
                throw new ArgumentException($"Длина логина должна быть больше {MinLoginLength}.");
            }

            if (login.Length > MaxLoginlength) 
            {
                throw new ArgumentException($"Длина логина должна быть меньше {MaxLoginlength}.");
            }
        }

        /// <summary>
        /// Валидирует пароль.
        /// </summary>
        /// <param name="password">Проверяемый пароль.</param>
        /// <exception cref="ArgumentException">Длина пароля должна быть в интервале. По умолчанию = [<see cref="MinPasswordLength"/>, <see cref="MaxPasswordLength"/>].</exception>
        public static void IsValidPassword(string password)
        {
            IsValidString(password);

            if (password.Length < MinPasswordLength)
            {
                throw new ArgumentException($"Длина пароля должна быть больше {MinLoginLength}.");
            }

            if (password.Length > MaxPasswordLength)
            {
                throw new ArgumentException($"Длина пароля должна быть меньше {MaxLoginlength}.");
            }
        }

        /// <summary>
        /// Проверяет, что строка состоит из латиницы и цифр.
        /// </summary>
        /// <param name="str">Проверяемая строка.</param>
        /// <exception cref="ArgumentException">Строка должна состоять только из латиницы и цифр.</exception>
        public static void IsValidCharacters(string str)
        {
            IsValidString(str);

            if (!Regex.IsMatch(str, CharactersPattern))
            {
                throw new ArgumentException("Строка должна состоять только из латиницы и цифр.");
            }
        }

        /// <summary>
        /// Проверяет совпадение паролей.
        /// </summary>
        /// <param name="password">Пароль.</param>
        /// <param name="passwordConfirmation">Повторенный пароль.</param>
        /// <exception cref="ArgumentException">Пароли не совпадают.</exception>
        public static void ConfirmPasswords(string password, string passwordConfirmation)
        {
            if (!password.Equals(passwordConfirmation))
            {
                throw new ArgumentException("Введенные пароли не совпадают.");
            }
        }
        #endregion
    }
    #endregion
}