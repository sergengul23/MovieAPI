using MediatR;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Commands
{
    public class RemoveGenreCommand : IRequest<IResult>
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public RemoveGenreCommand(int movieId, int genreId)
        {
            MovieId = movieId;
            GenreId = genreId;
        }
    }
}
