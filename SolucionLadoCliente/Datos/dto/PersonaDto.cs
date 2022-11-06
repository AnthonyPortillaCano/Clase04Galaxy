using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.dto
{
    public class PersonaDto
    {
       public int Id { get; set; }

        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get; set; }

        public int Edad { get; set; }
    }
}
