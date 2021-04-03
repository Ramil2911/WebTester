using System.Collections.Generic;
using tester.Data.Testing.QuizQuestions;

namespace tester.Data.Testing
{
    public class Test
    {
        public string Name;
        public List<IBuildable> Questions { get; set; } = new List<IBuildable>();
        //когда-то давным давно Questions содержало QuestionWrapper, через который для десериализации было необходимо
        //сначала узнать тип объекта, но, как оказалось, Newtonsoft.Json умеет делать это и сам.
    }
    
}