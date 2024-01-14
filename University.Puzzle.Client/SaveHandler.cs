using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.Client
{
    #region Class: SaveHandler
    /// <summary>
    /// Взаимодействует с таблицей сохранений через сервер.
    /// </summary>
    public class SaveHandler
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
        /// Добавляет сохранение через Web API.
        /// </summary>
        /// <param name="save">Сохранение.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Не удалось добавить сохранение.</exception>
        public async Task AddSave(Save save)
        {
            ObjectValidator.CheckNullReference(save);
            var addSaveEndpoint = _url + "api/save/add";
            string json = SerializationManager<Save>.Serialize(save);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(addSaveEndpoint, content);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось добавить сохранения.");
            }
        }

        /// <summary>
        /// Получает запись игры.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Запись игры.</returns>
        /// <exception cref="ArgumentException">Не удалось добавить запись игры.</exception>
        public async Task<Save> GetSave(Guid id)
        {
            var getSaveEndpoint = _url + $"api/save/get?id={id}";
            var response = await _httpClient.GetAsync(getSaveEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось получить запись сохранения.");
            }

            return SerializationManager<Save>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает список сохранений по идентификатору пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Список сохранений.</returns>
        /// <exception cref="ArgumentException">Не удалось получить сохранения.</exception>
        public async Task<List<Guid>> GetSavesId(Guid userId)
        {
            var getSavesByUserIdEndpoint = _url + $"api/save/user?userId={userId}";
            var response = await _httpClient.GetAsync(getSavesByUserIdEndpoint);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Не удалось получить сохранения.");
            }

            return SerializationManager<List<Guid>>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Удаляет сохранение.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <exception cref="ArgumentException">Не удалось удалить сохранение.</exception>
        public async Task DeleteGame(Guid id)
        {
            var deleteEndpoint = _url + $"api/save/delete?id={id}";
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
        public SaveHandler(string url)
        {
            TextValidator.IsValidString(url);

            _url = url;
            _httpClient = new HttpClient();
        }
        #endregion
    }
    #endregion
}