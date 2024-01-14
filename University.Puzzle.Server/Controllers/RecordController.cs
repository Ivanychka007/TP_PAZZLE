using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.Puzzle.DbLibrary;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ObjectsLibrary.Enum;

namespace University.Puzzle.Server.Controllers
{
    #region Class: RecordController
    /// <summary>
    /// Контроллер рейтинга.
    /// </summary>
    public class RecordController : ApiController
    {

        #region Fields: Private
        private readonly int _notScore = -404;

        /// <summary>
        /// Максимальное количество записей для определенного уровня сложности.
        /// </summary>
        private readonly int _recordsLimitAmount = 10;

        /// <summary>
        /// Взаимодействует с таблицей рекордов в базе данных.
        /// </summary>
        private RecordManager _recordManager;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Обрабатывает новую запись рекорда.
        /// </summary>
        /// <param name="record">Рекорд.</param>
        /// <returns>OK, если запись была добавлена. Иначе BadRequest.</returns>
        [HttpPost]
        [Route("api/record/process")]
        public HttpResponseMessage ProcessRecord([FromBody] Record record)
        {
            try
            {
                var difficultyType = _recordManager.GetDifficultyTypeByRecord(record);

                var records = record.Score == _notScore
                    ? _recordManager.GetTimeRecordsByDifficulty(difficultyType)
                    : _recordManager.GetScoreRecordsByDifficulty(difficultyType);

                if (records.Where(x => x.UserId == record.UserId).Count() > 0)
                {
                    var userRecord = records
                        .Where(x => x.UserId == record.UserId)
                        .FirstOrDefault();

                    if (IsBetterRecord(userRecord, record))
                    {
                        _recordManager.DeleteRecord(userRecord.Id);
                        _recordManager.AddRecord(record);
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                }
                else if (records.Count() == _recordsLimitAmount)
                {
                    var lastRecord = records.Last();

                    if (IsBetterRecord(lastRecord, record))
                    {
                        _recordManager.DeleteRecord(lastRecord.Id);
                        _recordManager.AddRecord(record);
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                }
                else
                {
                    _recordManager.AddRecord(record);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch (ArgumentException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Возвращает список рекордов по типу сложности и режиму подсчета очков.
        /// </summary>
        /// <param name="difficultyType">Тип сложности.</param>
        /// <param name="scoreMode">Режим подсчета очков.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/record/getrecords")]
        public List<Record> GetRecords(int difficultyType, int scoreMode)
        {
            switch(scoreMode)
            {
                case (int)ScoreMode.Score:
                    return _recordManager.GetScoreRecordsByDifficulty(difficultyType);
                case (int)ScoreMode.Time:
                    return _recordManager.GetTimeRecordsByDifficulty(difficultyType);
                default:
                    return null;
            }
        }
        #endregion

        #region Methods: Private
        /// <summary>
        /// Определяет является ли новый рекорд лучше старого.
        /// </summary>
        /// <param name="oldRecord">Старая запись.</param>
        /// <param name="newRecord">Новая запись.</param>
        /// <returns>True, если новый рекорд лучше старого. Иначе False.</returns>
        private bool IsBetterRecord(Record oldRecord, Record newRecord)
        {
            if (newRecord.Score == _notScore)
            {
                return oldRecord.Time > newRecord.Time;
            }
            else
            {
                return newRecord.Score > oldRecord.Score;
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public RecordController()
        {
            _recordManager = new RecordManager(ConfigurationManager.AppSettings["DefaultConnection"]);
        }
        #endregion
    }
    #endregion
}
