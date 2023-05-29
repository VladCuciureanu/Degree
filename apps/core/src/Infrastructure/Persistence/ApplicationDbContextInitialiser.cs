using AudioStreaming.Domain.Entities;
using AudioStreaming.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        if (!_context.Artists.Any())
        {
            _context.Artists.AddRange(
                new Artist
                {
                    Name = "Fake Artist 1"
                },
                new Artist
                {
                    Name = "Fake Artist 2"
                },
                new Artist
                {
                    Name = "Fake Artist 3"
                }
            );

            await _context.SaveChangesAsync();
        }

        if (!_context.Albums.Any())
        {
            _context.Albums.AddRange(
                new Album
                {
                    Name = "Fake Album 1",
                    ArtistId = 1
                },
                new Album
                {
                    Name = "Fake Album 2",
                    ArtistId = 2
                },
                new Album
                {
                    Name = "Fake Album 3",
                    ArtistId = 3
                }
            );

            await _context.SaveChangesAsync();
        }

        if (!_context.Tracks.Any())
        {
            _context.Tracks.AddRange(
                new Track
                {
                    Name = "Fake Track 1",
                    AlbumId = 1
                },
                new Track
                {
                    Name = "Fake Track 2",
                    AlbumId = 1
                },
                new Track
                {
                    Name = "Fake Track 3",
                    AlbumId = 1
                },
                new Track
                {
                    Name = "Fake Track 4",
                    AlbumId = 2
                },
                new Track
                {
                    Name = "Fake Track 5",
                    AlbumId = 2
                },
                new Track
                {
                    Name = "Fake Track 6",
                    AlbumId = 2
                },
                new Track
                {
                    Name = "Fake Track 7",
                    AlbumId = 3
                },
                new Track
                {
                    Name = "Fake Track 8",
                    AlbumId = 3
                },
                new Track
                {
                    Name = "Fake Track 9",
                    AlbumId = 3
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}