using MediatR;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Commands
{
    public class CreateMovieCommand : IRequest<IResult>
    {
        public CreateMovieDTO CreateMovieDTO { get; set; }

        public CreateMovieCommand(CreateMovieDTO createMovieDTO)
        {
            CreateMovieDTO = createMovieDTO;
        }
    }
}
