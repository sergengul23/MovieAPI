using AutoMapper;
using MediatR;
using Store.BUSINESS.CQRS.MovieOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;
using Store.MODELS.Entities;

namespace Store.BUSINESS.CQRS.MovieOperations.Handlers
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Movies.AnyAsync(x => x.Id == request.UpdateMovieDTO.Id);

            if (response)
            {
                var movie = _mapper.Map<Movie>(request.UpdateMovieDTO);

                await _unitOfWork.Movies.UpdateAsync(movie);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{movie.Title} is successfully updated.");
            }

            return new Result(ResultStatus.Error, "Movie is not found.");
        }
    }
}
