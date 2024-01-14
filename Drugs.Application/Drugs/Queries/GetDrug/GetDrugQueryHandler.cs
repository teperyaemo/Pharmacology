using AutoMapper;
using Drugs.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Drugs.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drugs.Domain;

namespace Drugs.Application.Drugs.Queries.GetDrug
{
    public class GetDrugQueryHandler : IRequestHandler<GetDrugQuery, DrugVm>
    {
        private readonly IDrugsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDrugQueryHandler(IDrugsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DrugVm> Handle(GetDrugQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Drugs.FirstOrDefaultAsync(drug =>
            drug.DrugId == request.DrugId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Drug), request.DrugId);
            }

            return _mapper.Map<DrugVm>(entity);
        }
    }
}
