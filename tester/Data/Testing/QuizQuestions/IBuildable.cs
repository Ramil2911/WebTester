using System;
using tester.Pages.QuestionRedactorViewComponents;
using tester.Pages.QuestionViewComponents;

namespace tester.Data.Testing.QuizQuestions
{
    public interface IBuildable
    {
        public QuestionBase BuildView();
        public QuestionRedactorViewBase BuildRedactor();
        /// <summary>
        /// Возвращает тип компонента, используемого для отображения вопроса
        /// </summary>
        public Type GetViewType();
        /// <summary>
        /// Возвращает тип компонента, используемого редактирования вопроса
        /// </summary>
        public Type GetRedactorType();
        /// <summary>
        /// Возвращает тип объекта, используемого для хранения ответов
        /// </summary>
        public Type GetAnswersDataType();

        /// <summary>
        /// Проверка ответа на правильность
        /// </summary>
        /// <returns>Возвращает true, если ответ правильный, иначе false</returns>
        public bool Check(object answer);
        /// <summary>
        /// Contains question price ushort
        /// </summary>
        public uint Price { get; set; }

        /// <summary>
        /// Contains question price string
        /// </summary>
        public string PriceString
        {
            get => Price.ToString();
            set
            {
                if (uint.TryParse(value, out var result))
                {
                    Price = result;
                }
            }
        }
        /// <summary>
        /// Создает копию объекта
        /// </summary>
        /// <returns>Возвращает точную копию объекта</returns>
        public IBuildable Copy();
    }
}