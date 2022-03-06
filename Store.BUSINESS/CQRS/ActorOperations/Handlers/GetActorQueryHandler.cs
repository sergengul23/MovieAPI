using MediatR;
using Store.BUSINESS.CQRS.ActorOperations.Queries;
using Store.BUSINESS.DTOs.ResponseDTOs;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.ActorOperations.Handlers
{
    public class GetActorQueryHandler : IRequestHandler<GetActorQuery, IDataResult<ActorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ActorDTO>> Handle(GetActorQuery request, CancellationToken cancellationToken)
        {
            var actor = await _unitOfWork.Actors.GetAsync(x => x.Id == request.Id, x => x.Movies);

            if (actor != null)
            {
                return new DataResult<ActorDTO>(ResultStatus.Success, new ActorDTO
                {
                    Id = actor.Id,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    BirthDate = actor.BirthDate.ToShortDateString(),
                    HasAnOscar = actor.HasAnOscar,
                    Movies = actor.Movies.Select(x => x.Title).ToList()
                });
            }

            return new DataResult<ActorDTO>(ResultStatus.Error, $"Actor with id {request.Id} is not found", null);
        }
    }
}
