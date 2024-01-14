using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.Puzzle.DbLibrary;
using University.Puzzle.ObjectsLibrary;

namespace University.Puzzle.Server.Controllers
{
    #region Class: GameController
    /// <summary>
    /// Взаимодействует с таблицей игры.
    /// </summary>
    public class GameController : ApiController
    {
        #region Fields: Private
        /// <summary>
        /// Взаимодействует с записями игр базы данных.
        /// </summary>
        private GameManager _gameManager;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Удаляет запись игры по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>OK, если запись была успешно удалена. Иначе BadRequest.</returns>
        [HttpGet]
        [Route("api/game/delete")]
        public HttpResponseMessage DeleteGame(Guid id)
        {
            return new HttpResponseMessage(_gameManager.DeleteGame(id) > 0
                ? HttpStatusCode.OK
                : HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Добавляет запись игры.
        /// </summary>
        /// <param name="game">Игра.</param>
        /// <returns>ОК, если запись добавилась. Иначе BadRequest.</returns>
        [HttpPost]
        [Route("api/game/add")]
        public HttpResponseMessage AddGame([FromBody] Game game)
        {
            try
            {
                _gameManager.AddGame(game);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Возвращает запись игры по названию.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Запись игры.</returns>
        [HttpGet]
        [Route("api/game/get")]
        public Game GetGame(Guid id)
        {
            return _gameManager.GetGame(id);
        }

        /// <summary>
        /// Возвращает список всех игр.
        /// </summary>
        /// <returns>Список всех сложностей.</returns>
        [HttpGet]
        [Route("api/game/getAll")]
        public List<Game> GetGames()
        {
            return _gameManager.GetGames();
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public GameController()
        {
            _gameManager = new GameManager(ConfigurationManager.AppSettings["DefaultConnection"]);
        }
        #endregion
    }
    #endregion
}
