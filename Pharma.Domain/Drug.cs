namespace Drugs.Domain
{
    public class Drug
    {
        public Guid DrugId { get; set; }
        public List<DrugVersion>? Versions { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}