using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBackendCrud.Application.DTOs.Puesto
{
    public class PuestoUpdateRequestDto
    {
        public required string NOM_PUEST { get; set; }
        public required string COD_USUAR_MODIF { get; set; }
    }
}
