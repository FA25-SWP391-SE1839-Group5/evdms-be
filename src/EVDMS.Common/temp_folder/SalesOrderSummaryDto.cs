public class SalesOrderSummaryDto
{
    public Guid SalesOrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal OutstandingBalance { get; set; }
    public bool IsFullyPaid { get; set; }
}
