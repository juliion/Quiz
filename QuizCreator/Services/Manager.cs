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
        private string[] _filenames;

        public Manager()
        {
            _createdQuizzes = new List<Quiz>();
            _filenames = Directory.GetFiles(@"../../../QuizApp/Data/Quizzes");
            foreach (var filename in _filenames)
            {
                _createdQuizzes.Add(DataManager.LoadQuiz(filename));
            }
        }

        public void AddQuiz(Quiz newQuiz)
        {
            _createdQuizzes.Add(newQuiz);
            string filenameQuiz = @"../../../QuizApp/Data/Quizzes/" + newQuiz.Title;
            _filenames[_filenames.Length - 1] = filenameQuiz;
            DataManager.SaveQuiz(filenameQuiz, newQuiz);
        }
    }
}
