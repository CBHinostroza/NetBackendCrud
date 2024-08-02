using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBackendCrud.Domain.Common
{
    public class Auditorias
    {
        public required string COD_USUAR_CREAC { get; set; }
        public required DateTime FEC_USUAR_CREAC { get; set; }
        public string? COD_USUAR_MODIF { get; set; }
        public DateTime? FEC_USUAR_MODIF { get; set; }
    }
}
