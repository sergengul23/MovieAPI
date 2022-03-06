using MediatR;
using Store.BUSINESS.CQRS.ActorOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.ActorOperations.Handlers
{
    public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, IDataResult<ActorListDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllActorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ActorListDTO>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _unitOfWork.Actors.GetAllAsync(null, x => x.Movies);

            if (actors.Count > 0)
            {
                return new DataResult<ActorListDTO>(ResultStatus.Success, new ActorListDTO
                {
                    Actors = actors.Select(x => new ActorDTO
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate.ToShortDateString(),
                        HasAnOscar = x.HasAnOscar,
                        Movies = x.Movies.Select(x => x.Title).ToList()
                    }).ToList(),
                });
            }

            return new DataResult<ActorListDTO>(ResultStatus.Error, "No actor is found.", null);
        }
    }
}
