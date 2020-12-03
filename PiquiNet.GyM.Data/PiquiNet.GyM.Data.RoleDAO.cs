using System;
using System.Collections.Generic;
using System.Configuration;
using PiquiNet.GyM.Utilities;
using PiquiNet.GyM.Entities;
using System.Data.SqlClient;

namespace PiquiNet.GyM.Data
{
    public class RoleDAO
    {
        string _connectionString = string.Empty;
        Security _security = new Security();
        Util util = new Util();
        int result_out = 0;
        public RoleDAO()
        {
            _connectionString = _security.DecryptConnectionString(ConfigurationManager.ConnectionStrings["GyM_DB"].ToString());
        }
        public Respuesta CreateRole(Role _objRole)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_Role";
                        command.Parameters.AddWithValue("@Operacion", _objRole.OperacionRole = OperacionesBD.OperacionRole.Insert);
                        command.Parameters.AddWithValue("@RolId", Util.ZeroToNull(_objRole.RoleId));
                        command.Parameters.AddWithValue("@Name", Util.NullToEmptyString(_objRole.NameRole));
                        command.Parameters.AddWithValue("@AddByUserId", Util.NullToZero(_objRole.AddByUserId));
                        command.Parameters.AddWithValue("@ModByUserId", Util.NullToZero(_objRole.ModByUserId));

                        SqlParameter newId = new SqlParameter();
                        newId.Direction = System.Data.ParameterDirection.InputOutput;
                        newId.ParameterName = "@RolId_Out";
                        newId.Value = _objRole.RoleId;
                        command.Parameters.Add(newId);

                        int response = command.ExecuteNonQuery();
                        int.TryParse(newId.Value.ToString(), out result_out);
                        _objRole.RoleId = result_out;

                        if (_objRole.RoleId > 0)
                        {
                            _respuesta.Codigo = 100;
                            _respuesta.Mensaje = "El registro se inserto satisfactoriamente";
                            _respuesta.EstatusTransaccion = true;
                        }
                        else
                        {
                            _respuesta.Codigo = -100;
                            _respuesta.Mensaje = "Ocurrio un error al procesar la solicitud, intente nuevamente.";
                            _respuesta.EstatusTransaccion = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _respuesta.Codigo = -600;
                _respuesta.Mensaje = ex.Message;
                _respuesta.EstatusTransaccion = false;
            }
            return _respuesta;
        }

        public Respuesta CreateRoleUser(Role _objRole, int _userId)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_Role";
                        command.Parameters.AddWithValue("@Operacion", _objRole.OperacionRole = OperacionesBD.OperacionRole.InsertRoleUser);
                        command.Parameters.AddWithValue("@RolId", Util.ZeroToNull(_objRole.RoleId));
                        command.Parameters.AddWithValue("@UserId", Util.ZeroToNull(_userId));

                        SqlParameter newId = new SqlParameter();
                        newId.Direction = System.Data.ParameterDirection.InputOutput;
                        newId.ParameterName = "@RolId_Out";
                        newId.Value = _objRole.RoleId;
                        command.Parameters.Add(newId);

                        int response = command.ExecuteNonQuery();
                        int.TryParse(newId.Value.ToString(), out result_out);
                        _objRole.RoleId = result_out;

                        if (_objRole.RoleId > 0)
                        {
                            _respuesta.Codigo = 100;
                            _respuesta.Mensaje = "El registro se inserto satisfactoriamente";
                            _respuesta.EstatusTransaccion = true;
                        }
                        else
                        {
                            _respuesta.Codigo = -100;
                            _respuesta.Mensaje = "Ocurrio un error al procesar la solicitud, intente nuevamente.";
                            _respuesta.EstatusTransaccion = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _respuesta.Codigo = -600;
                _respuesta.Mensaje = ex.Message;
                _respuesta.EstatusTransaccion = false;
            }
            return _respuesta;
        }

        public List<Role> SelectRole(Role _objRole)
        {
            List<Role> _lstrole = new List<Role>();
            Role _role = new Role();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_Role";
                        command.Parameters.AddWithValue("@Operacion", _objRole.OperacionRole = OperacionesBD.OperacionRole.Select_All);

                        SqlDataReader reader = command.ExecuteReader();
                        var countReg = 0;
                        while (reader.Read())
                        {
                            _role = new Role();

                            _role.RoleId = (int)Util.NullToZero(reader["RolId"]);
                            _role.NameRole = Util.NullToEmptyString(reader["RoleName"]);
                            _role.AddByUserId = (int)Util.NullToZero(reader["AddByUserId"]);
                            _role.DateAdd = Util.NullToMinDate(reader["DateAdd"]);
                            _role.ModByUserId = (int)Util.NullToZero(reader["ModByUserId"]);
                            _role.DateMod = Util.NullToMinDate(reader["DateMod"]);
                            _role.IsActive = Util.NullToFalse(reader["IsActive"]);

                            _role.Codigo = 100;
                            _role.Mensaje = "Proceso correcto";
                            _role.EstatusTransaccion = true;

                            _lstrole.Add(_role);

                            countReg += 1;
                        }

                        if (countReg < 0)
                        {
                            _role.Codigo = -100;
                            _role.Mensaje = "No existen roles, favor de validar.";
                            _role.EstatusTransaccion = false;
                            _lstrole.Add(_role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _role.Codigo = -600;
                _role.Mensaje = ex.Message;
                _role.EstatusTransaccion = false;
                _lstrole.Add(_role);
            }
            return _lstrole;
        }
    }
}
