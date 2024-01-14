using Drugs.Application.Interfaces;
using MediatR;
using Drugs.Domain;

namespace Drugs.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
    {
        private readonly IDrugsDbContext _dbContext;

        public CreateGroupCommandHandler(IDrugsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new PharmaGroup
            {
                GroupId = Guid.NewGuid(),
                Name = request.Name
            };

            await _dbContext.Groups.AddAsync(group);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return group.GroupId;
        }
    }
}
