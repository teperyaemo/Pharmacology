namespace Drugs.Domain
{
    public class PharmaGroup
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public List<DrugVersion>? Versions { get; set; }
    }
}
