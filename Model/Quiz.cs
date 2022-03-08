using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Quiz
    {
        public QuizType Type { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz()
        {
        }

        public Quiz(QuizType type, string title, List<Question> questions)
        {
            Type = type;
            Title = title;
            Questions = questions;
        }
    }
}
