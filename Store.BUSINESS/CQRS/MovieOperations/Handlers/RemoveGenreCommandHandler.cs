using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class RemoveGenreCommandHandler : IRequestHandler<RemoveGenreCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == request.MovieId, x => x.Genres);

            if (movie == null)
                return new Result(ResultStatus.Error, "Movie is not found.");

            var genre = await _unitOfWork.Genres.GetAsync(x => x.Id == request.GenreId);

            if (genre == null)
                return new Result(ResultStatus.Error, "Genre is not found.");

            if (!movie.Genres.Any(x => x.Id == genre.Id))
                return new Result(ResultStatus.Error, $"{movie.Title} doesn't contain {genre.Name}");

            movie.Genres.Remove(genre);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{genre.Name} is successfully removed from {movie.Title}");
        }
    }
}
