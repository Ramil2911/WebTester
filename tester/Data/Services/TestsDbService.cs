using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using tester.Data.Testing;

namespace tester.Data.Services
{
    /// <summary>
    /// Singleton service that contains data about Tests
    /// </summary>
    public class TestsDbService
    {
        //так как в будущем к тестам планируется поддержка картинок, я сразу сделаю раскидывание тестов по папкам
        public List<Test> TestList { get; private set; } = new();
        
        public Test ActiveTest { get; set; }
        
        public TestsDbService()
        {
            UpdateTests();
        }

        public void UpdateTests()
        {
            TestList.Clear();
            //директория тестов
            var testsDir = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName + "/Tests";
            if (!Directory.Exists(testsDir)) Directory.CreateDirectory(testsDir);
            
            //список json файлов с тестами
            var dirs = (from item in Directory.GetDirectories(testsDir) let name = new DirectoryInfo(item).Name where File.Exists(item + $"/{name}.json") select item + $"/{name}.json").ToArray();
            
            var jsonSerializerSettings = new JsonSerializerSettings 
            { 
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore,
            };
            foreach (var dir in dirs)
            {
                var obj = JsonConvert.DeserializeObject<Test>(File.ReadAllText(dir), jsonSerializerSettings);
                TestList.Add(obj);
            }
            
            //TODO: сохранение выбранного теста
            ActiveTest = TestList.Count == 0 ? null : TestList[0];
        }
    }
}