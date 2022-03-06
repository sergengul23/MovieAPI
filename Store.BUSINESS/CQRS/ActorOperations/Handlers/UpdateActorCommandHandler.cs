using AutoMapper;
using MediatR;
using Store.BUSINESS.CQRS.ActorOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;
using Store.MODELS.Entities;

namespace Store.BUSINESS.CQRS.ActorOperations.Handlers
{
    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateActorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Actors.AnyAsync(x => x.Id == request.UpdateActorDTO.Id);

            if (response)
            {
                var actor = _mapper.Map<Actor>(request.UpdateActorDTO);

                await _unitOfWork.Actors.UpdateAsync(actor);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{actor.FirstName + " " + actor.LastName} is successfully updated.");
            }

            return new Result(ResultStatus.Error, $"Actor with id {request.UpdateActorDTO.Id} is not found.");
        }
    }
}
