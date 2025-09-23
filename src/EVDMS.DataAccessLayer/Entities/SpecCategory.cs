namespace EVDMS.DataAccessLayer.Entities
{
    public class SpecCategory : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Spec> Specs { get; set; } = [];
    }
}
