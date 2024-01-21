using Drugs.Application.Interfaces;
using Drugs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
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
            request.DrugVersion.DrugId = drug.DrugId;
            if(drug.Versions != null)
                drug.Versions?.Add(request.DrugVersion);
            else
            {
                drug.Versions = new List<DrugVersion> {request.DrugVersion};
            }

            await _dbContext.Drugs.AddAsync(drug);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return drug.DrugId;
        }
    }
}
