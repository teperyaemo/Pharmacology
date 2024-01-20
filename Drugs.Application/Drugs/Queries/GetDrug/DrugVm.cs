using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Domain;

namespace Drugs.Application.Drugs.Queries.GetDrug
{
    public class DrugVm : IMapWith<Drug>
    {
        public Guid DrugId {  get; set; }
        public DrugVersion LastDrugVersion { get; set; }
        public DateTime UpdateDate { get; set; }
        
        public string Name { get => LastDrugVersion.Name; set { } }
        public string[]? Groups { get => LastDrugVersion.Groups; set { } }
        public string? ActiveSubstance { get => LastDrugVersion.ActiveSubstance; set { } }
        public string? MechanismOfAction { get => LastDrugVersion.MechanismOfAction; set { } }
        public string? Aindications { get => LastDrugVersion.Aindications; set { } }
        public string? Contraindications { get => LastDrugVersion.Contraindications; set { } }
        public string? ByEffect { get => LastDrugVersion.ByEffect; set { } }
        public string? DirectionsForUseAndDose { get => LastDrugVersion.DirectionsForUseAndDose; set { } }
        public string? Recipe { get => LastDrugVersion.Recipe; set { } }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Drug, DrugVm>()
                .ForMember(drugVm => drugVm.LastDrugVersion,
                opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true)));
        }
    }
}
