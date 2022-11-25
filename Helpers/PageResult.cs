
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryListBackEnd.Helpers
{
    public class PageResult<T>
    {
        public Pagination Pagination { get; set; }

        public IEnumerable<T> Items { get; set; }

        public PageResult() { }
        public PageResult (Pagination pagination, IEnumerable<T> data)
        {
            Pagination = pagination;
            Items = data;
        }

        public static IQueryable<T> ToPagedResult(Pagination pagination, IQueryable<T> query)
        {
            pagination.PageNumber = pagination.PageNumber <1 ? 1:pagination.PageNumber;
            if(pagination.PageSize>0)
            {
                query = query.Skip(pagination.PageSize * (pagination.PageNumber - 1))
                        .Take(pagination.PageSize)
                        .AsQueryable();
            }
            return query;
        }
    }
}
