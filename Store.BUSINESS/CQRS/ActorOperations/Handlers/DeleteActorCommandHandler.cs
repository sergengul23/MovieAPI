using MediatR;
using Store.BUSINESS.CQRS.ActorOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.ActorOperations.Handlers
{
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteActorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _unitOfWork.Actors.GetAsync(x => x.Id == request.Id);

            if (actor == null)
                return new Result(ResultStatus.Error, $"Actor with id {request.Id} is not found.");

            await _unitOfWork.Actors.DeleteAsync(actor);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"Actor with id {request.Id} is successfully deleted.");
        }
    }
}
