using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBackendCrud.Application.Interfaces
{
    public interface IPuestoRepository
    {
        Task<TBT_PUEST?> Get(int id);
        Task<List<TBT_PUEST>> GetAll();
        Task<TBT_PUEST> Save(TBT_PUEST model);
        Task Update(TBT_PUEST model);
        Task Delete(TBT_PUEST model);
        Task<TBT_PUEST> State(TBT_PUEST model);
    }
}
