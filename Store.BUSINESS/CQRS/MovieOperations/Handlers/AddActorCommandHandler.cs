using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class AddActorCommandHandler : IRequestHandler<AddActorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddActorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(AddActorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == request.MovieId, x => x.Actors);

            if (movie == null)
                return new Result(ResultStatus.Error, "Movie is not found.");

            var actor = await _unitOfWork.Actors.GetAsync(x => x.Id == request.ActorId);

            if (actor == null)
                return new Result(ResultStatus.Error, "Actor is not found.");

            if (movie.Actors.Any(x => x.Id == actor.Id))
                return new Result(ResultStatus.Error, $"{actor.FirstName + " " + actor.LastName} is already playing in {movie.Title}");

            movie.Actors.Add(actor);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{actor.FirstName + " " + actor.LastName} is successfully added to {movie.Title}");
        }
    }
}
