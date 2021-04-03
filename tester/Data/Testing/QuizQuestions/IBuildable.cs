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
        /// Создает копию объекта
        /// </summary>
        /// <returns>Возвращает точную копию объекта</returns>
        public IBuildable Copy();
    }
}