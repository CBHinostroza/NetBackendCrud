using Microsoft.EntityFrameworkCore;
using NetBackendCrud.Application.DTOs.Puesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBackendCrud.Infrastructure.Repositories
{
    public class PuestoRepository : Repository<TBT_PUEST>, IPuestoRepository
    {
        private readonly AppDbContext _appDbContext;

        public PuestoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
