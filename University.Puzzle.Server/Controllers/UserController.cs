using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.Puzzle.DbLibrary;
using System.Configuration;
using University.Puzzle.ObjectsLibrary;

namespace University.Puzzle.Server.Controllers
{
    #region Class: AccountController
    /// <summary>
    /// Контроллер пользователей.
    /// </summary>
    public class UserController : ApiController
    {
        #region Fields: Private
        /// <summary>
        /// Управляет записями пользователей в базе данных.
        /// </summary>
        private UserManager _userManager;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Возвращает идентификатор пользователя по логину.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Идентификатор пользователя.</returns>
        [HttpGet]
        [Route("api/user/getid")]
        public Guid GetId(string login)
        {
            return _userManager.GetId(login);
        }

        /// <summary>
        /// Авторизует пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Возвращает HTTP ответ.</returns>
        [HttpPost]
        [Route("api/user/authorize")]
        public HttpResponseMessage Authorize([FromBody] User user)
        {
            try
            {
                _userManager.CheckCredentials(user.Login, user.Password);
            }
            catch (ArgumentException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Проверяет, обладает ли пользователь правами администратора.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>True, если пользователь с правами администратора. Иначе false.</returns>
        [HttpGet]
        [Route("api/user/isAdmin")]
        public HttpResponseMessage IsAdmin(string login)
        {
            return Request.CreateResponse(_userManager.CheckIsAdmin(login) 
                ? HttpStatusCode.OK
                : HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>ОК, если пользователь был успешно добавлен. Иначе BadRequest.</returns>
        [HttpPost]
        [Route("api/user/register")]
        public HttpResponseMessage Register([FromBody] User user)
        {
            try
            {
                _userManager.AddUser(user);
            }
            catch (ArgumentException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Возвращает логин пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Логин пользователя.</returns>
        [HttpGet]
        [Route("api/user/getlogin")]
        public string GetLogin(Guid id)
        {
            return _userManager.GetLogin(id);
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public UserController()
        {
            _userManager = new UserManager(ConfigurationManager.AppSettings["DefaultConnection"]);
        }
        #endregion
    }
    #endregion
}
