using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.Client
{
    #region Class: UserHandler
    /// <summary>
    /// Взаимодействует с Web API.
    /// </summary>
    public class UserHandler
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
        /// Выполняет авторизацию пользователя.
        /// </summary>
        /// <param name="user">Пользователя.</param>
        public async Task Authorize(User user)
        {
            var authorizationEndpoint = _url + "api/user/authorize";

            string json = SerializationManager<User>.Serialize(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(authorizationEndpoint, httpContent);

            if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Неправильный логин или пароль");
            }
        }

        /// <summary>
        /// Проверяет наличие прав администратора у пользователя по логину.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <returns>True, если пользователь имеет права администратора. Иначе false.</returns>
        public async Task<bool> IsAdmin(string login)
        {
            var isAdminEndpoint = _url + $"api/user/isadmin?login={login}";
            
            var httpResponse = await _httpClient.GetAsync(isAdminEndpoint);

            return httpResponse.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <exception cref="ArgumentException">Пользователь с введенным логином уже существует.</exception>
        public async Task Register(User user)
        {
            var registerEndpoint = _url + $"api/user/register";

            string json = SerializationManager<User>.Serialize(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(registerEndpoint, httpContent);

            if(httpResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Пользователь с введенным логином уже существует.");
            }
        }

        /// <summary>
        /// Возвращает идентификатор пользователя по логину.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <returns>Идентификатор.</returns>
        public async Task<Guid> GetId(string login)
        {
            var getIdEndpoint = _url + $"api/user/getid?login={login}";

            var httpResponse = await _httpClient.GetAsync(getIdEndpoint);

            return SerializationManager<Guid>
                .Deserialize(await httpResponse.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает логин пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Логин пользователя.</returns>
        public async Task<string> GetLogin(Guid id)
        {
            var getLoginEndpoint = _url + $"api/user/getLogin?id={id}";
            var httpResponse = await _httpClient.GetAsync(getLoginEndpoint);

            return SerializationManager<string>
                .Deserialize(await httpResponse.Content.ReadAsStringAsync());
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземлпяр класса.
        /// </summary>
        /// <param name="url">Ссылка до сайта с Web API.</param>
        public UserHandler(string url)
        {
            TextValidator.IsValidString(url);

            _url = url;
            _httpClient = new HttpClient();
        }
        #endregion
    }
    #endregion
}
