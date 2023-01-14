using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedCustomerSpacifications : Specification<Customer>
    {
        public PagedCustomerSpacifications(int pageSize,int pageNumber, string name) {
            Query.Skip((pageNumber-1)* pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(name))
            {
                Query.Search(x=> x.Name, "%"+name+ "%");
            }
        }
    }
}
