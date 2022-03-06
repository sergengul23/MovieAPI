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
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request.CreateMovieDTO);

            await _unitOfWork.Movies.AddAsync(movie);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{movie.Title} is successfully created.");
        }
    }
}
