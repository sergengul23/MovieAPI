using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.GenreOperations.Queries
{
    public class GetAllGenresQuery : IRequest<IDataResult<GenreListDTO>>
    {
    }
}
