using System.Collections.Generic;
using tester.Data.Testing;
using tester.Data.Testing.QuizQuestions;

namespace tester.Data.Services
{
    public class SessionDataService
    {
        public bool IsTestActive { get; set; }
        public string NameSurname { get; set; } = "";
        public ushort QuestionIndex { get; set; }
        public Test UserTest { get; set; }
        public List<object> AnswersData { get; set; } = new();
        public List<uint> ChosenQuestionIndices = new();
        public List<IBuildable> ChosenQuestions = new();

        public void FinishTest()
        {
            IsTestActive = false;
            NameSurname = "";
            QuestionIndex = 0;
            UserTest = null;
            ChosenQuestions = new List<IBuildable>();
            ChosenQuestionIndices = new List<uint>();
            AnswersData = new List<object>();
        }
        
    }
}