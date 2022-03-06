using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Queries
{
    public class GetAllMoviesQuery : IRequest<IDataResult<MovieListDTO>>
    {
    }
}
