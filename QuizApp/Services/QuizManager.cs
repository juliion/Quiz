﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Model;

namespace QuizApp.Services
{
    public class QuizManager
    {
        private List<Quiz> _quizzes;
        private string[] _filenames;
        public QuizManager()
        {
            _quizzes = new List<Quiz>();
            _filenames = new string[] { @"..\..\Data\Quiz1.json", @"..\..\Data\Quiz2.json", @"..\..\Data\Quiz3.json" };
            foreach (var filename in _filenames)
            {
                _quizzes.Add(DataManager.LoadQuiz(filename));
            }
        }
        public int[] StartQuiz(QuizType quizType, string title)
        {
            Quiz curQuiz = _quizzes.Find((quiz) => quiz.Type == quizType && quiz.Title == title);
            List <Question> questions = curQuiz.Questions;
            int[] userAnswers = new int[questions.Count];
            int indUA = 0;
            foreach (var question in questions)
            {
                Console.Clear();
                Console.WriteLine(question.Text);
                Console.WriteLine();
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine(answer.Text);
                }
                 userAnswers[indUA] = Int32.Parse(Console.ReadLine());
                indUA++;
            }
            return userAnswers;
        }
        public List<string> GetQuizzesTitles(QuizType type)
        {
            List<string> res = new List<string>();
            foreach (var quiz in _quizzes)
            {
                if (quiz.Type == type)
                    res.Add(quiz.Title);
            }
            return res;
        }
    }
}
