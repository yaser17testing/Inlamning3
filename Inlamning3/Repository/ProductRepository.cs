


using Inlamning3.Contexts;
using Inlamning3.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inlamning3.Repository;

internal class ProductRepository : BaseRepository<ProductEntity>
{

    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {

        _context = context;

    }


    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products.Include(i => i.Category).ToList();
    }

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> expression)
    {

        var result = _context.Products.Include(i => i.Category).FirstOrDefault(expression);

        return result!;



    }





}
