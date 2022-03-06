using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.GenreOperations.Commands
{
    public class UpdateGenreCommand : IRequest<IResult>
    {
        public UpdateGenreDTO UpdateGenreDTO { get; set; }

        public UpdateGenreCommand(UpdateGenreDTO updateGenreDTO)
        {
            UpdateGenreDTO = updateGenreDTO;
        }
    }
}
