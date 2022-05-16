using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizModel;
using QuizApp.Services;

namespace QuizCreator.Services
{
    public class Manager
    {
        private Quizzes _createdQuizzes;
        private Reader<Quizzes> _quizzesReader;
        private Writer<Quizzes> _quizzesWriter;
        public Manager(Reader<Quizzes> quizzesReader, Writer<Quizzes> quizzesWriter)
        {
            _quizzesReader = quizzesReader;
            _quizzesWriter = quizzesWriter;
            _createdQuizzes = _quizzesReader.Read() == null ? new Quizzes() : _quizzesReader.Read();
        }
        public void AddQuiz(Quiz newQuiz)
        {
            _createdQuizzes.Add(newQuiz);
            _quizzesWriter.Write(_createdQuizzes);
        }
        public bool CheckQuizExists(string title)
        {
            return FindQuiz(title) != null;
        }
        public Quiz FindQuiz(string title)
        {
            return _createdQuizzes.FirstOrDefault(q => q.Title == title);
        }
        public void RemoveQuiz(string title)
        {
            Quiz remQuiz = FindQuiz(title);
            _createdQuizzes.Remove(remQuiz);
            _quizzesWriter.Write(_createdQuizzes);
        }
        public List<string> GetQuizzesTitles(QuizType type)
        {
            List<string> res = new List<string>();
            foreach (var quiz in _createdQuizzes)
            {
                if (quiz.Type == type)
                    res.Add(quiz.Title);
            }
            return res;
        }
    }
}
