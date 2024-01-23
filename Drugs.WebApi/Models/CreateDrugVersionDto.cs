using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Application.DrugVersions.Commands.CreateDrugVersion;

namespace Drugs.WebApi.Models
{
    public class CreateDrugVersionDto : IMapWith<CreateDrugVersionCommand>
    {
        public string Name { get; set; }
        public List<string>? Groups { get; set; }
        public string? ActiveSubstance { get; set; }
        public string? MechanismOfAction { get; set; }
        public string? Aindications { get; set; }
        public string? Contraindications { get; set; }
        public string? ByEffect { get; set; }
        public string? DirectionsForUseAndDose { get; set; }
        public string? Recipe { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDrugVersionDto, CreateDrugVersionCommand>();
        }
    }
}
