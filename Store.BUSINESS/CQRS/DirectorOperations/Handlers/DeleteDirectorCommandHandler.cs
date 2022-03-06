using MediatR;
using Store.BUSINESS.CQRS.DirectorOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.DirectorOperations.Handlers
{
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDirectorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = await _unitOfWork.Directors.GetAsync(x => x.Id == request.Id);

            if (director == null)
                return new Result(ResultStatus.Error, $"Director with id {request.Id} is not found.");

            await _unitOfWork.Directors.DeleteAsync(director);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"Director with id {request.Id} is successfully deleted.");
        }
    }
}
