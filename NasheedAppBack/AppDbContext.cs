using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NasheedAppBack.Entities.Identity;
using NasheedAppBack.Entities.Model;

namespace NasheedAppBack
{
    public class AppDbContext : IdentityDbContext<User,Role,string>
    {
        public AppDbContext(DbContextOptions options) : base(options) { 
        }

        public DbSet<Nasheed> Nasheeds { get; set; }
        public DbSet<NasheedPlaylist> NasheedPlaylists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User-Playlist relationship (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Configure Playlist-Nasheed many-to-many relationship with a join entity
            modelBuilder.Entity<NasheedPlaylist>()
                .HasKey(pn => new { pn.PlaylistId, pn.NasheedId });

            modelBuilder.Entity<NasheedPlaylist>()
                .HasOne(pn => pn.Playlist)
                .WithMany(p => p.NasheedPlaylists)
                .HasForeignKey(pn => pn.PlaylistId);

            modelBuilder.Entity<NasheedPlaylist>()
                .HasOne(pn => pn.Nasheed)
                .WithMany(n => n.NasheedPlaylists)
                .HasForeignKey(pn => pn.NasheedId);
        }
    }
}
