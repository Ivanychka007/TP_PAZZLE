using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.Client
{
    #region Class: ImageHandler
    /// <summary>
    /// Взаимодействует с Web API.
    /// </summary>
    public class ImageHandler
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
        /// Загружает изображение на сервер.
        /// </summary>
        /// <param name="imagePath">Путь до изображения.</param>
        public async Task Upload(string imagePath, string imageName)
        {
            TextValidator.IsValidString(imagePath);
            TextValidator.IsValidString(imageName);
            FileValidator.CheckFileExists(imagePath);

            var uploadEndpoint = _url + $"api/image/upload?imageName={imageName}";

            var fileName = Path.GetFileName(imagePath);

            var fileStream = File.OpenRead(imagePath);
            HttpContent fileStreamContent = new StreamContent(fileStream);

            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, imageName, fileName);
                var response = await _httpClient.PostAsync(uploadEndpoint, formData);

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    var exception = SerializationManager<ArgumentException>.Deserialize(await response.Content.ReadAsStringAsync());
                    throw new ArgumentException(exception.Message);
                }
            }
        }

        /// <summary>
        /// Возвращает список названий изображений.
        /// </summary>
        /// <returns>Список названий изображений.</returns>
        public async Task<string[]> GetImagesNameList()
        {
            var getImagesNameListEndpoint = _url + "api/image/getImagesNameList";

            var response = await _httpClient.GetAsync(getImagesNameListEndpoint);

            return SerializationManager<string[]>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает название изображения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Название изображения.</returns>
        public async Task<string> GetImageName(Guid id)
        {
            var getImageNameEndpoint = _url + $"api/image/getName?id={id}";
            var response= await _httpClient.GetAsync(getImageNameEndpoint);

            return SerializationManager<string>
                .Deserialize(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Скачивает изображение по названию.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>Изображение.</returns>
        public async Task<Image> Download(string imageName)
        {
            TextValidator.IsValidString(imageName);

            var downloadEndpoint = _url + $"api/image/download?imageName={imageName}";

            var response = await _httpClient.GetStreamAsync(downloadEndpoint);

            return new Image(imageName, response);
        }

        /// <summary>
        /// Удаляет изображение по названию.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns></returns>
        public async Task Delete(string imageName)
        {
            TextValidator.IsValidString(imageName);

            var deleteEndpoint = _url + $"api/image/delete?imageName={imageName}";

            var response = await _httpClient.GetAsync(deleteEndpoint);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException("Не получилось удалить изображение.");
            }
        }

        /// <summary>
        /// Возвращает идентификатор по названию изображения.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>Идентификатор.</returns>
        public async Task<Guid> GetId(string imageName)
        {
            TextValidator.IsValidString(imageName);
            var getIdEndpoint = _url + $"api/image/getId?imageName={imageName}";
            var response = await _httpClient.GetAsync(getIdEndpoint);

            return SerializationManager<Guid>.Deserialize(
                await response.Content.ReadAsStringAsync());
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="url">Ссылка до сайта с Web API.</param>
        public ImageHandler(string url)
        {
            TextValidator.IsValidString(url);

            _url = url;
            _httpClient = new HttpClient();
        }
        #endregion
    }
    #endregion
}
