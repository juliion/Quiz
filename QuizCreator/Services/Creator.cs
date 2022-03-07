using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizModel;

namespace QuizCreator.Services
{
    public static class Creator
    {
        public static Quiz CreateQuiz()
        {
            List<Question> questions = new List<Question>();
            Menu.DisplayQiuzMenu();
            Console.Write(">  Выберете область знаний викторины: ");
            int choiceQuiz = Int32.Parse(Console.ReadLine());
            QuizType type = (QuizType)choiceQuiz - 1;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Введите заголовок: ");
            Console.Write(">  ");
            string title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
            Console.Write(">  Введите количество вопросов: ");
            int numQuestion = int.Parse(Console.ReadLine());
            for (int i = 0; i < numQuestion; i++)
            {
                Console.Clear();
                Console.WriteLine($"Вопрос №{i+1}");
                questions.Add(CreateQuestion());
            }
            return new Quiz(type, title, questions);
        }
        public static Question CreateQuestion()
        {
            List<Answer> answers = new List<Answer>();
            Console.WriteLine();
            Console.WriteLine("Введите вопрос: ");
            Console.Write(">  ");
            string text = Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
            Console.Write(">  Введите количество ответов: ");
            int numAnswers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numAnswers; i++)
            {
                Console.Clear();
                Console.WriteLine($"Ответ №{i + 1}");
                answers.Add(CreateAnswer());
            }
            return new Question(text, answers);
        }
        public static Answer CreateAnswer()
        {
            bool isCorect;
            Console.WriteLine();
            Console.WriteLine("Введите ответ: ");
            Console.Write(">  ");
            string text = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\n>  Он правильный (y/n)? - ");
            string answer = Console.ReadLine();
            isCorect = answer == "y" ? true : false;
            return new Answer(text, isCorect);
        }
    }
}
