using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies.Select(x => new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate,
                Rating = x.Rating,
                Duration = x.Duration,
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                Status = x.Status
            }).ToList();
        }
    }
}
