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
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateActorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = _mapper.Map<Actor>(request.CreateActorDTO);

            await _unitOfWork.Actors.AddAsync(actor);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{actor.FirstName + " " + actor.LastName} is successfully created.");
        }
    }
}
