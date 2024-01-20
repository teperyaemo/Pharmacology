using Drugs.Application.Common.Exceptions;
using Drugs.Application.Interfaces;
using Drugs.Domain;
using MediatR;

namespace Drugs.Application.Drugs.Commands.DeleteCommand
{
    public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, Unit>
    {
        private readonly IDrugsDbContext _dbContext;

        public DeleteDrugCommandHandler(IDrugsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Drugs.FindAsync(new object[] {request.DrugId});

            if(entity == null)
            {
                throw new NotFoundException(nameof(Drug), request.DrugId);
            }

            _dbContext.Drugs.Remove(await entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
