using Microsoft.EntityFrameworkCore;

namespace PriceListEditor.Pagination
{
    public class PagedList<T>
    {
        public List<T> data { get; set; } = new();
        public int currentPage;
        public int totalPages;
        public int pageSize;
        public int totalCount;
        public bool hasPrevious;
        public bool hasNext;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            totalCount = count;
            this.pageSize = pageSize;
            currentPage = pageNumber;
            totalPages = (int)Math.Ceiling(count / (double)pageSize);
            hasPrevious = currentPage > 1;
            hasNext = currentPage < totalPages;
            data.AddRange(items);
        }

        public IEnumerator<T> GetEnumerator() => data.GetEnumerator();

        public PagedList()
        {
        }
        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int? page, int pageSize)
        {
            var count = source.Count();
            int pageNumber = page ?? 1;
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
