using CMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Repository
{
 public interface ILogin
    {
        // get user details by using username and password
        public Users validateUser(string username, string password);
    }
}
