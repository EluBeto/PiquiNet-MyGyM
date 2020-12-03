using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiquiNet.GyM.Entities
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int AddByUserId { get; set; }
        public DateTime DateAdd { get; set; }
        public int ModByUserId { get; set; }
        public DateTime DateMod { get; set; }
        public bool? IsActive { get; set; }
    }
    public class DetalleMembrecia
    {
        public string Membrecia { get; set; }
        public DateTime FechaFin { get; set; }
        public int DiasRestantes { get; set; }
        public bool IsActive { get; set; }
    }
}
