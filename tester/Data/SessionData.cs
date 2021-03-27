namespace tester.Data
{
    public class SessionData
    {
        public bool IsAdmin { get; set; } = false;
        public bool IsTestActive { get; set; } = false;
        public string NameSurname { get; set; } = "";
        public ushort QuestionIndex { get; set; } = 0;
    }
}