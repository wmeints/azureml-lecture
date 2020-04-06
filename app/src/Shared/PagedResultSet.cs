using System.Collections.Generic;

namespace CustomerChurn.Shared
{
    public class PagedResultSet<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}