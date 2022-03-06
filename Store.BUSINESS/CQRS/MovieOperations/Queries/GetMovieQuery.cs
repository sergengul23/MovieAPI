using MediatR;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.MovieOperations.Queries
{
    public class GetMovieQuery : IRequest<IDataResult<MovieDTO>>
    {
        public int Id { get; set; }

        public GetMovieQuery(int id)
        {
            Id = id;
        }
    }
}
