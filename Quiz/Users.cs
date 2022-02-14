using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Users
    {
        private List<User> _users;
        public bool SignUp(string login, string password, DateTime birthday)
        {
            foreach (User user in _users)
            {
                if(login == user.Login)
                    return false;
            }
            _users.Add(new User(login, password, birthday));
            return true;
        }
    }
}
