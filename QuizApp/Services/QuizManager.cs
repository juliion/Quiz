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
        private Reader<Quizzes> _quizzesReader;
        private Quizzes _quizzes;
        public QuizManager(Reader<Quizzes> quizzesReader)
        {
            _quizzesReader = quizzesReader;
            _quizzes = _quizzesReader.Read() == null ? new Quizzes() : _quizzesReader.Read();
            int numQuestions = GetAllQuestions().Count < 20 ? GetAllQuestions().Count : 20;
            _quizzes.Add(GetMixedQuiz(numQuestions));
        }
        public Score StartQuiz(QuizType quizType, string title, User curUser)
        {
            Quiz curQuiz = _quizzes.Find((quiz) => quiz.Type == quizType && quiz.Title == title);
            List <Question> questions = curQuiz.Questions;

            int countRightAnswers = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\"{curQuiz.Title}\"");
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Если правильных ответов несколько, введите их через пробелы (пример: 1 2)");
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
                List<int> userAnswers = Console.ReadLine().Split(' ').
                                    Where(a => !string.IsNullOrWhiteSpace(a)).
                                    Select(a => int.Parse(a)).ToList();
                countRightAnswers += userAnswers.FindAll(a => answers[a - 1].IsCorect).Count;
            }
            return new Score(curUser.Login, curQuiz, countRightAnswers);
        }
        private Quiz GetMixedQuiz(int numQuestions)
        {
            return new Quiz(QuizType.Mixed, "Смешаная викторина", GetRandomQuestions(numQuestions));
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
