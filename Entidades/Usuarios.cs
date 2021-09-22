using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCompleto2.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public String nombres { get; set; }
        public String alias { get; set; }
        public String email { get; set; }
        public String clave { get; set; }
        public DateTime fechaingreso { get; set; }
        public bool avtivo { get; set; }

        [ForeignKey("RolID")]
        public virtual Roles Roles { get; set; }
    }
}
