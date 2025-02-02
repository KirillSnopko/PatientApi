using Domain.DbEntities;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Interfaces;

public interface INameRepository : ICrudRepository<Name, string> { }
