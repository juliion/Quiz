using System;
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
        public Score StartQuiz(QuizType quizType, string title, User curUser)
        {
            Quiz curQuiz = _quizzes.Find((quiz) => quiz.Type == quizType && quiz.Title == title);
            List <Question> questions = curQuiz.Questions;
            int countRightAnswers = 0;
            int selectedAnswer;
            for (int i = 0; i < questions.Count; i++)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\"{curQuiz.Title}\"");
                Console.ResetColor();

                Question question = questions[i];

                Console.WriteLine();
                Console.WriteLine($" {i + 1}) {question.Text}");
                Console.WriteLine();

                List<Answer> answers = question.Answers;
                for (int j = 0; j < answers.Count; j++)
                {
                    Answer answer = answers[j];
                    Console.WriteLine($"   {j + 1} - {answer.Text}");
                }
                Console.WriteLine();
                Console.Write(">  ");
                selectedAnswer = Int32.Parse(Console.ReadLine());
                if (answers[selectedAnswer - 1].IsCorect)
                    countRightAnswers++;
            }
            return new Score(curUser, curQuiz, countRightAnswers);
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
