using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                Title = command.Title,
                Description = command.Description,
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Rating = command.Rating,
                Status = command.Status,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate
            });

            await _context.SaveChangesAsync();
        }
    }
}
