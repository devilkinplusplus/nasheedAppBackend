using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.Sunnahs;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.Sunnahs
{
    public class SunnahReadRepository : ReadRepository<Sunnah>, ISunnahReadRepository
    {
        public SunnahReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
