using MediatR;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.GenreOperations.Commands
{
    public class DeleteGenreCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public DeleteGenreCommand(int id)
        {
            Id = id;
        }
    }
}
