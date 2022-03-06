using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IDataResult<MovieListDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<MovieListDTO>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _unitOfWork.Movies.GetAllAsync(null, x => x.Director, x => x.Actors, x => x.Genres);

            if (movies.Count > 0)
            {
                return new DataResult<MovieListDTO>(ResultStatus.Success, new MovieListDTO
                {
                    Movies = movies.Select(x => new MovieDTO
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        Director = x.Director.FirstName + " " + x.Director.LastName,
                        Genres = x.Genres.Select(x => x.Name).ToList(),
                        Actors = x.Actors.Select(x => x.FirstName + " " + x.LastName).ToList(),
                        ReleasedYear = x.ReleasedYear,
                        ImdbRating = x.ImdbRating,
                        HasAnOscar = x.HasAnOscar,
                        Price = x.Price
                    }).ToList()
                });
            }

            return new DataResult<MovieListDTO>(ResultStatus.Error, "No movie is found.", null);
        }
    }
}
