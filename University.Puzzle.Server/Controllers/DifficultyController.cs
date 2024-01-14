using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.Puzzle.DbLibrary;
using University.Puzzle.ObjectsLibrary;

namespace University.Puzzle.Server.Controllers
{
    #region Class: DifficultyController
    /// <summary>
    /// Контроллер таблицы "Сложность".
    /// </summary>
    public class DifficultyController : ApiController
    {
        #region Fields: Private
        /// <summary>
        /// Взаимодействует с записями сложности базы данных.
        /// </summary>
        private DifficultyManager _difficultyManager;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Удаляет запись сложности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>OK, если запись была успешно удалена. Иначе BadRequest.</returns>
        [HttpGet]
        [Route("api/difficulty/delete")]
        public HttpResponseMessage DeleteDifficulty(Guid id)
        {
            return new HttpResponseMessage(_difficultyManager.DeleteDifficulty(id) > 0
                ? HttpStatusCode.OK
                : HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Добавляет запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <returns>ОК, если запись добавилась. Иначе BadRequest.</returns>
        [HttpPost]
        [Route("api/difficulty/add")]
        public HttpResponseMessage AddDifficulty([FromBody] Difficulty difficulty)
        {
            try
            {
                _difficultyManager.AddDifficulty(difficulty);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Возвращает запись сложности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Запись сложности.</returns>
        [HttpGet]
        [Route("api/difficulty/get")]
        public Difficulty GetDifficulty(Guid id)
        {
            return _difficultyManager.GetDifficulty(id);
        }

        /// <summary>
        /// Редактирует запись сложности.
        /// </summary>
        /// <param name="difficulty">Сложность.</param>
        /// <returns>ОК, если запись добавилась. Иначе BadRequest.</returns>
        public HttpResponseMessage EditDifficulty([FromBody] Difficulty difficulty)
        {
            try
            {
                _difficultyManager.EditDifficulty(difficulty);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Возвращает список всех сложностей.
        /// </summary>
        /// <returns>Список всех сложностей.</returns>
        [HttpGet]
        [Route("api/difficulty/getAll")]
        public List<Difficulty> GetDifficulties()
        {
            return _difficultyManager.GetDifficulties();
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public DifficultyController()
        {
            _difficultyManager = new DifficultyManager(ConfigurationManager.AppSettings["DefaultConnection"]);
        }
        #endregion
    }
    #endregion
}
