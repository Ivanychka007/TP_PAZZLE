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
    #region Class: SaveController
    /// <summary>
    /// Контроллер сохранений.
    /// </summary>
    public class SaveController : ApiController
    {
        #region Fields: Private
        /// <summary>
        /// Взаимодействует с записями сохранений базы данных.
        /// </summary>
        private SaveManager _saveManager;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Возвращает сохранение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сохранение.</returns>
        [HttpGet]
        [Route("api/save/get")]
        public Save GetSave(Guid id)
        {
            return _saveManager.GetSave(id);
        }

        /// <summary>
        /// Добавляет сохранение в базу данных.
        /// </summary>
        /// <param name="save">Сохранение.</param>
        /// <returns>ОК, если запись была успешно добавлена. Иначе BadRequest.</returns>
        [HttpPost]
        [Route("api/save/add")]
        public HttpResponseMessage AddSave([FromBody] Save save)
        {
            try
            {
                _saveManager.AddSave(save);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Удаляет запись сохранения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>ОК, если запись была успешно удалена. Иначе BadRequest.</returns>
        [HttpGet]
        [Route("api/save/delete")]
        public HttpResponseMessage DeleteSave(Guid id)
        {
            return _saveManager.DeleteSave(id) > 0
                ? new HttpResponseMessage(HttpStatusCode.OK)
                : new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Возвращает идентификаторы сохранений по идентификатору пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Список сохранений пользователя.</returns>
        [HttpGet]
        [Route("api/save/user")]
        public List<Guid> GetSaves(Guid userId)
        {
            return _saveManager.GetSavesId(userId);
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public SaveController()
        {
            _saveManager = new SaveManager(ConfigurationManager.AppSettings["DefaultConnection"]);
        }
        #endregion
    }
    #endregion
}
