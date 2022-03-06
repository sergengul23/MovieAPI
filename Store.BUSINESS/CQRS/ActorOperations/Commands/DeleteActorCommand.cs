using MediatR;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.ActorOperations.Commands
{
    public class DeleteActorCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public DeleteActorCommand(int id)
        {
            Id = id;
        }
    }
}
