using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.ActorOperations.Queries
{
    public class GetAllActorsQuery : IRequest<IDataResult<ActorListDTO>>
    {
    }
}
