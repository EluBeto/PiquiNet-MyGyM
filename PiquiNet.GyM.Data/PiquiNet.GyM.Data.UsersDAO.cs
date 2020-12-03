using System;
using System.Collections.Generic;
using PiquiNet.GyM.Utilities;
using PiquiNet.GyM.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace PiquiNet.GyM.Data
{
    public class UsersDAO
    {
        string _connectionString  = string.Empty;
        Security _security = new Security();
        Util util = new Util();
        RoleDAO roleDAO = new RoleDAO();

        int result_out = 0;
        public UsersDAO()
        {
            _connectionString = _security.DecryptConnectionString(ConfigurationManager.ConnectionStrings["GyM_DB"].ToString());
        }
        public Respuesta CreateUser(Users _objUsario)
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
                        command.CommandText = "SP_Users";
                        command.Parameters.AddWithValue("@Operacion", _objUsario.Operacion = OperacionesBD.OperacionUser.Insert);
                        command.Parameters.AddWithValue("@UserId", Util.ZeroToNull(_objUsario.UserId));
                        command.Parameters.AddWithValue("@UserCode", Util.EmptyStringToNull(_objUsario.UserCode));
                        command.Parameters.AddWithValue("@UserName", Util.EmptyStringToNull(_objUsario.UserName));
                        command.Parameters.AddWithValue("@Mail", Util.EmptyStringToNull(_objUsario.Mail));
                        command.Parameters.AddWithValue("@Password", Util.EmptyStringToNull(_objUsario.Password));
                        command.Parameters.AddWithValue("@Name", Util.EmptyStringToNull(_objUsario.Name));
                        command.Parameters.AddWithValue("@LastName", Util.EmptyStringToNull(_objUsario.LastName));
                        command.Parameters.AddWithValue("@MotherLastName", Util.EmptyStringToNull(_objUsario.MotherLastName));
                        command.Parameters.AddWithValue("@Sex", Util.NullToFalse(_objUsario.Sex));
                        command.Parameters.AddWithValue("@BirthDay", Util.EmptyDateToNull(_objUsario.BirthDay));
                        command.Parameters.AddWithValue("@TypeUser", Util.NullToFalse(_objUsario.TypeUser));
                        command.Parameters.AddWithValue("@AddByUserId", Util.ZeroToNull(_objUsario.AddByUserId));
                        command.Parameters.AddWithValue("@ModByUserId", Util.ZeroToNull(_objUsario.ModByUserId));

                        SqlParameter newId = new SqlParameter();
                        newId.Direction = System.Data.ParameterDirection.InputOutput;
                        newId.ParameterName = "@UserId_Out";
                        newId.Value = _objUsario.UserId; 
                        command.Parameters.Add(newId);

                        int response = command.ExecuteNonQuery();
                        int.TryParse(newId.Value.ToString(), out result_out);
                        _objUsario.UserId = result_out;

                        if (_objUsario.UserId > 0)
                        {
                            Respuesta respuesta = new Respuesta();

                            if (_objUsario.Imagen.Image != null)
                                respuesta = CreateImageUser(_objUsario);

                            if (_objUsario.Rol != null)
                                respuesta = roleDAO.CreateRoleUser(_objUsario.Rol, _objUsario.UserId);


                            if (respuesta.EstatusTransaccion)
                            {
                                _respuesta.Codigo = respuesta.Codigo;
                                _respuesta.Mensaje = respuesta.Mensaje;
                                _respuesta.EstatusTransaccion = respuesta.EstatusTransaccion;
                            }
                            else
                            {
                                _respuesta.Codigo = -100;
                                _respuesta.Mensaje = "Ocurrio un error al procesar la solicitud, intente nuevamente.";
                                _respuesta.EstatusTransaccion = false;
                            }
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
        public Respuesta UpdateUser(Users _objUsario)
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
                        command.CommandText = "SP_Users";
                        command.Parameters.AddWithValue("@Operacion", _objUsario.Operacion = OperacionesBD.OperacionUser.UpDate);
                        command.Parameters.AddWithValue("@UserId", Util.ZeroToNull(_objUsario.UserId));
                        command.Parameters.AddWithValue("@UserCode", Util.EmptyStringToNull(_objUsario.UserCode));
                        command.Parameters.AddWithValue("@UserName", Util.EmptyStringToNull(_objUsario.UserName));
                        command.Parameters.AddWithValue("@Mail", Util.EmptyStringToNull(_objUsario.Mail));
                        command.Parameters.AddWithValue("@Password", Util.EmptyStringToNull(_objUsario.Password));
                        command.Parameters.AddWithValue("@Name", Util.EmptyStringToNull(_objUsario.Name));
                        command.Parameters.AddWithValue("@LastName", Util.EmptyStringToNull(_objUsario.LastName));
                        command.Parameters.AddWithValue("@MotherLastName", Util.EmptyStringToNull(_objUsario.MotherLastName));
                        command.Parameters.AddWithValue("@PhoneNumber", Util.EmptyStringToNull(_objUsario.PhoneNumber));
                        command.Parameters.AddWithValue("@Sex", Util.NullToFalse(_objUsario.Sex));
                        command.Parameters.AddWithValue("@BirthDay", Util.EmptyDateToNull(_objUsario.BirthDay));
                        command.Parameters.AddWithValue("@ModByUserId", Util.ZeroToNull(_objUsario.ModByUserId));

                        int response = command.ExecuteNonQuery();

                        if (response > 0)
                        {
                            if (_objUsario.Imagen.Image != null)
                                _respuesta = CreateImageUser(_objUsario);

                            if (_respuesta.EstatusTransaccion)
                            {
                                _respuesta.Codigo = 100;
                                _respuesta.Mensaje = "El registro se actualizo satisfactoriamente";
                                _respuesta.EstatusTransaccion = true;
                            }
                            else
                            {
                                _respuesta.Codigo = -100;
                                _respuesta.Mensaje = "Ocurrio un error al procesar la solicitud, intente nuevamente.";
                                _respuesta.EstatusTransaccion = false;
                            }
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
        public Respuesta UpdateEstatusUser(Users _objUsario)
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
                        command.CommandText = "SP_Users";
                        command.Parameters.AddWithValue("@Operacion", _objUsario.Operacion = OperacionesBD.OperacionUser.Low_Logic);
                        command.Parameters.AddWithValue("@UserId", Util.ZeroToNull(_objUsario.UserId));
                        command.Parameters.AddWithValue("@IsActive", Util.NullToFalse(_objUsario.IsActive));
                        command.Parameters.AddWithValue("@ModByUserId", Util.ZeroToNull(_objUsario.ModByUserId));

                        int response = command.ExecuteNonQuery();

                        if (response > 0)
                        {
                            _respuesta.Codigo = 100;
                            _respuesta.Mensaje = "El usaurio se desactivo satisfactoriamente";
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
        public Users SelectLogin(Users _objUsario)
        {
            Users _users = new Users();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_Users";
                        command.Parameters.AddWithValue("@Operacion", _objUsario.Operacion = OperacionesBD.OperacionUser.Select_Login);
                        command.Parameters.AddWithValue("@UserCode", Util.EmptyStringToNull(_objUsario.UserCode));
                        command.Parameters.AddWithValue("@UserName", Util.EmptyStringToNull(_objUsario.UserName));
                        command.Parameters.AddWithValue("@TypeUser", Util.NullToFalse(_objUsario.TypeUser));

                        SqlDataReader reader = command.ExecuteReader();
                        var countReg = 0;
                        while (reader.Read())
                        {
                            _users = new Users();
                            _users.Imagen = new ImageUser();
                            _users.Rol = new Role();

                            _users.UserId = (int)Util.NullToZero(reader["UserId"]);
                            _users.UserName = Util.NullToEmptyString(reader["UserName"]);
                            _users.UserCode = Util.NullToEmptyString(reader["UserCode"]);                            
                            _users.Password = _security.DecryptString(Util.NullToEmptyString(reader["Password"]));
                            _users.Name = Util.NullToEmptyString(reader["Name"]);
                            _users.LastName = Util.NullToEmptyString(reader["LastName"]);
                            _users.MotherLastName = Util.NullToEmptyString(reader["MotherLastName"]);
                            _users.PhoneNumber = Util.NullToEmptyString(reader["PhoneNumber"]);
                            _users.Sex = Util.NullToFalse(reader["Sex"]);
                            _users.BirthDay = Util.NullToMinDate(reader["BirthDay"]);
                            _users.TypeUser = Util.NullToFalse(reader["TypeUser"]);
                            _users.AddByUserId = (int)Util.NullToZero(reader["AddByUserId"]);
                            _users.DateAdd = Util.NullToMinDate(reader["DateAdd"]);
                            _users.ModByUserId = (int)Util.NullToZero(reader["ModByUserId"]);
                            _users.DateMod = Util.NullToMinDate(reader["DateMod"]);
                            _users.IsActive = Util.NullToFalse(reader["IsActive"]);

                            _users.Rol.RoleId = (int)Util.NullToZero(reader["RolId"]);
                            _users.Rol.NameRole = Util.NullToEmptyString(reader["RoleName"]);

                            _users.Imagen.Image = (byte[])reader["Image"];
                            _users.Imagen.width_Img = (int)Util.NullToZero(reader["width_Img"]);
                            _users.Imagen.height_Img = (int)Util.NullToZero(reader["height_Img"]);

                            countReg += 1;
                        }

                        if (countReg > 0)
                        {
                            _users.Codigo = 100;
                            _users.Mensaje = "Proceso correcto";
                            _users.EstatusTransaccion = true;
                        }
                        else
                        {
                            _users.Codigo = -100;
                            _users.Mensaje = "El usuario no existe, favor de validar.";
                            _users.EstatusTransaccion = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _users.Codigo = -600;
                _users.Mensaje = ex.Message;
                _users.EstatusTransaccion = false;
            }
            return _users;
        }
        public List<Users> AllOrWhereUsers(int _userId, bool _parameter, bool _typeUser)
        {
           List<Users> _Lstusers = new List<Users>();
           Users _users = new Users();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_Users";
                        
                        if (_parameter)
                        {
                            command.Parameters.AddWithValue("@Operacion", OperacionesBD.OperacionUser.Select_Where);
                            command.Parameters.AddWithValue("@UserId", (int)Util.NullToZero(_userId));
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Operacion", OperacionesBD.OperacionUser.Select_All);
                        }
                        command.Parameters.AddWithValue("@TypeUser", Util.NullToFalse(_typeUser));

                        SqlDataReader reader = command.ExecuteReader();
                        var countReg = 0;
                        while (reader.Read())
                        {
                            _users = new Users();
                            _users.Imagen = new ImageUser();
                            _users.Rol = new Role();

                            _users.UserId = (int)Util.NullToZero(reader["UserId"]);
                            _users.UserName = Util.NullToEmptyString(reader["UserName"]);
                            _users.UserCode = Util.NullToEmptyString(reader["UserCode"]);
                            _users.Password = _security.DecryptString(Util.NullToEmptyString(reader["Password"]));
                            _users.Name = Util.NullToEmptyString(reader["Name"]);
                            _users.LastName = Util.NullToEmptyString(reader["LastName"]);
                            _users.MotherLastName = Util.NullToEmptyString(reader["MotherLastName"]);
                            _users.PhoneNumber = Util.NullToEmptyString(reader["PhoneNumber"]);
                            _users.Sex = Util.NullToFalse(reader["Sex"]);
                            _users.BirthDay = Util.NullToMinDate(reader["BirthDay"]);
                            _users.TypeUser = Util.NullToFalse(reader["TypeUser"]);
                            _users.AddByUserId = (int)Util.NullToZero(reader["AddByUserId"]);
                            _users.DateAdd = Util.NullToMinDate(reader["DateAdd"]);
                            _users.ModByUserId = (int)Util.NullToZero(reader["ModByUserId"]);
                            _users.DateMod = Util.NullToMinDate(reader["DateMod"]);
                            _users.IsActive = Util.NullToFalse(reader["IsActive"]);

                            _users.Rol.RoleId = (int)Util.NullToZero(reader["RolId"]);
                            _users.Rol.NameRole = Util.NullToEmptyString(reader["RoleName"]);

                            _users.Imagen.Image = (byte[])reader["Image"];
                            _users.Imagen.width_Img = (int)Util.NullToZero(reader["width_Img"]);
                            _users.Imagen.height_Img = (int)Util.NullToZero(reader["height_Img"]);

                            _users.Imagen.Huella_1 = (byte[])reader["Huella_1"];
                            _users.Imagen.Huella_2 = (byte[])reader["Huella_2"];
                            _users.Imagen.Huella_3 = (byte[])reader["Huella_3"];
                            _users.Imagen.width_H = (int)Util.NullToZero(reader["width_H1"]);
                            _users.Imagen.height_H = (int)Util.NullToZero(reader["height_H1"]);

                            _users.Codigo = 100;
                            _users.Mensaje = "Proceso correcto";
                            _users.EstatusTransaccion = true;

                            countReg += 1;

                            _Lstusers.Add(_users);
                        }
                        
                        if(countReg<=0)
                        {
                            _users.Codigo = -100;
                            _users.Mensaje = "El usuario no existe, favor de validar.";
                            _users.EstatusTransaccion = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _users.Codigo = -600;
                _users.Mensaje = ex.Message;
                _users.EstatusTransaccion = false;

                _Lstusers.Add(_users);
            }
            return _Lstusers;
        }
        public List<Users> SearchUsers(string _parameter, bool _typeUser)
        {
            List<Users> _Lstusers = new List<Users>();
            Users _users = new Users();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_Users";

                        command.Parameters.AddWithValue("@Operacion", OperacionesBD.OperacionUser.Select_UserName);
                        command.Parameters.AddWithValue("@UserCode", Util.EmptyStringToNull(_parameter));
                        command.Parameters.AddWithValue("@UserName", Util.EmptyStringToNull(_parameter));
                        command.Parameters.AddWithValue("@Name", Util.EmptyStringToNull(_parameter));
                        command.Parameters.AddWithValue("@LastName", Util.EmptyStringToNull(_parameter));
                        command.Parameters.AddWithValue("@MotherLastName", Util.EmptyStringToNull(_parameter));
                        command.Parameters.AddWithValue("@Mail", Util.EmptyStringToNull(_parameter));
                        command.Parameters.AddWithValue("@TypeUser", Util.NullToFalse(_typeUser));

                        SqlDataReader reader = command.ExecuteReader();
                        var countReg = 0;
                        while (reader.Read())
                        {
                            _users = new Users();
                            _users.Imagen = new ImageUser();
                            _users.Rol = new Role();

                            _users.UserId = (int)Util.NullToZero(reader["UserId"]);
                            _users.UserName = Util.NullToEmptyString(reader["UserName"]);
                            _users.UserCode = Util.NullToEmptyString(reader["UserCode"]);
                            _users.Password = _security.DecryptString(Util.NullToEmptyString(reader["Password"]));
                            _users.Name = Util.NullToEmptyString(reader["Name"]);
                            _users.LastName = Util.NullToEmptyString(reader["LastName"]);
                            _users.MotherLastName = Util.NullToEmptyString(reader["MotherLastName"]);
                            _users.PhoneNumber = Util.NullToEmptyString(reader["PhoneNumber"]);
                            _users.Sex = Util.NullToFalse(reader["Sex"]);
                            _users.BirthDay = Util.NullToMinDate(reader["BirthDay"]);
                            _users.TypeUser = Util.NullToFalse(reader["TypeUser"]);
                            _users.AddByUserId = (int)Util.NullToZero(reader["AddByUserId"]);
                            _users.DateAdd = Util.NullToMinDate(reader["DateAdd"]);
                            _users.ModByUserId = (int)Util.NullToZero(reader["ModByUserId"]);
                            _users.DateMod = Util.NullToMinDate(reader["DateMod"]);
                            _users.IsActive = Util.NullToFalse(reader["IsActive"]);

                            _users.Codigo = 100;
                            _users.Mensaje = "Proceso correcto";
                            _users.EstatusTransaccion = true;

                            countReg += 1;

                            _Lstusers.Add(_users);
                        }

                        if (countReg <= 0)
                        {
                            _users.Codigo = -100;
                            _users.Mensaje = "El usuario no existe, favor de validar.";
                            _users.EstatusTransaccion = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _users.Codigo = -600;
                _users.Mensaje = ex.Message;
                _users.EstatusTransaccion = false;

                _Lstusers.Add(_users);
            }
            return _Lstusers;
        }
        public Respuesta CreateImageUser(Users _objUsario)
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
                        command.CommandText = "SP_ImagesUsers";
                        command.Parameters.AddWithValue("@Operacion", _objUsario.Operacion = OperacionesBD.OperacionUser.Insert);
                        command.Parameters.AddWithValue("@UserId", Util.ZeroToNull(_objUsario.UserId));
                        command.Parameters.AddWithValue("@Image", _objUsario.Imagen.Image);
                        command.Parameters.AddWithValue("@width_Img", Util.ZeroToNull(_objUsario.Imagen.width_Img));
                        command.Parameters.AddWithValue("@height_Img", Util.ZeroToNull(_objUsario.Imagen.height_Img));
                        command.Parameters.AddWithValue("@Huella_1", _objUsario.Imagen.Huella_1);
                        command.Parameters.AddWithValue("@Huella_2", _objUsario.Imagen.Huella_2);
                        command.Parameters.AddWithValue("@Huella_3", _objUsario.Imagen.Huella_3);
                        command.Parameters.AddWithValue("@width_H", Util.ZeroToNull(_objUsario.Imagen.width_H));
                        command.Parameters.AddWithValue("@height_H", Util.ZeroToNull(_objUsario.Imagen.height_H));

                        SqlParameter newId = new SqlParameter();
                        newId.Direction = System.Data.ParameterDirection.InputOutput;
                        newId.ParameterName = "@ImgUserId_Out";
                        newId.Value = _objUsario.Imagen.ImgUserId;
                        command.Parameters.Add(newId);

                        int response = command.ExecuteNonQuery();
                        int.TryParse(newId.Value.ToString(), out result_out);
                        _objUsario.Imagen.ImgUserId = result_out;

                        if (_objUsario.Imagen.ImgUserId > 0)
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
        
    }
}
