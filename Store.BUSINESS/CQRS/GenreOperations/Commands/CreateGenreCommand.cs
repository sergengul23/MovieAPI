using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.GenreOperations.Commands
{
    public class CreateGenreCommand : IRequest<IResult>
    {
        public CreateGenreDTO CreateGenreDTO { get; set; }

        public CreateGenreCommand(CreateGenreDTO createGenreDTO)
        {
            CreateGenreDTO = createGenreDTO;
        }
    }
}
