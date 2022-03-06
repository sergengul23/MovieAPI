using MediatR;
using Store.DATA.Utils.Abstract;

namespace Store.BUSINESS.CQRS.DirectorOperations.Commands
{
    public class DeleteDirectorCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public DeleteDirectorCommand(int id)
        {
            Id = id;
        }
    }
}
