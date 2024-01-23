using Drugs.Application.Interfaces;
using MediatR;
using Drugs.Application.Common.Exceptions;
using Drugs.Domain;

namespace Drugs.Application.DrugVersions.Commands.DeleteDrugVersion
{
    public class DeleteDrugVersionCommandHandler : IRequestHandler<DeleteDrugVersionCommand, Unit>
    {
        private readonly IDrugsDbContext _dbContext;

        public DeleteDrugVersionCommandHandler(IDrugsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDrugVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Versions.FindAsync(new object[] { request.VersionId });

            if(entity == null)
            {
                throw new NotFoundException(nameof(DrugVersion), request.VersionId);
            }

            _dbContext.Versions.Remove(await entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}