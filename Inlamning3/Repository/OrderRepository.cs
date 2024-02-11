


using Inlamning3.Contexts;
using Inlamning3.Entites;

namespace Inlamning3.Repository;

internal class OrderRepository : BaseRepository<OrderEntity>
{

    private readonly DataContext _context;
    public OrderRepository(DataContext context) : base(context)
    {

        _context = context;

    }


}
