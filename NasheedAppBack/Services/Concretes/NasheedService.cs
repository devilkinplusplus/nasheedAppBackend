using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.Repositories.Abstractions.Nasheeds;
using NasheedAppBack.Services.Abstractions;
using NasheedAppBack.Entities.Model;
using NasheedAppBack.DTOs.ResponseParams;
using Microsoft.EntityFrameworkCore;

namespace NasheedAppBack.Services.Concretes
{
    public class NasheedService : INasheedService
    {
        private readonly INasheedWriteRepository _writeRepository;
        private readonly INasheedReadRepository _readRepository;
        public NasheedService(INasheedWriteRepository writeRepository, INasheedReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<NasheedResponse>> GetAllNasheedsAsync()
        {
            var nasheeds = await _readRepository.GetAll().Select(x => new NasheedResponse
            {
                Id = x.Id,
                Title = x.Title,
                AudioPath = x.AudioPath,
                CoverImage = x.CoverImage
            }).ToListAsync();

            return nasheeds;
        }

        public async Task<NasheedResponse> PostNasheedAsync(NasheedDto nasheedDto)
        {
            Nasheed nasheed = await _writeRepository.AddEntityAsync(new Nasheed
            {
                Id = Guid.NewGuid().ToString(),
                Title = nasheedDto.Title,
                AudioPath = nasheedDto.AudioPath,
                CoverImage = nasheedDto.CoverImage,
            });


            await _writeRepository.SaveAsync();
            return new NasheedResponse { Id = nasheed.Id, Title = nasheed.Title, AudioPath = nasheed.AudioPath, CoverImage = nasheed.CoverImage };

        }
    }
}
