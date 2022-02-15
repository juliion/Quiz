using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Quiz.Model;

namespace Quiz.Services
{
    public static class DataManager
    {
        public static void SaveUsers(string path, Users users)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                bf.Serialize(fs, users);
        }
        public static Users LoadUsers(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Users res;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                res = (Users)bf.Deserialize(fs);
            return res;
        }
    }
}
