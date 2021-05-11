using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using tester.Data.Testing;
using tester.Data.Testing.QuizQuestions;

namespace tester.Data.Services
{
    //Сервис хранит данные о пользователях, сдавших тест
    public class UsersHistoryService
    {
        public ObservableCollection<UsersHistoryRecord> History { get; set; } = new();

        public void AddRecord(UsersHistoryRecord record)
        {
            if (string.IsNullOrWhiteSpace(record.Username)) throw new Exception("Username cannot be null or whitespace");
            if (string.IsNullOrWhiteSpace(record.Testname)) throw new Exception("Testname cannot be null or whitespace");
            History.Add(record);
        }
    }

    public struct UsersHistoryRecord
    {
        public string Username;
        public string Testname;
        public DateTime StartTime;
        public DateTime EndTime;
        public uint Score;
        public uint MaxScore;
        public List<IBuildable> Questions;
        public List<object> AnswersData;
    }
}