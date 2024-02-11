


using Inlamning3.Contexts;
using Inlamning3.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inlamning3.Repository;

internal class CustomerRepository : BaseRepository<CustomerEntity>
{

    private readonly DataContext _context;


    public CustomerRepository(DataContext context) : base(context)
    {

        _context = context;

    }

    public override IEnumerable<CustomerEntity> GetAll()
    {
        return _context.Customers.Include(i => i.Address).Include(i => i.Role).Include(i => i.Orders).ToList();
    }

    public override CustomerEntity GetOne(Expression<Func<CustomerEntity, bool>> expression)
    {

        var result = _context.Customers.Include(i => i.Address).Include(i => i.Role).Include(i => i.Orders).FirstOrDefault(expression);

        return result!;



    }






}
