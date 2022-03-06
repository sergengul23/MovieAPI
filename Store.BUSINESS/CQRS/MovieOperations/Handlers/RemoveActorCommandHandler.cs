using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class RemoveActorCommandHandler : IRequestHandler<RemoveActorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveActorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(RemoveActorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == request.MovieId, x => x.Actors);

            if (movie == null)
                return new Result(ResultStatus.Error, "Movie is not found.");

            var actor = await _unitOfWork.Actors.GetAsync(x => x.Id == request.ActorId);

            if (actor == null)
                return new Result(ResultStatus.Error, "Actor is not found.");

            if (!movie.Actors.Any(x => x.Id == actor.Id))
                return new Result(ResultStatus.Error, $"{actor.FirstName + " " + actor.LastName} is not playing in {movie.Title}");

            movie.Actors.Remove(actor);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{actor.FirstName + " " + actor.LastName} is successfully removed from {movie.Title}");
        }
    }
}
