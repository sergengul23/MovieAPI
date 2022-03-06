using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.DirectorOperations.Queries
{
    public class GetDirectorQuery : IRequest<IDataResult<DirectorDTO>>
    {
        public int Id { get; set; }

        public GetDirectorQuery(int id)
        {
            Id = id;
        }
    }
}
