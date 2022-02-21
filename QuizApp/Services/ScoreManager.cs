using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Model;

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
            _scores.Add(score);
            DataManager.SaveScores(_fileName, _scores);
        }
        public void DisplayScore(Score score)
        {
            Console.Clear();
            Quiz quiz = score.Quiz;
            int allRightAnswers = quiz.Questions.Count;
            Console.WriteLine($"Ваш результат {score.RightAnswers} из {allRightAnswers}");
            Console.WriteLine($"{score.RightAnswers * 100 / allRightAnswers} %");
        }
    }
}
