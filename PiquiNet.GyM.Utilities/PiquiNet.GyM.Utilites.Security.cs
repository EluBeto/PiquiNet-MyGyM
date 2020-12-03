using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PiquiNet.GyM.Utilities
{
    public class Security
    {
        /// Encripta una cadena
        public string EncryptString(string texto)
        {
            try
            {

                string key = "PikiNetGyM240188"; //llave para encriptar datos

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch (Exception)
            {
                texto = null;
            }
            return texto;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DecryptString(string textoEncriptado)
        {
            try
            {
                string key = "PikiNetGyM240188";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {
                textoEncriptado = null;
            }
            return textoEncriptado;
        }

        public string EncryptConnectionString(string _strCadena)
        {
            var _cadena  = string.Empty;
            string[] arrCadena;

            arrCadena = _strCadena.Split(';');
            _cadena = StrToHex(arrCadena[2]) + "*" + StrToHex(arrCadena[1]) + "*" + StrToHex(arrCadena[0]);
            _cadena = Reverse(_cadena);
            _cadena = EncryptString(_cadena);
            _cadena = StrToHex(_cadena);

            return _cadena;
        }

        public string DecryptConnectionString(string _strCadena)
        {
            var _cadena  = string.Empty;
            string[] arrCadena;

            _cadena = HextoStr(_strCadena);
            _cadena = DecryptString(_cadena);
            _cadena = Reverse(_cadena);
            arrCadena = _cadena.Split('*');
            _cadena = HextoStr(arrCadena[0]) + ";" + HextoStr(arrCadena[1]) + ";" + HextoStr(arrCadena[2]) + ";";

            return _cadena;
        }

        public string StrToHex(string _strCadena)
        {
            var _cadena  = string.Empty;

            var sb = new StringBuilder();
            var bytes = Encoding.Unicode.GetBytes(_strCadena);

            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            _cadena = sb.ToString();

            return _cadena;
        }

        public string HextoStr(string _strCadena)
        {
            var _cadena  = string.Empty;
            var bytes = new byte[_strCadena.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(_strCadena.Substring(i * 2, 2), 16);
            }
            _cadena = Encoding.Unicode.GetString(bytes);

            return _cadena;
        }
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
