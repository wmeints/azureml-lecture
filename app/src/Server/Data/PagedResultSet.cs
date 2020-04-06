using System.Collections;
using System.Collections.Generic;

namespace CustomerChurn.Server.Data
{
    public class PagedResultSet<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}