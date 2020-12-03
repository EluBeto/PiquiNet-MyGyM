using DPUruNet;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using PiquiNet.GyM.Utilities;

namespace PiquiNet.GyM.FingerPrint
{
    public class ReaderFinger
    {
        private ReaderCollection _readers;
        private bool reset;
        private Reader currentReader;
        Util util = new Util();

        public string GetSerial()
        {
            _readers = ReaderCollection.GetReaders();
            string _SerialNumber  = string.Empty;

            foreach (Reader Reader in _readers)
            {
                _SerialNumber = _SerialNumber + "|" + Reader.Description.SerialNumber;
            }

            return _SerialNumber;
        }
        
        

        /// <summary>
        /// Check quality of the resulting capture.
        /// </summary>
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                   // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Create a bitmap from raw data in row/column format.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            //_bitMap = bmp;

            return bmp;
        }

    }
}
