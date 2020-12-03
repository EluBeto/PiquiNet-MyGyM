using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiquiNet.GyM.Entities;
using PiquiNet.GyM.Utilities;
using PiquiNet.GyM.Data;

namespace PiquiNet.GyM.Bussiness
{
    public class Login
    {
        UsersDAO _usersDAO = new UsersDAO();
        Security _security = new Security();
        public Entities.Users ProccessLogin(string _User, string _Password)
        {
           Entities.Users _users = new Entities.Users();
            try
            {
                _users.UserCode = _User;
                _users.UserName = _User;
                _users = _usersDAO.SelectLogin(_users);

            }catch(Exception ex)
            {
                _users.Codigo = -700;
                _users.Mensaje = ex.Message;
                _users.EstatusTransaccion = false;                
            }
            return _users;
        }
    }
}
