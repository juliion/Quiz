using System;

namespace QuizModel
{
    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        public User()
        {
        }

        public User(string login, string password, DateTime birthday)
        {
            Login = login;
            Password = password;
            Birthday = birthday;
        }
    }
}
