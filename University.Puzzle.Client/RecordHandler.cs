using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ObjectsLibrary.Enum;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.Client
{
    #region Class: RecordHandler
    /// <summary>
    /// Выполняет операции с таблицей рекордов через сервер.
    /// </summary>
    public class RecordHandler
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
        public async Task ProcessRecord(Record record)
        {
            ObjectValidator.CheckNullReference(record);
            var processRecordEndpoint = _url + "api/record/process";
            string json = SerializationManager<Record>.Serialize(record);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(processRecordEndpoint, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                throw new ArgumentException("Вы заняли место в таблице рекордов!");
            }
        }

        /// <summary>
        /// Возвращает список рекордов по сложности и режиму подсчета очков.
        /// </summary>
        /// <param name="difficultyType">Тип сложности.</param>
        /// <param name="scoreMode">Режи подсчета очков.</param>
        /// <returns></returns>
        public async Task<List<Record>> GetRecords(int difficultyType, int scoreMode)
        {
            var getRecordsEndpoint = _url 
                + $"api/record/getrecords?difficultyType={difficultyType}&scoreMode={scoreMode}";
            var response = await _httpClient.GetAsync(getRecordsEndpoint);
            var records = SerializationManager<List<Record>>
                .Deserialize(await response.Content.ReadAsStringAsync());

            if (records == null)
            {
                return null;
            }

            if (scoreMode == (int)ScoreMode.Score)
            {
                records = records.OrderByDescending(x => x.Score).ToList();
            }
            else
            {
                records = records.OrderBy(x => x.Time).ToList();
            }

            return records;
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="url">Ссылка до сайта с Web API.</param>
        public RecordHandler(string url)
        {
            TextValidator.IsValidString(url);

            _url = url;
            _httpClient = new HttpClient();
        }
        #endregion
    }
    #endregion
}
