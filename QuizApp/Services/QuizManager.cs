using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizModel;

namespace QuizApp.Services
{
    public class QuizManager
    {
        private List<Quiz> _quizzes;
        private string _pathQuizFolder;
        public QuizManager()
        {
            _pathQuizFolder = @"../../Data/Quizzes";
            _quizzes = new List<Quiz>();
            string[] filenames = Directory.GetFiles(_pathQuizFolder);
            foreach (var filename in filenames)
            {
                _quizzes.Add(DataManager.LoadQuiz(filename));
            }

            int numRandQuestions = 20;
            _quizzes.Add(new Quiz(QuizType.Mixed, "Смешаная викторина", GetRandomQuestions(numRandQuestions)));
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
            return new Score(curUser.Login, curQuiz, countRightAnswers);
        }

        public List<Question> GetAllQuestions()
        {
            List<Question> res = new List<Question>();
            foreach (var quiz in _quizzes)
            {
                foreach (var question in quiz.Questions)
                {
                    res.Add(question);
                }
            }
            return res;
        }
        public List<Question> GetRandomQuestions(int num)
        {
            List<Question> res = new List<Question>();
            List<Question> allQuestions = GetAllQuestions();
            Random rnd = new Random();
            for (int i = 0; i < num; i++)
            {
                int randInd = rnd.Next(0, allQuestions.Count - 1);
                Question randQuestion = allQuestions[randInd];
                res.Add(randQuestion);
            }
            return res;
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
