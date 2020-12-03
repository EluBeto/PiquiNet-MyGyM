using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiquiNet.GyM.Entities
{
    public class Users : Respuesta
    {
        public OperacionesBD.OperacionUser Operacion { get; set; }
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Sex { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool TypeUser { get; set; }
        public int AddByUserId { get; set; }
        public DateTime DateAdd { get; set; }
        public int ModByUserId { get; set; }
        public DateTime DateMod { get; set; }   
        public bool? IsActive { get; set; }
        public Role Rol { get; set; }
        public ImageUser Imagen { get; set; }
        public DetalleMembrecia Membrecia { get; set; }
    }
}
