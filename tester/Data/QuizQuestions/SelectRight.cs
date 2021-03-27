using System;
using System.Collections.Generic;
using System.Linq;
using tester.Pages.QuestionRedactorViewComponents;
using tester.Pages.QuestionViewComponents;


namespace tester.Data.QuizQuestions
{
    
    //тут находятся мои попытки использования XML-документации
    
    /// <summary>
    /// Вопрос с выбором правильных ответов
    /// </summary>
    public class SelectRight : Question, IBuildable
    {
        //ReSharper говорит, кто поля ниже можно оставить неинициализированными, но если используется пустой конструктор
        //то это приводит к ошибке
        public string Description { get; set; } = "";
        public List<string> Answers { get; set; } = new List<string>();
        /// <summary>
        /// Хранит не индексы, а bool по индексам значений
        /// </summary>
        public List<bool> RightAnswersIndices { get; set; } = new List<bool>();
        
        /// <summary>
        /// Показывает, можно ли выбрать несколько правильных ответов
        /// </summary>
        public bool IsMultipleAnswersAllowed { get; set; } = false;
        
        /// <summary>
        /// Пустой конструктор нужен для работы <see cref="Activator"/>, ибо тот требует parameterless конструктор
        /// </summary>
        //ReSharper предлагает удалить пустой конструктор, но без него будет ошибка во время исполнения
        public SelectRight()
        {
        }
        /// <summary>
        /// Конструктор спользуется исключительно для теста,
        /// но в будущем возможно будет использоваться для восстановления из JSON
        /// <param name="description">Текст вопроса</param>
        /// <param name="answers">Возможные ответы</param>
        /// <param name="rightAnswersIndices">Список НЕ С ИНДЕКСАМИ ПРАВИЛЬНЫХ ОТВЕТОВ, а со значениями true по
        /// индексам правильных ответов</param>
        /// </summary>
        public SelectRight(string description, List<string> answers, List<bool> rightAnswersIndices)
        {
            Description = description;
            Answers = answers;
            RightAnswersIndices = rightAnswersIndices;
        }
        
        [Obsolete("Больше не используется, но на всякий случай оставлю")] //TODO Удалить
        public QuestionBase BuildView()
        {
            return new SelectRightComponent();
        }
        
        [Obsolete("Больше не используется, но на всякий случай оставлю")] //TODO Удалить
        public QuestionRedactorViewBase BuildRedactor()
        {
            return new SelectRightQuestionRedactorView();
        }
        /// <summary>
        /// <inheritdoc cref="IBuildable"/>
        /// </summary>
        public Type GetViewType()
        {
            return typeof(SelectRightComponent);
        }
        /// <summary>
        /// <inheritdoc cref="IBuildable"/>
        /// </summary>
        public Type GetRedactorType()
        {
            return typeof(SelectRightQuestionRedactorView);
        }
    }
}
