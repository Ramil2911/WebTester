//because we cant get type of deserialized object i use wrapper which has full name of type it contains to deserialize it properly

namespace tester.Data.Testing.QuizQuestions
{
    // public class QuestionWrapper
    // {
    //     public string FullTypeName { get; set; }
    //     public IBuildable Value { get; set; }
    //
    //     public QuestionWrapper(IBuildable question)
    //     {
    //     }
    //     
    //     public QuestionWrapper(IBuildable question)
    //     {
    //         Value = question;
    //         FullTypeName = question.GetType().FullName;
    //     }
    // }
}