namespace Utilities.Types
{
    public class PagedResult<T>
    {
        public required List<T> Items { get; set; }
        public required int TotalCount { get; set; }
        public required int PageSize { get; set; }
        public required int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;


        public static PagedResult<T> Create(IEnumerable<T> items, int totalCount, int pageSize, int currentPage)
        {
            return new PagedResult<T>
            {
                Items = items.ToList(),
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = currentPage
            };
        }
    }
}
