using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiquiNet.GyM.Data;
using PiquiNet.GyM.Utilities;

namespace PiquiNet.GyM.Bussiness
{
    public class Role
    {
        RoleDAO roleDAO = new RoleDAO();
        Security _security = new Security();
        public List<Entities.Role> ProccessRole()
        {
            List<Entities.Role> _lstRole = new List<Entities.Role>();
            Entities.Role _Role = new Entities.Role();

            try
            {
                var _role = new Entities.Role()
                {
                    OperacionRole = Entities.OperacionesBD.OperacionRole.Select_All
                };
                _lstRole = roleDAO.SelectRole(_role);

            }
            catch (Exception ex)
            {
                _Role.Codigo = -700;
                _Role.Mensaje = ex.Message;
                _Role.EstatusTransaccion = false;
                _lstRole.Add(_Role);
            }
            return _lstRole;
        }
    }
}
