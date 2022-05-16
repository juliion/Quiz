using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace QuizApp.Services
{
    public class JSONWriter<T> : Writer<T> where T : class
    {
        private string _fileName;

        public JSONWriter(string fileName)
        {
            _fileName = fileName;
        }

        public override void Write(T data)
        {
            string jsonString = JsonSerializer.Serialize<T>(data, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(_fileName, jsonString);
        }
    }
}
