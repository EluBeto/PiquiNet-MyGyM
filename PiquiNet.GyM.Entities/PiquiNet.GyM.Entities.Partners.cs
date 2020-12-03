using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PiquiNet.GyM.Entities
{
    public class Partners
    {
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public ImageSource imgSocioModal { get; set; }
        public PropertyTextBlock propTextBlock { get; set; }
    }

    public class PropertyTextBlock
    {
        public string FontFamily { get; set; }
        public Thickness Margin { get; set; }
    }
}
