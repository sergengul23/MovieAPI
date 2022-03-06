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
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDirectorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = _mapper.Map<Director>(request.CreateDirectorDTO);

            await _unitOfWork.Directors.AddAsync(director);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{director.FirstName + " " + director.LastName} is successfully created.");
        }
    }
}
