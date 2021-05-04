using System.Collections.Generic;
using tester.Data.Testing;
using tester.Data.Testing.QuizQuestions;

namespace tester.Data.Services
{
    public class SessionDataService
    {
        public bool IsTestActive { get; set; } = false;
        public string NameSurname { get; set; } = "";
        public ushort QuestionIndex { get; set; } = 0;
        public Test UserTest { get; set; }
        public List<object> AnswersData { get; set; } = new List<object>();
        public List<bool> CorrectAnswersMap { get; set; } = new List<bool>();
        public readonly List<uint> ChosenQuestionIndices = new();
        public readonly List<IBuildable> ChosenQuestions = new();
        public ushort Answers { get; set; } = 0;

        public void FinishTest()
        {
            IsTestActive = false;
            NameSurname = "";
            QuestionIndex = 0;
            UserTest = null;
        }
        
    }
}