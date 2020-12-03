using DPUruNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PiquiNet.GyM.Utilities
{
    public class Util
    {
        Security security = new Security();
        private List<Fmd> preEnrollmentFmd;
        private DataResult<Fmd> enrolledFmd;

        /// <summary>
        /// Convierte una fecha minima a null
        /// </summary>
        /// <param name="value">Fecha a convertir</param>
        /// <returns>Un objeto nulo</returns>
        public static object EmptyDateToNull(DateTime? value)
        {
            DateTime time = DateTime.Now;
            string str = time.ToString();
            if ((value != null) && (value.ToString() != str))
            {
                return value;
            }
            return DBNull.Value;
        }

        /// <summary>
        /// Convierte una cadena vacia a nulo
        /// </summary>
        /// <param name="value">Cadena a convertir </param>
        /// <returns>Objeto nulo</returns>
        public static object EmptyStringToNull(string value)
        {
            if ((value != null) && (value != ""))
            {
                return value;
            }
            return DBNull.Value;
        }

        /// <summary>
        /// Convierte un nulo a cadena vacia
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Cadena vacia</returns>
        public static string NullToEmptyString(object value)
        {
            if (value is DBNull || value == null)
            {
                return "";
            }
            return value.ToString();
        }

        /// <summary>
        /// Cobvierte un valor nulo a false
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Un valor false</returns>
        public static bool NullToFalse(object value)
        {
            if (value is DBNull || value == null)
            {
                return false;
            }
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Convierto un nulo a la fecha minima
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Fecha minima</returns>
        public static DateTime NullToMinDate(object value)
        {
            if (value is DBNull || value == null)
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(value);
        }

        public static object MinDateToNull(DateTime value)
        {
            if (value == DateTime.MinValue || value == null)
            {
                return DBNull.Value;
            }
            return value;
        }

        /// <summary>
        /// Convierto un nulo a la fecha minima
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Fecha minima</returns>
        public static TimeSpan NullToTimeSpan(object value)
        {
            if (value is DBNull || value == null)
            {
                return new TimeSpan(0, 0, 0);
            }
            return (TimeSpan)value;
        }

        public static object TimeSpanToNull(object value)
        {
            if (value.ToString() == "00:00:00" || value == null)
            {
                return DBNull.Value;
            }
            return value;
        }

        /// <summary>
        /// Convierte un null a nothing
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Nothing</returns>
        public static object NullToNothing(object value)
        {
            if (value is DBNull)
            {
                return null;
            }
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// Conviert un objeto a 0
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Valor 0</returns>
        public static double NullToZero(object value)
        {
            if (value is DBNull || value == null)
            {
                return 0.0;
            }
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Conviert un objeto a 0
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Valor 0</returns>
        public static decimal NullToZeroDecimal(object value)
        {
            if (value is DBNull || value == null)
            {
                return 0;
            }
            return Convert.ToDecimal(value);
        }

        public static object NVL(object value, object altValue)
        {
            if ((value is DBNull) | (value == null))
            {
                return altValue;
            }
            return value;
        }

        /// <summary>
        /// Convierte el 0 a nulo
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Nulo</returns>
        public static object ZeroToNull(double value)
        {
            if (value == 0.0)
            {
                return DBNull.Value;
            }
            return value;
        }

        /// <summary>
        /// Convierte el 0 a nulo
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Nulo</returns>
        public static object ZeroDecimalToNull(decimal value)
        {
            if (value == 0)
            {
                return DBNull.Value;
            }
            return value;
        }

        /// <summary>
        /// Convierte un objecto nulo a nulo
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Nulo</returns>
        public static object NullToNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }

        /// <summary>
        /// Convierte un valor nullo a Byte[]
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <returns>Byte vacio</returns>
        public static byte[] NullToByte(byte[] value)
        {
            if (value == null)
            {
                return new byte[0];
            }
            return value;
        }

        public ImageSource GetGlowingImage(string _Uri)
        {
            BitmapImage glowIcon = new BitmapImage();

            glowIcon.BeginInit();
            glowIcon.UriSource = new Uri(@_Uri);
            glowIcon.EndInit();

            return glowIcon;
        }

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public ImageSource ImageSourceFromBitmap(Bitmap GetBitmap)
        {
            var handle = GetBitmap.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }

        public void CreateArchivo(string _Path, string _Name, string _Content)
        {
            if (!(Directory.Exists(@_Path)))
            {
                //DirectoryInfo dInfo = new DirectoryInfo(_Path);
                //DirectorySecurity dSecurity = dInfo.GetAccessControl();
                //dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                //dInfo.SetAccessControl(dSecurity);

                Directory.CreateDirectory(@_Path);
                File.SetAttributes(_Path, FileAttributes.Normal);
                File.SetAttributes(_Path, FileAttributes.Hidden);
            }

            if (Directory.Exists(@_Path))
            {
                CreateFile(_Name, _Content);
            }
        }

        public void CreateFile(string _Path, string _Content)
        {
            if (File.Exists(@_Path))
            {
                File.Delete(@_Path);
            }
            else
            {
                using (File.Create(@_Path))

                    _Content = security.Reverse(_Content);
                    _Content = security.EncryptString(_Content);
                    _Content = security.StrToHex(_Content);

                File.WriteAllText(@_Path, _Content);
            }
        }

        public string ReadFile(string _Path, string _FileName)
        {
            string _credenciales  = string.Empty;

            try
            {
                if (Directory.Exists(@_Path))
                {
                    using (StreamReader readFile = new StreamReader(@_FileName))
                    {
                        _credenciales = readFile.ReadLine();
                        _credenciales = security.HextoStr(_credenciales);
                        _credenciales = security.DecryptString(_credenciales);
                        _credenciales = security.Reverse(_credenciales);
                        readFile.Close();
                    }
                }
                else
                {
                    _credenciales = "|";
                }
            }
            catch(Exception ex)
            {
                _credenciales = "|";
            }

            return _credenciales;
        }

        public byte[] ImageToByte(Bitmap bitmapImg)
        {
            BitmapData bmpdata = null;

            bmpdata = bitmapImg.LockBits(new Rectangle(0, 0, bitmapImg.Width, bitmapImg.Height), ImageLockMode.ReadOnly, bitmapImg.PixelFormat);
            int numbytes = bmpdata.Stride * bitmapImg.Height;
            byte[] bytedata = new byte[numbytes];
            IntPtr ptr = bmpdata.Scan0;

            Marshal.Copy(ptr, bytedata, 0, numbytes);

            return bytedata;

            //MemoryStream stream = new MemoryStream();
            //img.Save(stream, ImageFormat.Bmp);
            //return stream.ToArray();

            //ImageConverter converter = new ImageConverter();
            //return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public Bitmap ByteToImage(byte[] imageData, int ancho, int alto)
        {
            //Here create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(ancho, alto, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //Create a BitmapData and Lock all pixels to be written 
            BitmapData bmpData = bmp.LockBits(
                                 new Rectangle(0, 0, bmp.Width, bmp.Height),
                                 ImageLockMode.WriteOnly, bmp.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(imageData, 0, bmpData.Scan0, imageData.Length);

            //Unlock the pixels
            bmp.UnlockBits(bmpData);

            //Return the bitmap 
            return bmp;

        }

        public byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public byte[] ExtractByteArray(Bitmap img)
        {
            byte[] rawData = null;
            byte[] bitData = null;
            //ToDo: CreateFmdFromRaw only works on 8bpp bytearrays. As such if we have an image with 24bpp then average every 3 values in Bitmapdata and assign it to bitdata
            if (img.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {

                //Lock the bitmap's bits
                BitmapData bitmapdata = img.LockBits(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, img.PixelFormat);
                //Declare an array to hold the bytes of bitmap
                byte[] imgData = new byte[bitmapdata.Stride * bitmapdata.Height]; //stride=360, height 392

                //Copy bitmapdata into array
                Marshal.Copy(bitmapdata.Scan0, imgData, 0, imgData.Length);//imgData.length =141120

                bitData = new byte[bitmapdata.Width * bitmapdata.Height];//ditmapdata.width =357, height = 392

                for (int y = 0; y < bitmapdata.Height; y++)
                {
                    for (int x = 0; x < bitmapdata.Width; x++)
                    {
                        bitData[bitmapdata.Width * y + x] = imgData[y * bitmapdata.Stride + x];
                    }
                }

                rawData = new byte[bitData.Length];

                for (int i = 0; i < bitData.Length; i++)
                {
                    int avg = (img.Palette.Entries[bitData[i]].R + img.Palette.Entries[bitData[i]].G + img.Palette.Entries[bitData[i]].B) / 3;
                    rawData[i] = (byte)avg;
                }
            }
            else
            {
                bitData = new byte[img.Width * img.Height];//ditmapdata.width =357, height = 392, bitdata.length=139944
                for (int y = 0; y < img.Height; y++)
                {
                    for (int x = 0; x < img.Width; x++)
                    {
                        System.Drawing.Color pixel = img.GetPixel(x, y);
                        bitData[img.Width * y + x] = (byte)((Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B)) / 3);
                    }
                }
            }
           
            return bitData;
        }

        public DataResult<Fmd> ExtractFmdfromBmp(Bitmap img)
        {
            preEnrollmentFmd = new List<Fmd>();
            byte[] imageByte = ExtractByteArray(img);
            int i = 0;
            //height, width and resolution must be same as those of image in ExtractByteArray
            
            DataResult<Fmd> fmd = null;
            
            fmd = FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, img.Width, img.Height, 500, Constants.Formats.Fmd.ANSI);

            //fmd = FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, img.Width, img.Height, 1000, Constants.Formats.Fmd.DP_PRE_REGISTRATION);
            if (fmd.ResultCode == Constants.ResultCode.DP_SUCCESS)
            {
                
                while (i < 4)
                {
                    preEnrollmentFmd.Add(fmd.Data);
                    i++;
                }

                i = 0;

                enrolledFmd = Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preEnrollmentFmd);
                //if (enrolledFmd.ResultCode != Constants.ResultCode.DP_SUCCESS)
                //{ MessageBox.Show("fmd.ResultCode = " + fmd.ResultCode); }
            }

            return enrolledFmd;
        }

    }
}
