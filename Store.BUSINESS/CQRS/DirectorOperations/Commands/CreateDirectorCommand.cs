using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.DirectorOperations.Commands
{
    public class CreateDirectorCommand : IRequest<IResult>
    {
        public CreateDirectorDTO CreateDirectorDTO { get; set; }

        public CreateDirectorCommand(CreateDirectorDTO createDirectorDTO)
        {
            CreateDirectorDTO = createDirectorDTO;
        }
    }
}
