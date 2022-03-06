using AutoMapper;
using MediatR;
using Store.BUSINESS.CQRS.GenreOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;
using Store.MODELS.Entities;

namespace Store.BUSINESS.CQRS.GenreOperations.Handlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Genre>(request.CreateGenreDTO);

            await _unitOfWork.Genres.AddAsync(genre);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{genre.Name} is successfully created.");
        }
    }
}
