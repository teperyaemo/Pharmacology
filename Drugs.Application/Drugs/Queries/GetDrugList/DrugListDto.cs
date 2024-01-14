using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Application.Drugs.Queries.GetDrug;
using Drugs.Domain;

namespace Drugs.Application.Drugs.Queries.GetDrugList
{
    public class DrugListDto : IMapWith<Drug>
    {
        public Guid DrugId { get; set; }
        public string Name { get; set; }
        public List<PharmaGroup>? Groups { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Drug, DrugVm>()
                .ForMember(drugDto => drugDto.Name,
                opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Name))
                .ForMember(drugDto => drugDto.Groups,
                opt => opt.MapFrom(drug => drug.Versions.Last(version => version.Approved == true).Groups));
        }
    }
}
