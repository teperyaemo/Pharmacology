using Drugs.Application.Interfaces;
using Drugs.Domain;
using MediatR;

namespace Drugs.Application.DrugVersions.Commands.CreateDrugVersion
{
    public class CreateDrugVersionCommandHandler : IRequestHandler<CreateDrugVersionCommand, Guid>
    {

        private readonly IDrugsDbContext _dbContext;

        public CreateDrugVersionCommandHandler(IDrugsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDrugVersionCommand request, CancellationToken cancellationToken)
        {
            var drugVersion = new DrugVersion
            {
                VersionId = Guid.NewGuid(),
                UserId = request.UserId,
                DrugId = request.DrugId,
                Name = request.Name,
                Groups = request.Groups,
                ActiveSubstance = request.ActiveSubstance,
                MechanismOfAction = request.MechanismOfAction,
                Aindications = request.Aindications,
                Contraindications = request.Contraindications,
                ByEffect = request.ByEffect,
                DirectionsForUseAndDose = request.DirectionsForUseAndDose,
                Recipe = request.Recipe,
                CreationDate = DateTime.Now,
                Approved = false
            };

            await _dbContext.Versions.AddAsync(drugVersion);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return drugVersion.VersionId;
        }
    }
}
