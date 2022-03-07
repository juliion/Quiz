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
        private List<Quiz> _createdQuizzes;
        private string _pathQuizFolder;
        public Manager()
        {
            _pathQuizFolder = @"../../../QuizApp/Data/Quizzes";
            _createdQuizzes = new List<Quiz>();
            string[] filenames = Directory.GetFiles(_pathQuizFolder);
            foreach (var filename in filenames)
            {
                _createdQuizzes.Add(DataManager.LoadQuiz(filename));
            }
        }

        public void AddQuiz(Quiz newQuiz)
        {
            _createdQuizzes.Add(newQuiz);
            string filenameQuiz = _pathQuizFolder + @"/" + newQuiz.Title + ".json";
            DataManager.SaveQuiz(filenameQuiz, newQuiz);
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
            string filenameQuiz = _pathQuizFolder + @"/" + remQuiz.Title + ".json";
            _createdQuizzes.Remove(remQuiz);
            File.Delete(filenameQuiz);
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
