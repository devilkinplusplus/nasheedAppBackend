using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Repositories.Abstractions.NasheedPlaylists;
using NasheedAppBack.Repositories.Abstractions.Playlists;
using NasheedAppBack.Services.Abstractions;
using NasheedAppBack.Entities.Model;
using NasheedAppBack.Validators;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace NasheedAppBack.Services.Concretes
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistWriteRepository _playlistWrite;
        private readonly IPlaylistReadRepository _playlistRead;
        private readonly INasheedPlaylistWriteRepository _nasheedPlaylistWriteRepository;
        public PlaylistService(IPlaylistWriteRepository playlistWrite, INasheedPlaylistWriteRepository nasheedPlaylistWriteRepository, IPlaylistReadRepository playlistRead)
        {
            _playlistWrite = playlistWrite;
            _nasheedPlaylistWriteRepository = nasheedPlaylistWriteRepository;
            _playlistRead = playlistRead;
        }

        public async Task<CreatePlaylistResponse> CreatePlaylistAsync(CreatePlaylistDto model)
        {
            ValidationResult vResults = await ValidateUserAsync(model);

            if (vResults.IsValid)
            {
                Playlist playlist = await _playlistWrite.AddEntityAsync(new Playlist
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = model.Title,
                    UserId = model.UserId
                });

                await _playlistWrite.SaveAsync();

                foreach (string nasheedId in model.NasheedIds)
                {
                    await _nasheedPlaylistWriteRepository.AddEntityAsync(new NasheedPlaylist
                    {
                        PlaylistId = playlist.Id,
                        NasheedId = nasheedId,
                    });
                }

                await _nasheedPlaylistWriteRepository.SaveAsync();

                return new() { Succeeded = true };
            }
            return new() { Succeeded = false, Errors = vResults.Errors.Select(x => x.ErrorMessage).ToList() };

        }

        public async Task<IEnumerable<PlaylistDto>> GetUserPlaylistsAsync(string userId)
        {
           IEnumerable<PlaylistDto> playlists = await _playlistRead.GetAllWhere(x => x.UserId == userId)
                               .Include(x => x.NasheedPlaylists)
                               .ThenInclude(x => x.Nasheed)
                               .Select(x => new PlaylistDto
                               {
                                   Id = x.Id,
                                   Title = x.Title,
                                   Nasheeds = x.NasheedPlaylists.Select(np => new NasheedDto
                                   {
                                       Title = np.Nasheed.Title,
                                       AudioPath = np.Nasheed.AudioPath,
                                       CoverImage = np.Nasheed.CoverImage
                                   }).ToList()
                               }).ToListAsync();


            return playlists;
        }







        private async Task<ValidationResult> ValidateUserAsync(CreatePlaylistDto model)
        {
            CreatePlaylistValidator validationRules = new();
            ValidationResult result = await validationRules.ValidateAsync(model);
            return result;
        }


    }
}
