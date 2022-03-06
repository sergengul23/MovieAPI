using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.DirectorOperations.Commands
{
    public class UpdateDirectorCommand : IRequest<IResult>
    {
        public UpdateDirectorDTO UpdateDirectorDTO { get; set; }

        public UpdateDirectorCommand(UpdateDirectorDTO updateDirectorDTO)
        {
            UpdateDirectorDTO = updateDirectorDTO;
        }
    }
}
