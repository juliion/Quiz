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
        public void DispayScoresUser(string login)
        {
            Console.Clear();
            foreach (var score in _scores)
            {
                if(score.User.Login == login)
                {
                    Console.WriteLine(score);
                }
            }
        }
    }
}
