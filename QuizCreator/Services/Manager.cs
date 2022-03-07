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

        public Manager()
        {
            _createdQuizzes = new List<Quiz>();
            string[] filenames = Directory.GetFiles(@"../../../QuizApp/Data/Quizzes");
            foreach (var filename in filenames)
            {
                _createdQuizzes.Add(DataManager.LoadQuiz(filename));
            }
        }

        public void AddQuiz(Quiz newQuiz)
        {
            _createdQuizzes.Add(newQuiz);
            string filenameQuiz = @"../../../QuizApp/Data/Quizzes/" + newQuiz.Title;
            DataManager.SaveQuiz(filenameQuiz, newQuiz);
        }
    }
}
