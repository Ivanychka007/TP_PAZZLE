using System;

namespace University.Puzzle.ValidationLibrary
{
    #region Class: ObjectValidator
    /// <summary>
    /// Валидирует объект класса "User".
    /// </summary>
    public static class ObjectValidator
    {
        #region Methods: Public
        /// <summary>
        /// Проверяет, что объект не является пустым.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <exception cref="ArgumentException">Объект не может быть пустым.</exception>
        public static void CheckNullReference(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Объект не может быть пустым.");
            }
        }
        #endregion
    }
    #endregion
}
