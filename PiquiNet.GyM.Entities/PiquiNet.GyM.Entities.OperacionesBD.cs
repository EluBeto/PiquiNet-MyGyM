using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiquiNet.GyM.Entities
{
    public class OperacionesBD
    {
        public enum OperacionUser
        {
            Select_All = 10,
            Select_Login = 11,
            Select_Where = 12,
            Select_UserName = 13,
            Sherch_UserName = 14,
            Insert = 20,
            UpDate = 30,
            Low_Logic = 40,
            Delete = 50
        }

        public enum OperacionImagesUser
        {
            Select_All = 10,
            Select_Huellas = 11,
            Select_Where = 12,
            Insert = 20,
            UpDate = 30,
            Low_Logic = 40,
            Delete = 50
        }

        public enum OperacionRole
        {
            Select_All = 10,
            Select_Where = 11,
            Insert = 20,
            InsertRoleUser = 21,
            UpDate = 30,
            Low_Logic = 40,
            Delete = 50
        }
    }
}
