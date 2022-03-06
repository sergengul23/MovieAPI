using MediatR;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Commands
{
    public class DeleteMovieCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
