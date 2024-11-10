using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.Nasheeds;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.Nasheeds
{
    public class NasheedWriteRepository : WriteRepository<Nasheed>, INasheedWriteRepository
    {
        public NasheedWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
