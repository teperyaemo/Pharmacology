using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Domain;

namespace Drugs.Application.Drugs.Queries.GetDrug
{
    public class DrugVm : IMapWith<Drug>
    {
        public Guid DrugId {  get; set; }
        public DateTime UpdateDate { get; set; }
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
            profile.CreateMap<Drug, DrugVm>()
                .ForMember(drugVm => drugVm.DrugId,
                    opt => opt.MapFrom(drug => drug.DrugId))
                .ForMember(drugVm => drugVm.UpdateDate,
                    opt => opt.MapFrom(drug => drug.UpdateDate))
                .ForMember(drugVm => drugVm.Name,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Name))
                .ForMember(drugVm => drugVm.Groups,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Groups))
                .ForMember(drugVm => drugVm.ActiveSubstance,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).ActiveSubstance))
                .ForMember(drugVm => drugVm.MechanismOfAction,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).MechanismOfAction))
                .ForMember(drugVm => drugVm.Aindications,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Aindications))
                .ForMember(drugVm => drugVm.Contraindications,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Contraindications))
                .ForMember(drugVm => drugVm.ByEffect,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).ByEffect))
                .ForMember(drugVm => drugVm.DirectionsForUseAndDose,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).DirectionsForUseAndDose))
                .ForMember(drugVm => drugVm.Recipe,
                    opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Recipe));
        }
    }
}