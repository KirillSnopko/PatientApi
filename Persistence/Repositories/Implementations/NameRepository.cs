using Domain.DbEntities;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories.Implementations;

public sealed class NameRepository : AbstractCrudRepository<Name, string>, INameRepository
{
    public NameRepository(HospitalContext context) : base(context)
    {
    }
}
