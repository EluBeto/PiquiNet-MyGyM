using DPUruNet;
using PiquiNet.GyM.Entities;
using PiquiNet.GyM.FingerPrint;
using PiquiNet.GyM.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace PiquiNet.GyM.Data
{
    public class HuellasUserDAO
    {
        string _connectionString = string.Empty;
        Security _security = new Security();
        Util util = new Util();
        RoleDAO roleDAO = new RoleDAO();
        ReaderFinger readerFinger = new ReaderFinger();
        
        public HuellasUserDAO()
        {
            _connectionString = _security.DecryptConnectionString(ConfigurationManager.ConnectionStrings["GyM_DB"].ToString());
        }

        public List<Users> AllUsersHuellas()
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
                        command.CommandText = "SP_ImagesUsers";
                        command.Parameters.AddWithValue("@Operacion", OperacionesBD.OperacionImagesUser.Select_All);

                        SqlDataReader reader = command.ExecuteReader();
                        var countReg = 0;
                        while (reader.Read())
                        {
                            _users = new Users();
                            _users.Imagen = new ImageUser();

                            _users.UserId = (int)Util.NullToZero(reader["UserId"]);
                            _users.UserCode = Util.NullToEmptyString(reader["UserCode"]);
                            _users.Name = Util.NullToEmptyString(reader["Name"]);
                            _users.Sex = Util.NullToFalse(reader["Sex"]);
                            _users.BirthDay = Util.NullToMinDate(reader["BirthDay"]);
                            //_users.DateAdd = Util.NullToMinDate(reader["DateAdd"]);
                            //_users.ModByUserId = (int)Util.NullToZero(reader["ModByUserId"]);
                            //_users.DateMod = Util.NullToMinDate(reader["DateMod"]);
                            //_users.IsActive = Util.NullToFalse(reader["IsActive"]);

                            _users.Imagen.Image = (byte[])reader["Image"];
                            _users.Imagen.width_Img = (int)Util.NullToZero(reader["width_Img"]);
                            _users.Imagen.height_Img = (int)Util.NullToZero(reader["height_Img"]);

                            _users.Imagen.Huella_1 = (byte[])reader["Huella_1"];
                            _users.Imagen.Huella_2 = (byte[])reader["Huella_2"];
                            _users.Imagen.Huella_3 = (byte[])reader["Huella_3"];
                            _users.Imagen.width_H = (int)Util.NullToZero(reader["width_H1"]);
                            _users.Imagen.height_H = (int)Util.NullToZero(reader["height_H1"]);

                            _users.Membrecia = new DetalleMembrecia();

                            _users.Membrecia.Membrecia = Util.NullToEmptyString(reader["NombreMembership"]);
                            _users.Membrecia.FechaFin = Util.NullToMinDate(reader["FechaFin"]);
                            _users.Membrecia.DiasRestantes = (int)Util.NullToZero(reader["DiasRestantes"]);
                            _users.Membrecia.IsActive = Util.NullToFalse(reader["IsActive"]);

                            _users.Codigo = 100;
                            _users.Mensaje = "Proceso correcto";
                            _users.EstatusTransaccion = true;

                            countReg += 1;

                            _Lstusers.Add(_users);
                        }

                        if (countReg >= 1)
                        {
                            for (var i = 0; i < _Lstusers.Count; i++) 
                            {
                                _Lstusers[i].Imagen.lstFingerFmd = new List<Fmd>();
                                Fmd fingerBD = null;
                                byte[] Hprosses = null;
                                int widthH = _Lstusers[i].Imagen.width_H;
                                int heightH = _Lstusers[i].Imagen.height_H;

                                for (var h = 0; h < 3; h++)
                                {
                                    switch (h)
                                    {
                                        case 0:
                                            Hprosses = null;
                                            Hprosses = _Lstusers[i].Imagen.Huella_1;
                                           
                                            break;

                                        case 1:
                                            Hprosses = null;
                                            Hprosses = _Lstusers[i].Imagen.Huella_2;
                                           
                                            break;

                                        case 2:
                                            Hprosses = null;
                                            Hprosses = _Lstusers[i].Imagen.Huella_3;
                                           
                                            break;
                                    }

                                    fingerBD = ConvertFingerBD(Hprosses, widthH, heightH);
                                    _Lstusers[i].Imagen.lstFingerFmd.Add(fingerBD);

                                }
                            }
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

                _Lstusers.Add(_users);
            }
            return _Lstusers;
        }

        private Fmd ConvertFingerBD(byte[] arrFingerPrintBD, int widthFinger, int heigthFinger)
        {
            Fmd FingerRecultConvert = null;
            Bitmap _FingerPrintBD = null;

            try
            {
                _FingerPrintBD = readerFinger.CreateBitmap(arrFingerPrintBD, widthFinger, heigthFinger);
                DataResult<Fmd> resultConversionFingerBD = util.ExtractFmdfromBmp(_FingerPrintBD);
                FingerRecultConvert = resultConversionFingerBD.Data;

            }
            catch (Exception ex)
            {
                FingerRecultConvert = null;
            }
            return FingerRecultConvert;
        }

    }
}
