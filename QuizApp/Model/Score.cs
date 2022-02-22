using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Score
    {
        public User User { get; set; }
        public Quiz Quiz { get; set; }
        public int RightAnswers { get; set; }

        public Score()
        {
        }

        public Score(User user, Quiz quiz, int rightAnswers)
        {
            User = user;
            Quiz = quiz;
            RightAnswers = rightAnswers;
        }

        public override string ToString()
        {
            int allRightAnswers = Quiz.Questions.Count;
            return $"{RightAnswers} из {allRightAnswers} ({RightAnswers * 100 / allRightAnswers} %)";
        }
    }
}
