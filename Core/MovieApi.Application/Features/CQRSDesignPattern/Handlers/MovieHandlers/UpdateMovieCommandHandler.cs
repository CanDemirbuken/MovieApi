using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            movie.Title = command.Title;
            movie.Description = command.Description;
            movie.Status = command.Status;
            movie.ReleaseDate = command.ReleaseDate;
            movie.Rating = command.Rating;
            movie.Duration = command.Duration;
            movie.CoverImageUrl = command.CoverImageUrl;
            movie.CreatedYear = command.CreatedYear;

            await _context.SaveChangesAsync();
        }
    }
}
