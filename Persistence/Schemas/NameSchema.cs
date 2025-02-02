namespace Persistence.Schemas;

public static class NameSchema
{
    public const string Table = "names";

    public class Columns : ColumnsBase
    {
        public const string Use = "use";

        public const string Family = "family";

        public const string Given = "given";
    }
}
