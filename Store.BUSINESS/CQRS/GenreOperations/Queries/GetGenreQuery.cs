using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.GenreOperations.Queries
{
    public class GetGenreQuery : IRequest<IDataResult<GenreDTO>>
    {
        public int Id { get; set; }

        public GetGenreQuery(int id)
        {
            Id = id;
        }
    }
}
