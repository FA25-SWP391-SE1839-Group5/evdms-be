namespace EVDMS.DataAccessLayer.Entities
{
    public class Customer : BaseEntity
    {
        public required string FullName { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }

        public ICollection<Quotation> Quotations { get; set; } = [];
        public ICollection<SalesOrder> SalesOrders { get; set; } = [];
        public ICollection<TestDrive> TestDrives { get; set; } = [];
        public ICollection<Feedback> Feedbacks { get; set; } = [];
        public ICollection<CustomerDealer> CustomerDealers { get; set; } = [];
    }
}
