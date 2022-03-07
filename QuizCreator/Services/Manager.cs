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
    }
}
