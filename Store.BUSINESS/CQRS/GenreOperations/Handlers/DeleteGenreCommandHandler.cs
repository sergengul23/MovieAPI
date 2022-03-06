using MediatR;
using Store.BUSINESS.CQRS.GenreOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.GenreOperations.Handlers
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.Genres.GetAsync(x => x.Id == request.Id);

            if (genre == null)
                return new Result(ResultStatus.Error, "Genre is not found.");

            await _unitOfWork.Genres.DeleteAsync(genre);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"Genre with id {request.Id} is successfully deleted.");
        }
    }
}
