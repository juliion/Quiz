using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizModel;

namespace QuizApp.Services
{
    public class ScoreManager
    {
        private string _fileName;
        private Scores _scores;

        public ScoreManager()
        {
            _fileName = @"..\..\Data\Scores.json";
            if (File.Exists(_fileName))
                _scores = DataManager.LoadScores(_fileName);
            else
                _scores = new Scores();
        }
        public void AddScore(Score score)
        {
            if (_scores.CheckScoreExists(score.UserLogin, score.QuizTitle))
                _scores.Remove(_scores.FindScore(score.UserLogin, score.QuizTitle));
            _scores.Add(score);
            DataManager.SaveScores(_fileName, _scores);
        }
        public List<Score> GetTop(string quizTitle)
        {
            List<Score> scoresQuiz = _scores.FindAll((s) => s.QuizTitle == quizTitle);
            List<Score> topScores = scoresQuiz.OrderByDescending((s) => s.RightAnswers).ToList();
            return topScores;
        }
        public List<Score> GetScoresUser(string login)
        {
            return _scores.FindAll((s) => s.UserLogin == login);
        }
        public void DispayScoresUser(string login)
        {
            Console.Clear();
            Console.WriteLine();
            List<Score> scoresUser = GetScoresUser(login);
            if (scoresUser.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Нет результатов!");
                Console.WriteLine("Похоже вы не прошли еще ни одной викторины.");
            }
            else 
            {
                foreach (var score in scoresUser)
                {
                    Console.WriteLine($"  {score.QuizTitle} - {score}");
                }
            }
        }
        public void DispayTopScores(int topAmount, string quizTitle)
        {
            Console.Clear();
            Console.WriteLine();
            List<Score> topScores = GetTop(quizTitle);
            if (topScores.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Нет результатов по данной векторине!");
            }
            else
            {
                topAmount = topAmount > topScores.Count ? topScores.Count : topAmount;
                for (int i = 0; i < topAmount; i++)
                {
                    Score score = topScores[i];
                    Console.WriteLine($"{i + 1})  {score.UserLogin} - {score}");
                }
            }
        }
        public void DispayUserScInTop(string quizTitle, Score userScore)
        {
            Console.WriteLine();
            List<Score> topScores = GetTop(quizTitle);
            int indUserSc = topScores.IndexOf(userScore);
            int delta = 3;
            int start = indUserSc > delta ? indUserSc - delta : 0;
            int end = indUserSc < topScores.Count - delta - 1 ? indUserSc + delta : topScores.Count - 1;
            for (int i = start; i <= end; i++)
            {
                Score score = topScores[i];
                if(score.UserLogin == userScore.UserLogin)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"  {i + 1})  {score.UserLogin} - {score}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"{i + 1})  {score.UserLogin} - {score}");
            }
        }
    }
}
