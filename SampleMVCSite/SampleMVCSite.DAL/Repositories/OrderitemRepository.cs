using SampleMVCSite.Contracts.Data;
using SampleMVCSite.DAL.Repositories;
using SampleMVCSite.Models;
using System;

namespace SampleMVCSite.Contracts.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>
    {
        public OrderItemRepository(DataContext context)
            : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}
