using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.DirectorOperations.Queries
{
    public class GetAllDirectorsQuery : IRequest<IDataResult<DirectorListDTO>>
    {
    }
}
