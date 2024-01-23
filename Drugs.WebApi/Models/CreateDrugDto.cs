using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Application.Drugs.Commands.CreateDrug;

namespace Drugs.WebApi.Models
{
    public class CreateDrugDto : IMapWith<CreateDrugCommand>
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
            profile.CreateMap<CreateDrugDto, CreateDrugCommand>()
                .ForPath(drugCommand => drugCommand.DrugVersion.Name,
                    opt => opt.MapFrom(drugDto => drugDto.Name))
                .ForPath(drugCommand => drugCommand.DrugVersion.Groups,
                    opt => opt.MapFrom(drugDto => drugDto.Groups))
                .ForPath(drugCommand => drugCommand.DrugVersion.ActiveSubstance,
                    opt => opt.MapFrom(drugDto => drugDto.ActiveSubstance))
                .ForPath(drugCommand => drugCommand.DrugVersion.MechanismOfAction,
                    opt => opt.MapFrom(drugDto => drugDto.MechanismOfAction))
                .ForPath(drugCommand => drugCommand.DrugVersion.Aindications,
                    opt => opt.MapFrom(drugDto => drugDto.Aindications))
                .ForPath(drugCommand => drugCommand.DrugVersion.Contraindications,
                    opt => opt.MapFrom(drugDto => drugDto.Contraindications))
                .ForPath(drugCommand => drugCommand.DrugVersion.ByEffect,
                    opt => opt.MapFrom(drugDto => drugDto.ByEffect))
                .ForPath(drugCommand => drugCommand.DrugVersion.DirectionsForUseAndDose,
                    opt => opt.MapFrom(drugDto => drugDto.DirectionsForUseAndDose))
                .ForPath(drugCommand => drugCommand.DrugVersion.Recipe,
                    opt => opt.MapFrom(drugDto => drugDto.Recipe));
        }
    }
}
