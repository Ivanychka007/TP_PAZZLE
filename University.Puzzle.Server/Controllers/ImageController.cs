using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using University.Puzzle.DbLibrary;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.Server.Controllers
{
    #region Class: ImageController
    /// <summary>
    /// Контроллер изображений.
    /// </summary>
    public class ImageController : ApiController
    {
        #region Fields: Private
        /// <summary>
        /// Взаимодействует с таблицей изображений в базе данных.
        /// </summary>
        private ImageManager _imageManager;

        /// <summary>
        /// Ограничение на вес файла в байтах.
        /// </summary>
        private readonly int _fileBytesLength = 1024000;
        #endregion

        #region Methods: Public
        /// <summary>
        /// Загружает изображения формата .jpeg или .jpg в базу данных.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        [Route("api/image/upload")]
        [HttpPost]
        public HttpResponseMessage Upload(string imageName)
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count != 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Разрешено загружать только один файл за запрос.");
            }

            if (httpRequest.Files[0].ContentLength > _fileBytesLength)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Размер файла превышает {_fileBytesLength} байт.");
            }

            var file = httpRequest.Files[0];

            try
            {
                FileValidator.CheckJpegExtension(file.FileName);

                var image = new Image(imageName, file.InputStream);
                _imageManager.AddImage(image);
            }
            catch(ArgumentException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
            
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Возвращает список названий изображений.
        /// </summary>
        /// <returns>Список названий изображений.</returns>
        [HttpGet]
        [Route("api/image/getImagesNameList")]
        public string[] GetImagesNameList()
        {
            return _imageManager.GetImagesNameList();
        }

        /// <summary>
        /// Возвращает идентификатор по названию изображения.
        /// </summary>
        /// <param name="name">Название изображения.</param>
        /// <returns>Идентификатор.</returns>
        [HttpGet]
        [Route("api/image/getId")]
        public Guid GetId(string imageName)
        {
            return _imageManager.GetImageId(imageName);
        }

        /// <summary>
        /// Возвращает название по идентификатору изображения.
        /// </summary>
        /// <param name="id">Идентификатор изображения.</param>
        /// <returns>Название изображение.</returns>
        [HttpGet]
        [Route("api/image/getName")]
        public string GetName(Guid id)
        {
            return _imageManager.GetImageName(id);
        }

        /// <summary>
        /// Возвращает изображение по названию.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>HTTP сообщение.</returns>
        [HttpGet]
        [Route("api/image/download")]
        public HttpResponseMessage GetImage(string imageName)
        {
            var image = _imageManager.GetImage(imageName);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(image.Data);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = $"{imageName}.jpg";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = image.Data.Length;

            return response;
        }

        /// <summary>
        /// Удаляет изображение по названию.
        /// </summary>
        /// <param name="imageName">Название изображения.</param>
        /// <returns>OK, если сообщение было удалено. Иначе BadRequest.</returns>
        [HttpGet]
        [Route("api/image/delete")]
        public HttpResponseMessage DeleteImage(string imageName)
        {
            var isDeleted = _imageManager.DeleteImage(imageName) > 0;

            return new HttpResponseMessage(isDeleted 
                ? HttpStatusCode.OK 
                : HttpStatusCode.BadRequest);
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        public ImageController()
        {
            _imageManager = new ImageManager(ConfigurationManager.AppSettings["DefaultConnection"]);
        }
        #endregion
    }
    #endregion
}
