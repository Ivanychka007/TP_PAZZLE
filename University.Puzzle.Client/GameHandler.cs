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
    #region Class: ImageHandler
    /// <summary>
    /// Взаимодействует с Web API.
    /// </summary>
    public class GameHandler
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
        /// Добавляет запись игры.
        /// </summary>
        /// <param name="game">Игра.</param>
        /// <exception cref="ArgumentException">Не удалось добавить запись игры.</exception>
        public async Task AddGame(Game game)
        {
            ObjectValidator.CheckNullReference(game);
            var addGameEndpoint = _url + "api/game/add";
            string json = SerializationManager<Game>.Serialize(game);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(addGameEndpoint, content);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось добавить запись сложности.");
            }
        }

        /// <summary>
        /// Получает запись игры.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Запись игры.</returns>
        /// <exception cref="ArgumentException">Не удалось добавить запись игры.</exception>
        public async Task<Game> GetGame(Guid id)
        {
            var getGameEndpoint = _url + $"api/game/get?id={id}";
            var response = await _httpClient.GetAsync(getGameEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось получить запись сложности.");
            }

            return SerializationManager<Game>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает все игры.
        /// </summary>
        /// <returns>Список игр.</returns>
        /// <exception cref="ArgumentException">Не удалось получить записи игр.</exception>
        public async Task<List<Game>> GetGames()
        {
            var getAllEndpoint = _url + "api/game/getAll";
            var response = await _httpClient.GetAsync(getAllEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось получить записи игр.");
            }

            return SerializationManager<List<Game>>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Удаляет запись игры.
        /// </summary>
        /// <exception cref="ArgumentException">Не удалось удалить запись игры.</exception>
        public async Task DeleteGame(Guid id)
        {
            var deleteEndpoint = _url + $"api/game/delete?id={id}";
            var response = await _httpClient.GetAsync(deleteEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось удались запись сложности.");
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="url">Ссылка до сайта с Web API.</param>
        public GameHandler(string url)
        {
            TextValidator.IsValidString(url);

            _url = url;
            _httpClient = new HttpClient();
        }
        #endregion
    }
    #endregion
}
