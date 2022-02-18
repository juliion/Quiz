using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuizApp.Model;

namespace QuizApp.Services
{
    public static class DataManager
    {
        public static void SaveUsers(string path, Users users)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                bf.Serialize(fs, users);
        }
        public static Users LoadUsers(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Users res;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                res = (Users)bf.Deserialize(fs);
            return res;
        }
        public static void SaveQuiz(string path, Quiz quiz)
        {
            string jsonString = JsonSerializer.Serialize<Quiz>(quiz);
            File.WriteAllText(path, jsonString);
        }
        public static Quiz LoadQuiz(string path)
        {
            string jsonString = File.ReadAllText(path);
            Quiz quiz = JsonSerializer.Deserialize<Quiz>(jsonString);
            return quiz;
        }
    }
}
