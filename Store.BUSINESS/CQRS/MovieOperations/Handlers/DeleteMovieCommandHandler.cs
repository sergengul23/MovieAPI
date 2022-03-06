using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == request.Id);

            if (movie == null)
                return new Result(ResultStatus.Error, "Movie is not found.");

            await _unitOfWork.Movies.DeleteAsync(movie);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"Movie with id {request.Id} is successfully deleted.");
        }
    }
}
