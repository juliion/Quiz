using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorect{ get; set; }

        public Answer()
        {
        }

        public Answer(string text, bool isCorect)
        {
            Text = text;
            IsCorect = isCorect;
        }
    }
}
