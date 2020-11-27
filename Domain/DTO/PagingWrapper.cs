using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class PagingWrapper<T>
    {
        public int totalPages { get; set; }
        public int firstPage { get; set; }
        public int lastPage { get; set; }
        public int prevPage { get; set; }
        public int nextPage { get; set; }
        public int currentPage { get; set; }
        public int totalRows { get; set; }
        public T Data { get; set; }
    }
}
