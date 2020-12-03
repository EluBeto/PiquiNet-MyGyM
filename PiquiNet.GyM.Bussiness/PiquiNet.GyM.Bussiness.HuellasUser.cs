using PiquiNet.GyM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiquiNet.GyM.Bussiness
{
    public class HuellasUser
    {
        HuellasUserDAO _usersDAO = new HuellasUserDAO();
        public List<Entities.Users> AllUsersHuellas()
        {
            return _usersDAO.AllUsersHuellas();
        }
    }
}
