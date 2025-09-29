namespace EVDMS.Common.Dtos
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalResults { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
