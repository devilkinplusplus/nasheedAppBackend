using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.Nasheeds;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.Nasheeds
{
    public class NasheedReadRepository : ReadRepository<Nasheed>, INasheedReadRepository
    {
        public NasheedReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
