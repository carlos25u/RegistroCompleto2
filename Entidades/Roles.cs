using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCompleto2.Entidades
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }
        public String Descripcion { get; set; }
    }
}
