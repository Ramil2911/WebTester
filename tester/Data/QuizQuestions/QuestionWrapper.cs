//because we cant get type of deserialized object i use wrapper which has full name of type it contains to deserialize it properly

namespace tester.Data.QuizQuestions
{
    public class QuestionWrapper
    {
        public string FullTypeName { get; private set; }
        public Question Value { get; private set; }

        public QuestionWrapper(Question question)
        {
            Value = question;
            FullTypeName = question.GetType().FullName;
        }
    }
}