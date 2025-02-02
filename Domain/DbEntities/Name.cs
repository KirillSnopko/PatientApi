namespace Domain.DbEntities
{
    public class Name : BaseEntity<string>
    {
        public new string Id { get; set; } = Guid.NewGuid().ToString();

        public string Use { get; set; }

        public string Family { get; set; }

        public string[] Given { get; set; }
    }
}
