using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class DealerContractDto
    {
        public Guid Id { get; set; }
        public Guid DealerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalesTarget { get; set; }
        public decimal OutstandingDebt { get; set; }
    }

    public class CreateDealerContractDto
    {
        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }

        [Required]
        public required decimal SalesTarget { get; set; }

        [Required]
        public required decimal OutstandingDebt { get; set; }
    }

    public class UpdateDealerContractDto
    {
        [Required]
        public required Guid DealerId { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }

        [Required]
        public required decimal SalesTarget { get; set; }

        [Required]
        public required decimal OutstandingDebt { get; set; }
    }

    public class PatchDealerContractDto
    {
        public Guid? DealerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? SalesTarget { get; set; }
        public decimal? OutstandingDebt { get; set; }
    }
}
