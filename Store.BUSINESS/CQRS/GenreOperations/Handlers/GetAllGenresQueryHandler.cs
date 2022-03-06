using MediatR;
using Store.BUSINESS.CQRS.GenreOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.GenreOperations.Handlers
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IDataResult<GenreListDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGenresQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<GenreListDTO>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _unitOfWork.Genres.GetAllAsync(null, x => x.Movies);

            if (genres.Count > 0)
            {
                return new DataResult<GenreListDTO>(ResultStatus.Success, new GenreListDTO
                {
                    Genres = genres.Select(x => new GenreDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Movies = x.Movies.Select(x => x.Title).ToList()
                    }).ToList()
                });
            }

            return new DataResult<GenreListDTO>(ResultStatus.Error, "No genre is found.", null);
        }
    }
}
