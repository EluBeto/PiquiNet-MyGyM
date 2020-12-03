using DPUruNet;
using System;
using System.Collections.Generic;

namespace PiquiNet.GyM.Entities
{
    public class ImageUser
    {
        public int ImgUserId { get; set; }
        public int UserId { get; set; }
        public byte[] Image { get; set; }
        public int width_Img { get; set; }
        public int height_Img { get; set; }
        public byte[] Huella_1 { get; set; }
        public byte[] Huella_2 { get; set; }
        public byte[] Huella_3 { get; set; }
        public int width_H { get; set; }
        public int height_H { get; set; }
        public DateTime DateAdd { get; set; }
        public bool Is_Active { get; set; }
        public List<Fmd> lstFingerFmd { get; set; }
    }
}
