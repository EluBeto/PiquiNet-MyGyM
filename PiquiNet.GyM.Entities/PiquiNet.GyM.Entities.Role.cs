using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiquiNet.GyM.Entities
{
    public class Role : Respuesta
    {
        public OperacionesBD.OperacionRole OperacionRole { get; set; }
        public int RoleId { get; set; }
        public string NameRole { get; set; }
        public int AddByUserId { get; set; }
        public DateTime DateAdd { get; set; }
        public int ModByUserId { get; set; }
        public DateTime DateMod { get; set; }
        public bool? IsActive { get; set; }
    }
}
