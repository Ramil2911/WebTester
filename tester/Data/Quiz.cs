using System.Collections.Generic;
using tester.Data.QuizQuestions;

namespace tester.Data
{
    public class Quiz
    {
        public string Name;
        public List<QuestionWrapper> Questions { get; set; } = new List<QuestionWrapper>();
    }
}