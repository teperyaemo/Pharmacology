namespace Drugs.Domain
{
    public class DrugVersion
    {
        public Guid VersionId { get; set; }
        public Guid UserId { get; set; }
        public Guid DrugId { get; set; }
        public string Name { get; set; }
        public string[]? Groups { get; set; }
        public string? ActiveSubstance { get; set; }
        public string? MechanismOfAction { get; set; }
        public string? Aindications { get; set; }
        public string? Contraindications { get; set; }
        public string? ByEffect { get; set; }
        public string? DirectionsForUseAndDose { get; set; }
        public string? Recipe { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Approved { get; set; }
        public Drug Drug { get; set; } = null!;
    }
}
