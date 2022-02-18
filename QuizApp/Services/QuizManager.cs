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

        public QuizManager()
        {
            _quizzes = new List<Quiz>();
        }
    }
}
