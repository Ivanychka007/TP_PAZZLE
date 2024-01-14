using LinqToDB.Mapping;
using System;
using University.Puzzle.ObjectsLibrary.Enum;

namespace University.Puzzle.ObjectsLibrary
{
    #region Class: Difficulty
    /// <summary>
    /// Сущность "Сложность".
    /// </summary>
    public class Difficulty
    {
        #region Fields: Private
        /// <summary>
        /// Количество очков для среднего типа сложности.
        /// </summary>
        private static readonly int MediumDifficultyTypeScore = 5000;

        /// <summary>
        /// Количество очков для тяжелого типа сложности.
        /// </summary>
        private static readonly int HardDifficultyTypeScore = 7000;

        /// <summary>
        /// Множитель элементов пазла для подсчета максимума очков.
        /// </summary>
        private static readonly int ScorePiecesMultiplier = 100;

        /// <summary>
        /// Множитель типов для подсчета максимума очков.
        /// </summary>
        private static readonly int ScoreTypesMultiplier = 1000;

        /// <summary>
        /// Константа типов для подсчета максимума очков.
        /// </summary>
        private static readonly int ScoreAddition = 2;
        #endregion

        #region Properties: Public
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Количество элементов по горизонтали.
        /// </summary>
        [Column(Name = "HorizontalPieces")]
        public int HorizontalPieces { get; set; }

        /// <summary>
        /// Количество элементов по вертикали.
        /// </summary>
        [Column(Name = "VerticalPieces")]
        public int VerticalPieces { get; set; }

        /// <summary>
        /// Режим сборки.
        /// </summary>
        [Column(Name = "AssembleMode")]
        public int AssembleMode { get; set; }

        /// <summary>
        /// Форма элемента.
        /// </summary>
        [Column(Name = "PieceForm")]
        public int PieceForm { get; set; }

        /// <summary>
        /// Тип сложности.
        /// </summary>
        [Column(Name = "DifficultyType")]
        public int DifficultyType { get; set; }
        #endregion

        #region Methods: Public
        /// <summary>
        /// Возвращает максимальное количество очков для данной сложности.
        /// </summary>
        /// <returns>Максимальное количество очков.</returns>
        public static int GetScore(int assembleMode, int pieceForm, int verticalPieces, int horizontalPieces)
        {
            return 
                (assembleMode + pieceForm + ScoreAddition) * ScoreTypesMultiplier
                + verticalPieces * horizontalPieces * ScorePiecesMultiplier;
        }

        /// <summary>
        /// Возвращает тип сложности по максимальному количеству очков.
        /// </summary>
        /// <param name="maxScore">Максимальное количество очков.</param>
        /// <returns>Тип сложности.</returns>
        public static int GetDifficultyTypeByScore(int maxScore)
        {
            var difficultyType = 0;

            if (maxScore > MediumDifficultyTypeScore)
            {
                difficultyType++;
            }

            if (maxScore > HardDifficultyTypeScore)
            {
                difficultyType++;
            }

            return difficultyType;
        }

        /// <summary>
        /// Возвращает строковое представление объекта.
        /// </summary>
        /// <returns>Строковое представление объекта.</returns>
        public override string ToString()
        {
            var lineFormat = "{0,-10}{1,-10}{2,-15}{3,-5}{4,-5}";

            return string.Format(
                lineFormat, 
                GetDifficultyType(), 
                GetAssembleMode(), 
                GetPieceForm(), 
                HorizontalPieces, 
                VerticalPieces);
        }

        /// <summary>
        /// Возвращает форму элемента в строковом представлении.
        /// </summary>
        /// <returns>Строковое представление формы элемента.</returns>
        public string GetPieceForm()
        {
            var pieceForm = string.Empty;

            switch ((PieceFormType)PieceForm)
            {
                case PieceFormType.Square:
                    pieceForm = "Квадрат";
                    break;
                case PieceFormType.Triangle:
                    pieceForm = "Треугольник";
                    break;
                case PieceFormType.Figure:
                    pieceForm = "Фигура";
                    break;
            }

            return pieceForm;
        }

        /// <summary>
        /// Возвращает тип сложности в строковом представлении.
        /// </summary>
        /// <returns>Строковое представление типа сложности.</returns>
        public string GetDifficultyType()
        {
            var difficultyType = string.Empty;

            switch ((DifficultyTypeCode)DifficultyType)
            {
                case DifficultyTypeCode.Easy:
                    difficultyType = "Лёгкая";
                    break;
                case DifficultyTypeCode.Medium:
                    difficultyType = "Средняя";
                    break;
                case DifficultyTypeCode.Hard:
                    difficultyType = "Тяжелая";
                    break;
            }

            return difficultyType;
        }

        /// <summary>
        /// Возвращает форму элемента в строковом представлении.
        /// </summary>
        /// <returns>Строковое представление формы элемента.</returns>
        public string GetAssembleMode()
        {
            var assembleMode = string.Empty;

            switch ((AssembleModeType)AssembleMode)
            {
                case AssembleModeType.OnLine:
                    assembleMode = "На линии";
                    break;
                case AssembleModeType.OnField:
                    assembleMode = "На поле";
                    break;
                case AssembleModeType.OnHeap:
                    assembleMode = "В куче";
                    break;
            }

            return assembleMode;
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Инициализирует экземпляр класса.
        /// </summary>
        /// <param name="horizontalPieces">Элементов по горизонтали.</param>
        /// <param name="verticalPieces">Элементов по вертикали.</param>
        /// <param name="assembleMode">Режим сборки.</param>
        /// <param name="pieceForm">Форма пазла.</param>
        public Difficulty(
            Guid id,
            int horizontalPieces,
            int verticalPieces,
            int assembleMode,
            int pieceForm,
            int difficultyType)
        {
            Id = id;
            HorizontalPieces = horizontalPieces;
            VerticalPieces = verticalPieces;
            AssembleMode = assembleMode;
            PieceForm = pieceForm;
            DifficultyType = difficultyType;
        }
        #endregion
    }
    #endregion
}