﻿using System;
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
        public List<Score> GetTop(string quizTitle)
        {
            List<Score> scoresQuiz = _scores.FindAll((s) => s.Quiz.Title == quizTitle);
            List<Score> topScores = scoresQuiz.OrderByDescending((s) => s.RightAnswers).ToList();
            return topScores;
        }
        public void DispayScoresUser(string login)
        {
            Console.Clear();
            Console.WriteLine();
            foreach (var score in _scores)
            {
                if(score.User.Login == login)
                {
                    Console.WriteLine($"  {score.Quiz.Title} - {score}");
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
                    Console.WriteLine($"{i + 1})  {score.User.Login} - {score}");
                }
            }
        }
    }
}
