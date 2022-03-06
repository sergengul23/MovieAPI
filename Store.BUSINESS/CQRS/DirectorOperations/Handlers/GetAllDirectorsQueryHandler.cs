using MediatR;
using Store.BUSINESS.CQRS.DirectorOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.DirectorOperations.Handlers
{
    public class GetAllDirectorsQueryHandler : IRequestHandler<GetAllDirectorsQuery, IDataResult<DirectorListDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDirectorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<DirectorListDTO>> Handle(GetAllDirectorsQuery request, CancellationToken cancellationToken)
        {
            var directors = await _unitOfWork.Directors.GetAllAsync(null, x => x.Movies);

            if (directors.Count > 0)
            {
                return new DataResult<DirectorListDTO>(ResultStatus.Success, new DirectorListDTO
                {
                    Directors = directors.Select(x => new DirectorDTO
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate.ToShortDateString(),
                        Movies = x.Movies.Select(x => x.Title).ToList(),
                        HasAnOscar = x.HasAnOscar
                    }).ToList()
                });
            }

            return new DataResult<DirectorListDTO>(ResultStatus.Error, "No director is found.", null);
        }
    }
}
