using Drugs.Domain;
using MediatR;

namespace Drugs.Application.DrugVersions.Commands.CreateDrugVersion
{
    public class CreateDrugVersionCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid DrugId { get; set; }
        public string Name { get; set; }
        public List<string>? Groups { get; set; }
        public string? ActiveSubstance { get; set; }
        public string? MechanismOfAction { get; set; }
        public string? Aindications { get; set; }
        public string? Contraindications { get; set; }
        public string? ByEffect { get; set; }
        public string? DirectionsForUseAndDose { get; set; }
        public string? Recipe { get; set; }
    }
}
