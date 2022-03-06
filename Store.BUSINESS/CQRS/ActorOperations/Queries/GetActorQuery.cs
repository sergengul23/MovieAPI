using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.ActorOperations.Queries
{
    public class GetActorQuery : IRequest<IDataResult<ActorDTO>>
    {
        public int Id { get; set; }

        public GetActorQuery(int id)
        {
            Id = id;
        }
    }
}
