using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBackendCrud.Domain.DTOs.Puesto
{
    public class PuestoCreateRequestDto
    {
        public required string NOM_PUEST { get; set; }
        public required string COD_USUAR_CREAC { get; set; }
    }
}
