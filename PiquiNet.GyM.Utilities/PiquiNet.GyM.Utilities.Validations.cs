using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PiquiNet.GyM.Utilities;
using PiquiNet.GyM.Entities;

namespace PiquiNet.GyM.Utilities
{
    public class Validations
    {
        Security _Security = new Security();
        public bool ValidationLoginNotNull(string txtUser, string txtPassword)
        {
            if (txtUser == "" || txtPassword == "")
                return false;
            return true;
        }

        public bool ValidationLogin(string txtUser, string txtPassword, string txtUserCodBD, string txtUserBD, string txtPasswordBD)
        {
            if (txtUser == txtUserBD || txtUser == txtUserCodBD && txtPassword == txtPasswordBD)
                return true;
            return false;
        }

        public bool ValidFields(int _Type, string _Param)
        {
            bool _IsValid = false;
            switch (_Type)
            {
                case 1:
                    _IsValid = Regex.IsMatch(_Param, @"^[a-zA-Z ]+$");
                    break;
                case 2:
                    _IsValid = Regex.IsMatch(_Param, @"^(?("")("".+?(?<!\\)""@)|(([0-9A-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Z][-0-9A-Z]*[0-9A-Z]*\.)+[A-Z0-9][\-A-Z0-9]{0,22}[A-Z0-9]))$");
                    break;
                case 3:
                    _IsValid = Regex.IsMatch(_Param, @"^[a-zA-Z0-9]+$");
                    break;
                case 4:
                    _IsValid = Regex.IsMatch(_Param, @"^[0-9]{10}$");
                    break;
                default:
                    break;
                   
            }
            return _IsValid;
        }

        public string CreateCodeUser(string _cadena, string _TypeRegistro)
        {
            string _codigo  = string.Empty;
            string[] _arrCadena;

            _arrCadena = _cadena.Split('|');

            for (var i = 0; i <= _arrCadena.Length -1; i++)
            {
                if (_arrCadena[i] != "")
                {
                    if (i == 2)
                    {
                        _codigo = _codigo + _arrCadena[i].Substring(0, 1) + DateTime.Today.ToString("dd-MM-yy").Replace("-", "") + _TypeRegistro;
                    }
                    else
                    {
                        _codigo = _codigo + _arrCadena[i].Substring(0,1);
                    }
                }
                else
                {
                    if (_arrCadena[i] != "") 
                    {
                        switch (i)
                        {
                            case 0:
                                _codigo = _codigo + _arrCadena[i].Substring(0, 0);
                                break;
                            case 1:
                                _codigo = _codigo + _arrCadena[i].Substring(0, 1);
                                break;
                            case 2:
                                _codigo = _codigo + _arrCadena[i].Substring(1, 8);
                                break;
                        }
                    }
                }
            }

            return _codigo;
        }

        public bool ValidFormUser(Users _objUsers, bool tipo=false)
        {
            if (!tipo)
            {
                if (_objUsers.Name == "" || _objUsers.Name == null)
                    return false;

                if (_objUsers.LastName == "" || _objUsers.LastName == null)
                    return false;

                if (_objUsers.MotherLastName == "" || _objUsers.MotherLastName == null)
                    return false;

                if (_objUsers.UserName == "" || _objUsers.UserName == null)
                    return false;
            }
            else
            {
                if (_objUsers.Name == "" || _objUsers.Name == null)
                    return false;

                if (_objUsers.LastName == "" || _objUsers.LastName == null)
                    return false;

                if (_objUsers.MotherLastName == "" || _objUsers.MotherLastName == null)
                    return false;

                if (_objUsers.Imagen == null || _objUsers.Imagen.Huella_1 == null || _objUsers.Imagen.Huella_2 == null || _objUsers.Imagen.Huella_3 == null)
                    return false;
            }
            

            return true;
        }

        public bool ValidPassword(string _password, string _confirmPassword)
        {
            if (_password == string.Empty || _confirmPassword == string.Empty)
                return false;

            if (_password != _confirmPassword)
                return false;

            return true;
        }
    }
}
