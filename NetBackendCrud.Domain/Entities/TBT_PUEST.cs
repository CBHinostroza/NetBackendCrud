using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetBackendCrud.Domain.Entities
{
    public class TBT_PUEST : Auditorias
    {
        [Key]
        public int IDD_PUEST { get; set; }
        public required string NOM_PUEST { get; set; }
        public required bool EST_REGIS { get; set; }
    }
}
