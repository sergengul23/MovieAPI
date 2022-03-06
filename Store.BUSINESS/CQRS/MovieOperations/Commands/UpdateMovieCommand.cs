using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Commands
{
    public class UpdateMovieCommand : IRequest<IResult>
    {
        public UpdateMovieDTO UpdateMovieDTO { get; set; }

        public UpdateMovieCommand(UpdateMovieDTO updateMovieDTO)
        {
            UpdateMovieDTO = updateMovieDTO;
        }
    }
}
