using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiquiNet.GyM.Data;
using PiquiNet.GyM.Entities;
using PiquiNet.GyM.Utilities;

namespace PiquiNet.GyM.Bussiness
{
    public class Users
    {
        UsersDAO _usersDAO = new UsersDAO();
        Security _security = new Security();

        public Respuesta CreateUser(Entities.Users _objUser)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _objUser.Password = _security.EncryptString(_objUser.Password);
                _respuesta = _usersDAO.CreateUser(_objUser);

            }catch(Exception ex)
            {
                _respuesta.Codigo = -700;
                _respuesta.Mensaje = ex.Message;
                _respuesta.EstatusTransaccion = false;

            }
            return _respuesta;
        }
        public Respuesta UpdateUser(Entities.Users _objUser)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _objUser.Password = _security.EncryptString(_objUser.Password);
                _respuesta = _usersDAO.UpdateUser(_objUser);

            }
            catch (Exception ex)
            {
                _respuesta.Codigo = -700;
                _respuesta.Mensaje = ex.Message;
                _respuesta.EstatusTransaccion = false;

            }
            return _respuesta;
        }
        public Respuesta UpdateEstatusUser(Entities.Users _objUser)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta = _usersDAO.UpdateEstatusUser(_objUser);

            }
            catch (Exception ex)
            {
                _respuesta.Codigo = -700;
                _respuesta.Mensaje = ex.Message;
                _respuesta.EstatusTransaccion = false;

            }
            return _respuesta;

        }
        public List<Entities.Users> AllUsers(bool _typeUser)
        {
            return _usersDAO.AllOrWhereUsers(0,false, _typeUser);
        }
        public List<Entities.Users> SelectUser(int _userId, bool _typeUser)
        {
            return _usersDAO.AllOrWhereUsers(_userId, true, _typeUser);
        }
        public List<Entities.Users> SearchUser(string _parameter, bool _typeUser)
        {
            return _usersDAO.SearchUsers(_parameter, _typeUser);
        }

      
    }
}
