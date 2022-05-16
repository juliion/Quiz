using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace QuizApp.Services
{
    public class JSONReader<T> : Reader<T> where T : class 
    { 
        private string _fileName;

        public JSONReader(string fileName)
        {
            _fileName = fileName;
        }

        public override T Read()
        {
            if(File.Exists(_fileName))
            {
                string jsonString = File.ReadAllText(_fileName);
                T data = JsonSerializer.Deserialize<T>(jsonString);
                return data;
            }
            return null;
        }
    }
}
