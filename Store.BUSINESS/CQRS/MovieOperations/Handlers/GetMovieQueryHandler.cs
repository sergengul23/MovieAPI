using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, IDataResult<MovieDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMovieQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<MovieDTO>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == request.Id, x => x.Director, x => x.Actors, x => x.Genres);

            if (movie != null)
            {
                return new DataResult<MovieDTO>(ResultStatus.Success, new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Director = movie.Director.FirstName + " " + movie.Director.LastName,
                    Genres = movie.Genres.Select(x => x.Name).ToList(),
                    Actors = movie.Actors.Select(x => x.FirstName + " " + x.LastName).ToList(),
                    ReleasedYear = movie.ReleasedYear,
                    ImdbRating = movie.ImdbRating,
                    HasAnOscar = movie.HasAnOscar,
                    Price = movie.Price
                });
            }

            return new DataResult<MovieDTO>(ResultStatus.Error, "Movie is not found.", null);
        }
    }
}
