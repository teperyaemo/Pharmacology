using AutoMapper;
using Drugs.Application.Common.Mappings;
using Drugs.Application.Drugs.Queries.GetDrugList;

namespace Drugs.WebApi.Models
{
    public class GetAllDrugsDto : IMapWith<GetDrugListQuery>
    {
        public string? Name { get; set; }
        public List<string>? Groups { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAllDrugsDto, GetDrugListQuery>();
        }
    }
}
