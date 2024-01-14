using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.Client
{
    #region Class: DifficultyHandler
    /// <summary>
    /// Взаимодействует с Web Api.
    /// </summary>
    public class DifficultyHandler
    {
        #region Fields: Private
        /// <summary>
        /// HTTP клиент.
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Ссылка до сайта с Web API.
        /// </summary>
        private string _url;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Добавляет запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <exception cref="ArgumentException">Не удалось добавить запись сложности.</exception>
        public async Task AddDifficulty(Difficulty difficulty)
        {
            ObjectValidator.CheckNullReference(difficulty);
            var addDifficultyEndpoint = _url + "api/difficulty/add";
            string json = SerializationManager<Difficulty>.Serialize(difficulty);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(addDifficultyEndpoint, content);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось добавить запись сложности.");
            }
        }

        /// <summary>
        /// Получает запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <exception cref="ArgumentException">Не удалось добавить запись сложности.</exception>
        public async Task<Difficulty> GetDifficulty(Guid id)
        {
            var getDifficultyEndpoint = _url + $"api/difficulty/get?id={id}";
            var response = await _httpClient.GetAsync(getDifficultyEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось получить запись сложности.");
            }

            return SerializationManager<Difficulty>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает все сложности.
        /// </summary>
        /// <returns>Список сложностей.</returns>
        /// <exception cref="ArgumentException">Не удалось получить записи сложностей.</exception>
        public async Task<List<Difficulty>> GetDifficulties()
        {
            var getAllEndpoint = _url + "api/difficulty/getAll";
            var response = await _httpClient.GetAsync(getAllEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось получить записи сложностей.");
            }

            return SerializationManager<List<Difficulty>>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Редактирует запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Не удалось изменить запись сложности.</exception>
        public async Task EditDifficulty(Difficulty difficulty)
        {
            ObjectValidator.CheckNullReference(difficulty);
            var addDifficultyEndpoint = _url + "api/difficulty/edit";
            string json = SerializationManager<Difficulty>.Serialize(difficulty);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(addDifficultyEndpoint, content);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось изменить запись сложности.");
            }
        }

        /// <summary>
        /// Удаляет запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Не удалось удалить запись сложности.</exception>
        public async Task DeleteDifficulty(Guid id)
        {
            var deleteDifficultyEndpoint = _url + $"api/difficulty/delete?id={id}";
            var response = await _httpClient.GetAsync(deleteDifficultyEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось удались запись сложности.");
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземлпяр класса.
        /// </summary>
        /// <param name="url">Ссылка до сайта с Web API.</param>
        public DifficultyHandler(string url)
        {
            TextValidator.IsValidString(url);

            _url = url;
            _httpClient = new HttpClient();
        }
        #endregion
    }
    #endregion
}
