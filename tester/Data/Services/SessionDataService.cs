using tester.Data.Testing;

namespace tester.Data.Services
{
    public class SessionDataService
    {
        public bool IsTestActive { get; set; } = false;
        public string NameSurname { get; set; } = "";
        public ushort QuestionIndex { get; set; } = 0;
        public Test UserTest { get; set; }
        public short CorrectAnswers { get; set; } = 0;

        public void FinishTest()
        {
            IsTestActive = false;
            NameSurname = "";
            QuestionIndex = 0;
            UserTest = null;
        }
        
    }
}