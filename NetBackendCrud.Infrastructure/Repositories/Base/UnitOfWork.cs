using Microsoft.Extensions.Options;
using NetBackendCrud.Application.Interfaces.Base;

namespace NetBackendCrud.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        public IPuestoRepository puestoRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            puestoRepository = new PuestoRepository(_context);
        }

        #region Commits
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}