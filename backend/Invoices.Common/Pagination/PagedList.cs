using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Pagination
{
    public class PagedList<T>
    {
        private List<T> _items = new List<T>();
        public int TotalItems { get => Items.Count(); }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }

        public IEnumerable<T> Items
        {
            get { return _items; }
        }

        public PagedList(IQueryable<T> items, int pageSize, int currentPage, Expression<Func<T, string>> orderByExpression)
        {
            var totalItem = items.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalItem / (decimal)pageSize);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.Min(startIndex + pageSize - 1, totalItem - 1);

            if (currentPage == 1)
            {
                _items.AddRange(items.Take<T>(pageSize)
                    .OrderByDescending(orderByExpression).ToList<T>());
            }
            else
            {
                var skipCount = (currentPage - 1) * pageSize;
                _items.AddRange(items.Skip(skipCount).Take<T>(pageSize)
                    .OrderByDescending(orderByExpression).ToList<T>());
            }

            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

    }
}
