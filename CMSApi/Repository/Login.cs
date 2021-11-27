using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
    public class Login:ILogin
    {
        DBClinicContext _db;

        public Login(DBClinicContext db)
        {
            _db = db;
        }


        // get user details by using username and password
        public Users validateUser(string username, string password)
        {
            if (_db != null)
            {
                Users dbuser = _db.Users.FirstOrDefault(em => em.UserName == username && em.UserPassword == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;

        }
    }
}
