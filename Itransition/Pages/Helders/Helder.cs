using ItransitionTask3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItransitionTask3.Pages.Helders
{
    public class Helder
    {
        DataBase db;
        public static List<User> Users;
        public static int ThisUserId;

        public Helder(int Id)
        {
            db = new DataBase();
            ThisUserId = Id;
            Users = db.GetAllUsersFromDataBase();
        }

        public static void CreateHelder(int id)
        {
             new Helder(id);
        }

        public static List<User> GetHelderUsers()
        {
            return Users;
        }
    }
}
