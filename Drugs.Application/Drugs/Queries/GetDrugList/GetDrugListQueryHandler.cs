﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Drugs.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Drugs.Application.Drugs.Queries.GetDrugList
{
    public class GetDrugListQueryHandler : IRequestHandler<GetDrugListQuery, DrugListVm>
    {
        private readonly IDrugsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDrugListQueryHandler(IDrugsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DrugListVm> Handle(GetDrugListQuery request, CancellationToken cancellationToken)
        {

            //проверить быстродействие разных исполнений метода
            var drugsQuery = await _dbContext.Drugs.Where(drug => drug.Versions.Last().Approved == true)
                .ProjectTo<DrugListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                drugsQuery = (List<DrugListDto>)drugsQuery.Where(drug => drug.Name.Contains(request.Name));
            }
            if (request.Groups.Count != 0)
            {
                drugsQuery = (List<DrugListDto>)drugsQuery.Where(drug => (bool)(drug.Groups?.Contains(request.Groups.First())));
            }

            return new DrugListVm { DrugList = drugsQuery };
        }
    }
}