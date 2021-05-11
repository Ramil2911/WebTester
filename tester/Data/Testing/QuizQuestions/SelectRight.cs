using System;
using System.Collections.Generic;
using System.Linq;
using tester.Pages.QuestionRedactorViewComponents;
using tester.Pages.QuestionViewComponents;

namespace tester.Data.Testing.QuizQuestions
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
        public List<string> Answers { get; set; } = new();
        /// <summary>
        /// Хранит не индексы, а bool по индексам значений
        /// </summary>
        public List<bool> RightAnswersIndices { get; set; } = new();
        
        /// <summary>
        /// Показывает, можно ли выбрать несколько правильных ответов
        /// </summary>
        public bool IsMultipleAnswersAllowed { get; set; } = false;
        
        public uint Price { get; set; }


        /// <summary>
        /// Пустой конструктор нужен для работы <see cref="Activator"/>, ибо тот требует parameterless конструктор
        /// </summary>
        //ReSharper предлагает удалить пустой конструктор, но без него будет ошибка во время исполнения
        public SelectRight()
        {
        }
        /// <summary>
        /// Конструктор используется исключительно для теста,
        /// но в будущем возможно будет использоваться для восстановления из JSON
        /// <param name="description">Текст вопроса</param>
        /// <param name="answers">Возможные ответы</param>
        /// <param name="rightAnswersIndices">Список НЕ С ИНДЕКСАМИ ПРАВИЛЬНЫХ ОТВЕТОВ, а со значениями true по
        /// индексам правильных ответов</param>
        /// </summary>
        public SelectRight(string description, List<string> answers, List<bool> rightAnswersIndices, bool isMultipleAnswersAllowed, uint price)
        {
            Description = description;
            Answers = answers;
            RightAnswersIndices = rightAnswersIndices;
            IsMultipleAnswersAllowed = isMultipleAnswersAllowed;
            Price = price;
        }
        
        [Obsolete("Больше не используется, но на всякий случай оставлю")]
        public QuestionBase BuildView() => new SelectRightComponent();

        [Obsolete("Больше не используется, но на всякий случай оставлю")]
        public QuestionRedactorViewBase BuildRedactor() => new SelectRightQuestionRedactorView();

        /// <inheritdoc cref="IBuildable"/>
        public Type GetViewType() => typeof(SelectRightComponent);

        /// <inheritdoc cref="IBuildable"/>
        public Type GetRedactorType() => typeof(SelectRightQuestionRedactorView);

        /// <inheritdoc cref="IBuildable"/>
        public Type GetAnswersDataType() => typeof(List<bool>);

        /// <summary>
        /// <inheritdoc cref="IBuildable"/>
        /// </summary>
        /// <param name="answer">Ответ</param>
        /// <returns>Правильность ответа</returns>
        public bool Check(object answer) =>
            /*var list1 = RightAnswersIndices.Except((List<bool>)answer);
            var list2 = ((List<bool>)answer).Except(RightAnswersIndices);
            return list1.Count() + list2.Count() == 0;*/
            RightAnswersIndices.SequenceEqual((List<bool>)answer);

        /// <inheritdoc cref="IBuildable"/>
        public IBuildable Copy() =>
            //так как этот тип состоит из примитивных типов и списков примитивных типов, можно просто передать
            //примитивные типы и создать новые списки с ними, получится несвязанная с оригиналом копия
            //примечание: string - reference type, который ведет себя как value type
            new SelectRight(Description, Answers.ToList(), RightAnswersIndices.ToList(), IsMultipleAnswersAllowed, Price);
    }
}
