using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using QuizModel;

namespace QuizApp.Services
{
    public static class DataManager
    {
        public static void SaveUsers(string path, Users users)
        {
            string jsonString = JsonSerializer.Serialize<Users>(users, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(path, jsonString);
        }
        public static Users LoadUsers(string path)
        {
            string jsonString = File.ReadAllText(path);
            Users users = JsonSerializer.Deserialize<Users>(jsonString);
            return users;
        }
        public static void SaveQuiz(string path, Quiz quiz)
        {
            string jsonString = JsonSerializer.Serialize<Quiz>(quiz, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(path, jsonString);
        }
        public static Quiz LoadQuiz(string path)
        {
            string jsonString = File.ReadAllText(path);
            Quiz quiz = JsonSerializer.Deserialize<Quiz>(jsonString);
            return quiz;
        }
        public static void SaveScores(string path, Scores scores)
        {
            string jsonString = JsonSerializer.Serialize<Scores>(scores, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(path, jsonString);
        }
        public static Scores LoadScores(string path)
        {
            string jsonString = File.ReadAllText(path);
            Scores scores = JsonSerializer.Deserialize<Scores>(jsonString);
            return scores;
        }
    }
}
