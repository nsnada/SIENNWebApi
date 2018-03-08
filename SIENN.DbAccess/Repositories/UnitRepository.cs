using SIENN.Db;
using SIENN.Models;

namespace SIENN.DbAccess.Repositories
{
    public class UnitRepository : GenericRepository<UnitEntity>, IUnitRepository
    {
        private SIENNDbContext _context;

        public UnitRepository(SIENNDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
