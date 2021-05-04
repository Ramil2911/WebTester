using System;
using System.Collections.Generic;
using tester.Pages.QuestionRedactorViewComponents;
using tester.Pages.QuestionViewComponents;

namespace tester.Data.Testing.QuizQuestions
{
    public class CodePad : Question, IBuildable //WIP
    {
        /// <summary>
        /// Текст кода
        /// </summary>
        public string Code { get; set; } = "";
        /// <summary>
        /// Язык кода
        /// </summary>
        public Language Lang { get; set; } = 0;
        /// <summary>
        /// Содержит связку ввод-вывод для каждого теста
        /// </summary>
        public List<KeyValuePair<List<string>, List<string>>> Tests { get; set; } = new();

        public CodePad() {}

        public CodePad(string code, Language lang, List<KeyValuePair<List<string>, List<string>>> tests)
        {
            Code = code;
            Lang = lang;
            Tests = tests;
        }
        
        public QuestionBase BuildView()
        {
            throw new NotImplementedException();
        }

        public QuestionRedactorViewBase BuildRedactor()
        {
            throw new NotImplementedException();
        }
        
        /// <inheritdoc cref="IBuildable"/>
        public Type GetViewType()
        {
            return typeof(CodePadViewComponent);
        }
        /// <inheritdoc cref="IBuildable"/>
        public Type GetRedactorType()
        {
            return typeof(CodePadQuestionRedactor);
        }

        public Type GetAnswersDataType()
        {
            throw new NotImplementedException();
        }

        public bool Check(object answer)
        {
            throw new NotImplementedException();
        }

        public uint Price { get; set; } = 0;

        /// <inheritdoc cref="IBuildable"/>
        public IBuildable Copy()
        {
            throw new NotImplementedException();
        }
    }

    public enum Language : ushort
    {
        Cs = 0,
        C = 1,
        Cpp = 2
    }
}