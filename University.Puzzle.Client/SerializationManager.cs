using System.Text.Json;
using System.Text.Json.Serialization;

namespace University.Puzzle.Client
{
    #region Class: SerializationManager
    /// <summary>
    ///  Управляет сериализацией объектов.
    /// </summary>
    /// <typeparam name="T">Обобщенный тип.</typeparam>
    public static class SerializationManager<T>
    {
        #region Fields: Private
        /// <summary>
        /// Настройка json сериализатора.
        /// </summary>
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString |
           JsonNumberHandling.WriteAsString
        };
        #endregion

        #region Methods: Public
        /// <summary>
        /// Десериализует строку формата json в объект сделки.
        /// </summary>
        /// <param name="json">Строка в json формате.</param>
        /// <returns>Десериализованный объект.</returns>
        public static T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json, Options);
        }

        /// <summary>
        /// Сериализует объект в json формат.
        /// </summary>
        /// <param name="T">Сериализуемый объект.</param>
        /// <returns>Строковое представление объекта в json формате.</returns>
        public static string Serialize(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
        #endregion
    }
    #endregion
}
