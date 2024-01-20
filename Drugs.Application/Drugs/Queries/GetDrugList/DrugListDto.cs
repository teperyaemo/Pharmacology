using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Domain;

namespace Drugs.Application.Drugs.Queries.GetDrugList
{
    public class DrugListDto : IMapWith<DrugVersion>
    {
        public Guid DrugId { get; set; }
        public string Name { get; set; }
        public string[]? Groups { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DrugVersion, DrugListDto>()
                .ForMember(drugListVm => drugListVm.Name,
                opt => opt.MapFrom(drugVersion => drugVersion.Name))
                .ForMember(drugListVm => drugListVm.Groups,
                opt => opt.MapFrom(drugVersion => drugVersion.Groups));
        }
    }
}
