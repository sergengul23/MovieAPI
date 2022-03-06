using MediatR;
using Store.BUSINESS.CQRS.DirectorOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.DirectorOperations.Handlers
{
    public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, IDataResult<DirectorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDirectorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<DirectorDTO>> Handle(GetDirectorQuery request, CancellationToken cancellationToken)
        {
            var director = await _unitOfWork.Directors.GetAsync(x => x.Id == request.Id, x => x.Movies);

            if (director != null)
            {
                return new DataResult<DirectorDTO>(ResultStatus.Success, new DirectorDTO
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName,
                    BirthDate = director.BirthDate.ToShortDateString(),
                    Movies = director.Movies.Select(x => x.Title).ToList(),
                    HasAnOscar = director.HasAnOscar,
                });
            }

            return new DataResult<DirectorDTO>(ResultStatus.Error, "No director is found.", null);
        }
    }
}
