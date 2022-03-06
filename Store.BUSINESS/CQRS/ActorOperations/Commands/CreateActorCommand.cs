using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.ActorOperations.Commands
{
    public class CreateActorCommand : IRequest<IResult>
    {
        public CreateActorDTO CreateActorDTO { get; set; }

        public CreateActorCommand(CreateActorDTO createActorDTO)
        {
            CreateActorDTO = createActorDTO;
        }
    }
}
