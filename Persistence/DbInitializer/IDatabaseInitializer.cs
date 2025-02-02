namespace Persistence.DbInitializer;

public interface IDatabaseInitializer
{
    Task InitializeIfNeededAsync();
}
