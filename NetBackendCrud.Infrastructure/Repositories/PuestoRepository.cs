using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBackendCrud.Infrastructure.Repositories
{
    public class PuestoRepository : IPuestoRepository
    {
        private readonly AppDbContext _context;

        public PuestoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(TBT_PUEST model)
        {
            _context.TBT_PUEST.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<TBT_PUEST?> Get(int id)
        {
            return await _context.TBT_PUEST.FindAsync(id);
        }

        public async Task<List<TBT_PUEST>> GetAll()
        {
            return await _context.TBT_PUEST.ToListAsync();
        }

        public async Task<TBT_PUEST> Save(TBT_PUEST model)
        {
            model.FEC_USUAR_CREAC = DateTime.Now;
            _context.TBT_PUEST.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<TBT_PUEST> State(TBT_PUEST model)
        {
            model.EST_REGIS = model.EST_REGIS ? false : true;
            _context.TBT_PUEST.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Update(TBT_PUEST model)
        {
            model.FEC_USUAR_MODIF = DateTime.Now;
            _context.TBT_PUEST.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
