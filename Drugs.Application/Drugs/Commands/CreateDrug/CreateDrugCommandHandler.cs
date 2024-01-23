using Drugs.Application.Interfaces;
using Drugs.Domain;
using MediatR;

namespace Drugs.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Guid>
    {
        private readonly IDrugsDbContext _dbContext;

        public CreateDrugCommandHandler(IDrugsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
        {
            var drug = new Drug
            {
                DrugId = Guid.NewGuid(),
                UpdateDate = DateTime.UtcNow
            };

            var drugVersion = new DrugVersion
            {
                VersionId = Guid.NewGuid(),
                UserId = request.DrugVersion.UserId,
                DrugId = drug.DrugId,
                Name = request.DrugVersion.Name,
                Groups = request.DrugVersion.Groups,
                ActiveSubstance = request.DrugVersion.ActiveSubstance,
                MechanismOfAction = request.DrugVersion.MechanismOfAction,
                Aindications = request.DrugVersion.Aindications,
                Contraindications = request.DrugVersion.Contraindications,
                ByEffect = request.DrugVersion.ByEffect,
                DirectionsForUseAndDose = request.DrugVersion.DirectionsForUseAndDose,
                Recipe = request.DrugVersion.Recipe,
                CreationDate = DateTime.UtcNow,
                Approved = true
            };
/*
            request.DrugVersion.DrugId = drug.DrugId;
            if(drug.Versions != null)
                drug.Versions?.Add(request.DrugVersion);
            else
            {
                drug.Versions = new List<DrugVersion> {request.DrugVersion};
            }
*/
            await _dbContext.Drugs.AddAsync(drug);
            await _dbContext.Versions.AddAsync(drugVersion);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return drug.DrugId;
        }
    }
}
