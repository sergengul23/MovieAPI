using AutoMapper;
using MediatR;
using Store.BUSINESS.CQRS.DirectorOperations.Commands;
using Store.DATA.Abstract.UOW;
using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;
using Store.DATA.Utils.Concrete;
using Store.MODELS.Entities;

namespace Store.BUSINESS.CQRS.DirectorOperations.Handlers
{
    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Directors.AnyAsync(x => x.Id == request.UpdateDirectorDTO.Id);

            if (response)
            {
                var director = _mapper.Map<Director>(request.UpdateDirectorDTO);

                await _unitOfWork.Directors.UpdateAsync(director);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{director.FirstName + " " + director.LastName} is successfully updated.");
            }

            return new Result(ResultStatus.Error, $"Director with id {request.UpdateDirectorDTO.Id} is not found.");
        }
    }
}
