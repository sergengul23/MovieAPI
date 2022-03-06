using MediatR;
using Store.BUSINESS.CQRS.GenreOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.GenreOperations.Handlers
{
    public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, IDataResult<GenreDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGenreQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<GenreDTO>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.Genres.GetAsync(x => x.Id == request.Id, x => x.Movies);

            if (genre != null)
            {
                return new DataResult<GenreDTO>(ResultStatus.Success, new GenreDTO
                {
                    Id = genre.Id,
                    Name = genre.Name,
                    Movies = genre.Movies.Select(x => x.Title).ToList()
                });
            }

            return new DataResult<GenreDTO>(ResultStatus.Error, "No genre is found.", null);
        }
    }
}
