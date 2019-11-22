using Api.Domain._Base;
using System.Threading.Tasks;

namespace Api.Data.Context {
    public class UnitOfWork : IUnitOfWork {
        ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
        }
        public async Task Commit() {
            await _context.SaveChangesAsync();
        }
    }
}
