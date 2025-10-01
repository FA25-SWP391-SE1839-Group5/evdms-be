namespace EVDMS.DataAccessLayer.Entities
{
    public class Dealer : BaseEntity
    {
        public required string Name { get; set; }
        public required string Region { get; set; }
        public required string Address { get; set; }

        public ICollection<DealerContract> DealerContracts { get; set; } = [];
        public ICollection<Feedback> Feedbacks { get; set; } = [];
        public ICollection<Promotion> Promotions { get; set; } = [];
        public ICollection<Quotation> Quotations { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
        public ICollection<TestDrive> TestDrives { get; set; } = [];
        public ICollection<User> Users { get; set; } = [];
        public ICollection<Vehicle> Vehicles { get; set; } = [];

        public static readonly string[] SearchableColumns = ["Name", "Region", "Address"];
    }
}
