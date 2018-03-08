using SIENN.Db;
using SIENN.Models;

namespace SIENN.DbAccess.Repositories
{
    public class TypeRepository : GenericRepository<TypeEntity>, ITypeRepository
    {
        private SIENNDbContext _context;

        public TypeRepository(SIENNDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
