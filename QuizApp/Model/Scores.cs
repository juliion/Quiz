using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Scores : List<Score>
    {
        public Scores()
        {

        }

        public bool CheckScoreExists(string userLogin, string quizTitle)
        {
            return FindScore(userLogin, quizTitle) != null;
        }
        public Score FindScore(string userLogin, string quizTitle)
        {
            return this.FirstOrDefault(s => s.UserLogin == userLogin && s.QuizTitle == quizTitle);
        }
    }
}
