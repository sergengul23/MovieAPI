using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.ActorOperations.Commands
{
    public class UpdateActorCommand : IRequest<IResult>
    {
        public UpdateActorDTO UpdateActorDTO { get; set; }

        public UpdateActorCommand(UpdateActorDTO updateActorDTO)
        {
            UpdateActorDTO = updateActorDTO;
        }
    }
}
