using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public abstract class Reader<T>
    {
        public abstract T Read();

    }
}
