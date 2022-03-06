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
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Genres.AnyAsync(x => x.Id == request.UpdateGenreDTO.Id);

            if (response)
            {
                var genre = _mapper.Map<Genre>(request.UpdateGenreDTO);

                await _unitOfWork.Genres.UpdateAsync(genre);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{genre.Name} is successfully updated.");
            }

            return new Result(ResultStatus.Error, "Genre is not found.");
        }
    }
}
