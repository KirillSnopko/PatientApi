namespace Persistence.Schemas;

public static class PatientSchema
{
    public const string Table = "patients";

    public class Columns : ColumnsBase
    {
        public const string Gender = "gender";

        public const string DateOfBirth = "date_of_birth";

        public const string Active = "active";

        public const string NameId = "name_id";
    }
}
