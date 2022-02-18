using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Question
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }

        public Question(string text, List<Answer> answers)
        {
            Text = text;
            Answers = answers;
        }
    }
}
