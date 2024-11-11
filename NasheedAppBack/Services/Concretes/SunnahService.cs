using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Repositories.Abstractions.Sunnahs;
using NasheedAppBack.Services.Abstractions;
using NasheedAppBack.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace NasheedAppBack.Services.Concretes
{
    public class SunnahService : ISunnahService
    {
        private readonly ISunnahReadRepository _readRepository;
        private readonly ISunnahWriteRepository _writeRepository;
        public SunnahService(ISunnahReadRepository readRepository, ISunnahWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task CreateSunnahAsync(string content)
        {
            bool isSucceeded = await _writeRepository.AddAsync(new Sunnah
            {
                Id = Guid.NewGuid().ToString(),
                Content = content
            });

            if (isSucceeded)
                await _writeRepository.SaveAsync();
        }

        public async Task<IEnumerable<SunnahResponse>> GetAllSunnahsAsync()
        {
            IEnumerable<SunnahResponse> sunnahs = await _readRepository.GetAll()
                                                               .Select(x=> new SunnahResponse
                                                               {
                                                                   Id = x.Id,
                                                                   Content = x.Content
                                                               })
                                                               .ToListAsync();

            return sunnahs;
        }
    }
}
