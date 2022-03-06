using MediatR;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Commands
{
    public class RemoveActorCommand : IRequest<IResult>
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public RemoveActorCommand(int movieId, int actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }
    }
}
