using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.Sunnahs;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.Sunnahs
{
    public class SunnahWriteRepository : WriteRepository<Sunnah>, ISunnahWriteRepository
    {
        public SunnahWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
